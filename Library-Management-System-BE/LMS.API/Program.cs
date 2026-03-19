using Hangfire;
using LMS.Application;
using LMS.Application.Services;
using LMS.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
try
{


    #region Database
    builder.Services.AddDbContext<LMSDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    #endregion

    // Add Hangfire services
    builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Add the processing server as IHostedService
    builder.Services.AddHangfireServer();

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    // ?? Configure Swagger with JWT Authentication
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "LMS API", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer {your_token}'"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
        });
    });
    //builder.Services.AddControllers()
    //.AddJsonOptions(options =>
    //{
    //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    //    options.JsonSerializerOptions.WriteIndented = true;
    //});

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IBookService, BookService>();
    builder.Services.AddScoped<ITransactionService, TransactionService>();
    builder.Services.AddScoped<IReportService, ReportService>();
    builder.Services.AddScoped<IDashboardService, DashboardService>();
    // Register background service
    // builder.Services.AddHostedService<OverdueNotificationBackgroundService>();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });

    #region Identity 

    builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 3;
        options.Password.RequiredLength = 5;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<LMSDbContext>()
    .AddDefaultTokenProviders();

    #endregion

    #region Authentication

    // Get the Secret Key
    string? stringKey = builder.Configuration["SecretKey"];

    if (string.IsNullOrEmpty(stringKey))
    {
        throw new Exception("SecretKey is not configured in appsettings.json.");
    }

    byte[] keyASBytes = Encoding.ASCII.GetBytes(stringKey);
    SymmetricSecurityKey key = new SymmetricSecurityKey(keyASBytes);

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "AppUserSchema";
        options.DefaultChallengeScheme = "AppUserSchema";
    })
    .AddJwtBearer("AppUserSchema", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

    #endregion

    var app = builder.Build();

    // ?? Call Admin Seeding After App Building
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            //await DbSeeder.SeedAdminAsync(userManager);
            //  await DbSeeder.SeedLibrarianAsync(userManager);
            // await DbSeeder.SeedMembersAsync(userManager);
            //await DbSeeder.SeedTransactionsAsync(unitOfWork); //one time run don't unComment
            // await DbSeeder.SeedUsersWithTransactionsAsync(userManager, unitOfWork,10);  //one time run don't unComment
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during seeding: {ex.Message}");
        }
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowAll");

    app.UseStaticFiles();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    // Configure Hangfire dashboard
    app.UseHangfireDashboard("/hangfire");

    // Schedule the overdue notification job
    var checkIntervalMinutes = builder.Configuration.GetValue<int>("OverdueNotificationOptions:CheckIntervalMinutes");
    var checkIntervalHours = builder.Configuration.GetValue<int>("OverdueNotificationOptions:CheckIntervalHours");
    RecurringJob.AddOrUpdate<OverdueNotificationService>(
        "process-overdue-notifications",
        x => x.ProcessOverdueNotifications(),
        Cron.Daily(checkIntervalHours, checkIntervalMinutes));

    await app.RunAsync();
}
catch (Exception ex)
{
    var x = ex.Message;
    throw;
}