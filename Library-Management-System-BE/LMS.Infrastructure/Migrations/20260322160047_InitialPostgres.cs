using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertedUserId = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ActivationUserId = table.Column<string>(type: "text", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUserId = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    InsertedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertedUserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ActivationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActivationUserId = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    InsertedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertedUserId = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ActivationUserId = table.Column<string>(type: "text", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    PublicationYear = table.Column<int>(type: "integer", nullable: false),
                    AvailableCopies = table.Column<int>(type: "integer", nullable: false),
                    TotalCopies = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    IsTrending = table.Column<bool>(type: "boolean", nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertedUserId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ActivationUserId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUserId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertedUserId = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ActivationUserId = table.Column<string>(type: "text", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    BorrowDays = table.Column<int>(type: "integer", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IssuedByUserId = table.Column<int>(type: "integer", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReturnedByUserId = table.Column<int>(type: "integer", nullable: true),
                    ReturnNotes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastOverdueNotified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertedUserId = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ActivationUserId = table.Column<string>(type: "text", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_IssuedByUserId",
                        column: x => x.IssuedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_ReturnedByUserId",
                        column: x => x.ReturnedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "ActivationTime", "ActivationUserId", "DateOfBirth", "DeletedTime", "DeletedUserId", "Description", "FullName", "ImageUrl", "InsertedTime", "InsertedUserId", "IsActive", "IsDeleted", "UpdateTime", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, null, null, new DateOnly(1896, 9, 1), null, null, "American novelist, best known for 'The Great Gatsby.'", "F. Scott Fitzgerald", "Uploads/Authors/cbb2b78f-8694-4431-a464-3a9b1726cd7f_20250402_175701.webp", null, null, true, false, null, null },
                    { 2, null, null, new DateOnly(1926, 4, 20), null, null, "American author of 'To Kill a Mockingbird.'", "Harper Lee", "Uploads/Authors/37cec819-13d2-4923-9d75-e17474d414a2_20250402_175816.jpeg", null, null, true, false, null, null },
                    { 3, null, null, new DateOnly(1976, 2, 24), null, null, "Israeli historian and author of 'Sapiens.'", "Arthur Charles Clarke", "Uploads/Authors/ea772cf3-f09a-46fc-a574-f56e3566e3bf_20250402_180120.jpeg", null, null, true, false, null, null },
                    { 4, null, null, new DateOnly(1986, 9, 27), null, null, "American memoirist, known for 'Educated.'", "Tara Westover", "Uploads/Authors/bc98f022-05a4-4504-ac55-a6b79a59a477_20250402_180600.webp", null, null, true, false, null, null },
                    { 5, null, null, new DateOnly(1942, 1, 8), null, null, "English theoretical physicist, known for 'A Brief History of Time.'", "Stephen Hawking", "Uploads/Authors/0c495402-9543-4952-8f69-66f39043f4f7_20250402_180804.jpeg", null, null, true, false, null, null },
                    { 6, null, null, new DateOnly(1941, 3, 26), null, null, "English evolutionary biologist, author of 'The Selfish Gene.'", "Richard Dawkins", "Uploads/Authors/1e0f58a7-04d3-4a67-acde-7df83d2dce5a_20250402_181011.jpeg", null, null, true, false, null, null },
                    { 7, null, null, new DateOnly(1959, 5, 13), null, null, "American mathematician, author of 'The Joy of x.'", "Steven Strogatz", "Uploads/Authors/0118303f-f410-4423-8dab-5e23924cdef0_20250402_181147.jpeg", null, null, true, false, null, null },
                    { 8, null, null, new DateOnly(1838, 12, 20), null, null, "English schoolmaster and theologian, known for 'Flatland.'", "Edwin A. Abbott", "Uploads/Authors/1be5aefe-56c4-4d1e-b87c-aaf3211c5acf_20250402_160002.jpeg", null, null, true, false, null, null },
                    { 9, null, null, new DateOnly(1929, 6, 12), null, null, "Jewish diarist, known for 'The Diary of a Young Girl.'", "Anne Frank", "Uploads/Authors/c979a01b-7192-45d1-b2a8-51efc59f9199_20250402_151258.jpeg", null, null, true, false, null, null },
                    { 10, null, null, new DateOnly(1971, 8, 10), null, null, "British historian, author of 'The Silk Roads.'", "Peter Frankopan", "Uploads/Authors/cfd27d17-0f76-4824-9365-154ff7ee871c_20250402_181600.jpeg", null, null, true, false, null, null },
                    { 11, null, null, new DateOnly(1952, 5, 20), null, null, "American author and biographer, known for 'Steve Jobs.'", "Walter Isaacson", "Uploads/Authors/4d15adec-12ee-4255-ae8e-2ff16a79fe96_20250402_193321.jpeg", null, null, true, false, null, null },
                    { 12, null, null, new DateOnly(1925, 5, 19), null, null, "African American civil rights leader, co-author of 'The Autobiography of Malcolm X.'", "Malcolm X", "Uploads/Authors/5a95aca0-8fb8-406a-ae0e-04d7e02db21f_20250402_174937.jpeg", null, null, true, false, null, null },
                    { 13, null, null, new DateOnly(1819, 8, 1), null, null, "American author, known for 'Moby-Dick.'", "Herman Melville", "Uploads/Authors/ecd8f1b5-49ac-4fcc-aa2b-06815efe01e0_20250402_160403.jpeg", null, null, true, false, null, null },
                    { 14, null, null, new DateOnly(1775, 12, 16), null, null, "English novelist, best known for 'Pride and Prejudice.'", "Jane Austen", "Uploads/Authors/ca76345f-b440-44ad-b582-57f1b9a01a28_20250402_160756.jpeg", null, null, true, false, null, null },
                    { 15, null, null, new DateOnly(121, 4, 26), null, null, "Roman Emperor, known for 'Meditations.'", "Marcus Aurelius", "Uploads/Authors/b4b9c56d-2b43-4764-85be-03cfcc590347_20250402_193607.jpeg", null, null, true, false, null, null },
                    { 16, null, null, new DateOnly(427, 5, 21), null, null, "Ancient Greek philosopher, author of 'The Republic.'", "Plato", "Uploads/Authors/7b593e7a-b03e-49f2-8017-a0c72f802804_20250402_193740.jpeg", null, null, true, false, null, null },
                    { 17, null, null, new DateOnly(1934, 3, 5), null, null, "Israeli-American psychologist, author of 'Thinking, Fast and Slow.'", "Sidney Sheldon", "Uploads/Authors/80598739-3622-4043-a6d7-fe9891d4139d_20250402_152017.jpg", null, null, true, false, null, null },
                    { 18, null, null, new DateOnly(1974, 4, 27), null, null, "American journalist, author of 'The Power of Habit.'", "Charles Duhigg", "Uploads/Authors/a38eed70-fd98-49d9-aaca-8faec2adea2d_20250402_151501.jpeg", null, null, true, false, null, null },
                    { 19, null, null, new DateOnly(1986, 7, 22), null, null, "Author of 'Atomic Habits.'", "James Clear", "Uploads/Authors/1df19d32-8a82-4bda-b4b2-e448c459c7e3_20250402_160708.jpeg", null, null, true, false, null, null },
                    { 20, null, null, new DateOnly(1932, 10, 24), null, null, "American educator, author of 'The 7 Habits of Highly Effective People.'", "Stephen R. Covey", "Uploads/Authors/3697df34-d29d-4fa0-9517-8abf6edb9d57_20250402_193956.jpeg", null, null, true, false, null, null },
                    { 21, null, null, new DateOnly(1909, 3, 20), null, null, "Austrian-born British art historian, known for 'The Story of Art.'", "E.H. Gombrich", "Uploads/Authors/183bd937-d422-4627-81fd-748e3fc64b9c_20250402_155915.webp", null, null, true, false, null, null },
                    { 22, null, null, new DateOnly(1926, 11, 5), null, null, "British art critic and theorist, author of 'Ways of Seeing.'", "John Berger", "Uploads/Authors/67d544cf-f321-4140-b200-2cab44cf829e_20250402_174813.jpeg", null, null, true, false, null, null },
                    { 23, null, null, new DateOnly(1968, 11, 10), null, null, "American music critic, author of 'The Rest Is Noise.'", "Alex Ross", "Uploads/Authors/26201ade-0cb7-44a2-8c42-3ad4a1f989c5_20250402_151223.jpeg", null, null, true, false, null, null },
                    { 24, null, null, new DateOnly(1952, 5, 14), null, null, "American musician and author of 'How Music Works.'", "David Byrne", "Uploads/Authors/82cd6f40-8394-4dc5-87b8-c10cb7cad73c_20250402_152113.webp", null, null, true, false, null, null },
                    { 25, null, null, new DateOnly(1943, 7, 5), null, null, "Dutch-American psychiatrist, author of 'The Body Keeps the Score.'", "Bessel van der Kolk", "Uploads/Authors/e63b6047-7e89-4ba3-a3f0-421239b79656_20250402_151350.jpeg", null, null, true, false, null, null },
                    { 26, null, null, new DateOnly(1962, 6, 10), null, null, "American author, known for 'Born to Run.'", "Christopher McDougall", "Uploads/Authors/6f40020c-45e4-413c-9fcd-8dfa81a95c3a_20250402_151529.jpeg", null, null, true, false, null, null },
                    { 27, null, null, new DateOnly(1877, 3, 15), null, null, "American author, known for 'The Joy of Cooking.'", "Irma S. Rombauer", "Uploads/Authors/d86a4fb2-d5f4-40fe-b68d-311b1da2810e_20250402_160444.jpeg", null, null, true, false, null, null },
                    { 28, null, null, new DateOnly(1979, 11, 7), null, null, "American chef and author of 'Salt, Fat, Acid, Heat.'", "Samin Nosrat", null, null, null, true, false, null, null },
                    { 29, null, null, new DateOnly(1954, 4, 12), null, null, "American author, known for 'Into the Wild.'", "Jon Krakauer", "Uploads/Authors/d59f3b6d-5e14-4fb8-bfa4-eb521d5b1abd_20250402_174850.jpeg", null, null, true, false, null, null },
                    { 30, null, null, new DateOnly(1962, 10, 26), null, null, "American author, known for 'The Geography of Bliss.'", "Eric Weiner", "Uploads/Authors/43c1798a-524f-4b5b-993a-05a9d2f2f861_20250402_160041.jpeg", null, null, true, false, null, null },
                    { 31, null, null, new DateOnly(1965, 7, 20), null, null, "British author, known for the 'Harry Potter' series.", "J.K. Rowling", "Uploads/Authors/e1c62018-0910-48b2-977d-ef6e78b8e2dc_20250402_150251.jpeg", null, null, true, false, null, null },
                    { 32, null, null, new DateOnly(1928, 6, 10), null, null, "American author of children's books, known for 'Where the Wild Things Are.'", "Maurice Sendak", null, null, null, true, false, null, null },
                    { 33, null, null, new DateOnly(1892, 1, 3), null, null, "English author, known for 'The Hobbit.'", "J.R.R. Tolkien", "Uploads/Authors/dcdb66fd-5fb6-43f6-a8ce-9cf0ab5b4008_20250402_160625.jpeg", null, null, true, false, null, null },
                    { 34, null, null, new DateOnly(1973, 6, 6), null, null, "American author, known for 'The Name of the Wind.'", "Patrick Rothfuss", null, null, null, true, false, null, null },
                    { 35, null, null, new DateOnly(1920, 10, 8), null, null, "American science fiction author, known for 'Dune.'", "Frank Herbert", "Uploads/Authors/d8674beb-3d6e-4eff-b657-99174468991d_20250402_160108.jpeg", null, null, true, false, null, null },
                    { 36, null, null, new DateOnly(1948, 3, 17), null, null, "American-Canadian author, known for 'Neuromancer.'", "William Gibson", null, null, null, true, false, null, null },
                    { 37, null, null, new DateOnly(1954, 8, 15), null, null, "Swedish author, known for 'The Girl with the Dragon Tattoo.'", "Stieg Larsson", null, null, null, true, false, null, null },
                    { 38, null, null, new DateOnly(1971, 2, 24), null, null, "American author, known for 'Gone Girl.'", "Gillian Flynn", "Uploads/Authors/f1b1d709-2878-4db0-a1dd-540214e6c6fc_20250402_160327.jpeg", null, null, true, false, null, null },
                    { 39, null, null, new DateOnly(1968, 11, 22), null, null, "Cypriot-British author, known for 'The Silent Patient.'", "Alex Michaelides", "Uploads/Authors/8dcc9a1f-de9c-4185-ae6b-9e111886f1f3_20250402_150936.jpeg", null, null, true, false, null, null },
                    { 40, null, null, new DateOnly(1972, 8, 26), null, null, "British author, known for 'The Girl on the Train.'", "Paula Hawkins", null, null, null, true, false, null, null },
                    { 41, null, null, new DateOnly(1920, 8, 22), null, null, "American author, known for 'Fahrenheit 451.'", "Ray Bradbury", null, null, null, true, false, null, null },
                    { 42, null, null, new DateOnly(1903, 6, 25), null, null, "British author, known for '1984.'", "George Orwell", "Uploads/Authors/ada31ec3-af92-463c-9437-52622a6ff058_20250402_160249.jpeg", null, null, true, false, null, null },
                    { 43, null, null, new DateOnly(1894, 7, 26), null, null, "English author, known for 'Brave New World.'", "Aldous Huxley", "Uploads/Authors/79d85041-8d9e-4dae-97eb-353f2b9efa55_20250402_151129.jpeg", null, null, true, false, null, null },
                    { 44, null, null, new DateOnly(1939, 11, 18), null, null, "Canadian author, known for 'The Handmaid's Tale.'", "Margaret Atwood", null, null, null, true, false, null, null },
                    { 45, null, null, new DateOnly(1919, 1, 1), null, null, "American author, known for 'The Catcher in the Rye.'", "J.D. Salinger", "Uploads/Authors/1620c1c2-16ba-4c2b-a862-9f666a1d6d6f_20250402_160547.jpeg", null, null, true, false, null, null },
                    { 46, null, null, new DateOnly(1950, 7, 22), null, null, "American author, known for 'The Outsiders.'", "S.E. Hinton", null, null, null, true, false, null, null },
                    { 47, null, null, new DateOnly(1854, 10, 16), null, null, "Irish author, known for 'The Picture of Dorian Gray.'", "Oscar Wilde", null, null, null, true, false, null, null },
                    { 48, null, null, new DateOnly(1797, 8, 20), null, null, "English author, known for 'Frankenstein.'", "Mary Shelley", null, null, null, true, false, null, null },
                    { 49, null, null, new DateOnly(1847, 11, 8), null, null, "Irish author, known for 'Dracula.'", "Bram Stoker", "Uploads/Authors/475d6e1b-e566-4e20-b986-04c691089ac4_20250402_151431.jpeg", null, null, true, false, null, null },
                    { 50, null, null, new DateOnly(1821, 11, 11), null, null, "Russian author, known for 'Crime and Punishment.'", "Fyodor Dostoevsky", "Uploads/Authors/f72c8663-b8c9-431d-8012-0a18c45fb6e3_20250402_160154.jpeg", null, null, true, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ActivationTime", "ActivationUserId", "DeletedTime", "DeletedUserId", "Description", "ImageUrl", "InsertedTime", "InsertedUserId", "IsActive", "IsDeleted", "Name", "UpdateTime", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Books that contain stories created from the imagination.", "Uploads/Books/6393e19e-6166-4db4-a076-976352f7e20d_20250330_002637.jpeg", null, null, true, false, "Fiction", null, null },
                    { 2, null, null, null, null, "Books based on real facts and events.", "Uploads/Books/2ec27bb0-5430-41d6-9e10-db55a5ea961c_20250330_002741.jpeg", null, null, true, false, "Non-Fiction", null, null },
                    { 3, null, null, null, null, "Books related to scientific principles, experiments, and discoveries.", "Uploads/Books/c5fc5bee-ea8c-40a9-99c2-936cfa5d041d_20250330_002809.jpeg", null, null, true, false, "Science", null, null },
                    { 4, null, null, null, null, "Books covering mathematical theories, problems, and equations.", "Uploads/Books/35ce256b-5c7d-4436-9fe6-b0a1b6797224_20250330_003015.jpeg", null, null, true, false, "Mathematics", null, null },
                    { 5, null, null, null, null, "Books that discuss past events and historical occurrences.", "Uploads/Books/19a4642e-b144-44d2-b37e-8773f4e9a52b_20250330_003044.jpeg", null, null, true, false, "History", null, null },
                    { 6, null, null, null, null, "Books about the lives of individuals, either famous or historical.", "Uploads/Books/8ed4d4a2-6ade-4eba-a3ee-c9760a2757d9_20250330_003206.png", null, null, true, false, "Biography", null, null },
                    { 7, null, null, null, null, "Books considered to have artistic value, including poetry, novels, and drama.", "Uploads/Books/acbae6c0-0c0d-44c3-8f99-4ff327c81005_20250330_003245.jpeg", null, null, true, false, "Literature", null, null },
                    { 8, null, null, null, null, "Books that explore fundamental questions about existence, knowledge, and ethics.", "Uploads/Books/5de8b2ec-4651-4b86-a50c-0352b2ceba84_20250330_003310.jpeg", null, null, true, false, "Philosophy", null, null },
                    { 9, null, null, null, null, "Books related to human behavior, emotions, and cognitive functions.", "Uploads/Books/a079349e-4d11-4521-b07e-8d315b13527f_20250330_003502.jpeg", null, null, true, false, "Psychology", null, null },
                    { 10, null, null, null, null, "Books that provide advice or strategies for improving life and personal growth.", "Uploads/Books/f967b576-dd73-48ec-9162-950caa88d10a_20250330_003606.jpeg", null, null, true, false, "Self-Help", null, null },
                    { 11, null, null, null, null, "Books that focus on various forms of art, including visual arts, sculpture, and performance.", "Uploads/Books/f8237660-039b-4459-bba6-4394d70adad4_20250330_003642.jpeg", null, null, true, false, "Art", null, null },
                    { 12, null, null, null, null, "Books that discuss musical theory, history, and performance techniques.", "Uploads/Books/fb89b2db-af67-44f2-835c-22c0e349d131_20250330_003722.png", null, null, true, false, "Music", null, null },
                    { 13, null, null, null, null, "Books focused on physical well-being, exercise, and mental health.", "Uploads/Books/6bda1890-8333-4bc8-b11e-afad13fa8249_20250330_003809.jpeg", null, null, true, false, "Health & Fitness", null, null },
                    { 14, null, null, null, null, "Books providing recipes and cooking techniques.", "Uploads/Books/ee60663d-c0fd-4a74-874a-2c70733e0f9a_20250330_003916.jpeg", null, null, true, false, "Cooking", null, null },
                    { 15, null, null, null, null, "Books that explore destinations, cultures, and experiences in different parts of the world.", "Uploads/Books/ddde898a-001c-406b-a022-d739209c07a4_20250330_004002.jpeg", null, null, true, false, "Travel", null, null },
                    { 16, null, null, null, null, "Books intended for young readers, including stories and educational books.", "Uploads/Books/c6b34e07-de1d-44ee-8d45-390ae71affbb_20250330_004115.jpeg", null, null, true, false, "Children's Books", null, null },
                    { 17, null, null, null, null, "Books containing magical or fantastical elements set in imaginary worlds.", "Uploads/Books/7f59fdf5-ead6-45c2-9a2b-e6b591880d3e_20250330_004149.jpeg", null, null, true, false, "Fantasy", null, null },
                    { 18, null, null, null, null, "Books set in the future or in space, often incorporating advanced technology or extraterrestrial life.", "Uploads/Books/c75396e8-8da4-4ba1-b644-7a6c6b64e1ce_20250330_004229.jpeg", null, null, true, false, "Science Fiction", null, null },
                    { 19, null, null, null, null, "Books centered around solving a crime or uncovering secrets.", "Uploads/Books/4375faff-2083-449b-a270-67b515001c28_20250330_004256.png", null, null, true, false, "Mystery", null, null },
                    { 20, null, null, null, null, "Books designed to keep the reader on edge with suspense and tension.", "Uploads/Books/cc4b5787-7574-45b2-8d71-06dd0658d491_20250330_004355.jpeg", null, null, true, false, "Thriller", null, null },
                    { 21, null, null, null, null, "Books designed to evoke fear or unease in the reader.", null, null, null, true, false, "Horror", null, null },
                    { 22, null, null, null, null, "Books containing poems, written in verse.", null, null, null, true, false, "Poetry", null, null },
                    { 23, null, null, null, null, "Books focused on religious studies, scriptures, and beliefs.", null, null, null, true, false, "Religion", null, null },
                    { 24, null, null, null, null, "Books that explore personal growth and the search for meaning beyond the material world.", null, null, null, true, false, "Spirituality", null, null },
                    { 25, null, null, null, null, "Books that explore political theory, history, and analysis.", null, null, null, true, false, "Politics", null, null },
                    { 26, null, null, null, null, "Books about the production, distribution, and consumption of goods and services.", null, null, null, true, false, "Economics", null, null },
                    { 27, null, null, null, null, "Books on management, entrepreneurship, and business strategies.", null, null, null, true, false, "Business", null, null },
                    { 28, null, null, null, null, "Books covering advancements in technology, including programming, artificial intelligence, and gadgets.", null, null, null, true, false, "Technology", null, null },
                    { 29, null, null, null, null, "Books on engineering principles, innovations, and applications.", null, null, null, true, false, "Engineering", null, null },
                    { 30, null, null, null, null, "Books about legal studies, statutes, and legal principles.", null, null, null, true, false, "Law", null, null },
                    { 31, null, null, null, null, "Books about the art and techniques of photography.", null, null, null, true, false, "Photography", null, null },
                    { 32, null, null, null, null, "Books on the design and construction of buildings and other structures.", null, null, null, true, false, "Architecture", null, null },
                    { 33, null, null, null, null, "Books about various sports, athletes, and sporting events.", null, null, null, true, false, "Sports", null, null },
                    { 34, null, null, null, null, "Books focused on ecology, nature conservation, and environmental science.", null, null, null, true, false, "Environment", null, null },
                    { 35, null, null, null, null, "Books about cities, urban planning, and metropolitan life.", null, null, null, true, false, "Urban Studies", null, null },
                    { 36, null, null, null, null, "Books related to financial markets, investment strategies, and economic theory.", null, null, null, true, false, "Economics & Finance", null, null },
                    { 37, null, null, null, null, "Books offering advice for raising children and family dynamics.", null, null, null, true, false, "Parenting", null, null },
                    { 38, null, null, null, null, "Books on educational methods, theories, and teaching practices.", null, null, null, true, false, "Education", null, null },
                    { 39, null, null, null, null, "Books consisting of illustrated stories in a comic strip format.", null, null, null, true, false, "Comic Books", null, null },
                    { 40, null, null, null, null, "Books that combine illustrations with narrative storytelling, typically in a longer form.", null, null, null, true, false, "Graphic Novels", null, null },
                    { 41, null, null, null, null, "Books covering sociology, anthropology, and other social studies disciplines.", null, null, null, true, false, "Social Sciences", null, null },
                    { 42, null, null, null, null, "Books related to the scientific study of language and its structure.", null, null, null, true, false, "Linguistics", null, null },
                    { 43, null, null, null, null, "Books about physical geography, the study of places and environments.", null, null, null, true, false, "Geography", null, null },
                    { 44, null, null, null, null, "Books about space exploration, the universe, stars, and planets.", null, null, null, true, false, "Space & Astronomy", null, null },
                    { 45, null, null, null, null, "Books that incorporate mathematical themes or problems in their stories.", null, null, null, true, false, "Mathematical Fiction", null, null },
                    { 46, null, null, null, null, "Books about the history and collection of valuable items.", null, null, null, true, false, "Antiques & Collectibles", null, null },
                    { 47, null, null, null, null, "Books about various crafts, from knitting to woodworking.", null, null, null, true, false, "Crafts & Hobbies", null, null },
                    { 48, null, null, null, null, "Books about planting, cultivating, and maintaining gardens.", null, null, null, true, false, "Gardening", null, null },
                    { 49, null, null, null, null, "Books that focus on managing personal wealth, budgeting, and investing.", null, null, null, true, false, "Personal Finance", null, null },
                    { 50, null, null, null, null, "Books that explore real-life criminal cases and investigations.", null, null, null, true, false, "True Crime", null, null }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "ActivationTime", "ActivationUserId", "AuthorId", "AvailableCopies", "CategoryId", "DeletedTime", "DeletedUserId", "Description", "ImageUrl", "InsertedTime", "InsertedUserId", "IsActive", "IsDeleted", "IsTrending", "PublicationYear", "Title", "TotalCopies", "UpdateTime", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, null, null, 1, 10, 1, null, null, "Set in the opulent backdrop of the Roaring Twenties, 'The Great Gatsby' tells the story of Jay Gatsby, a mysterious millionaire obsessed with reuniting with his lost love, Daisy Buchanan. Narrated by Nick Carraway, the novel explores the illusions of wealth and the corruption of the American Dream. Through lavish parties and tragic romance, it portrays a society enthralled by materialism and status, yet hollow beneath the glittering surface. F. Scott Fitzgerald crafts a timeless reflection on desire, disillusionment, and the fragile nature of dreams.", "Uploads/Books/240a09b8-7452-4cda-99e4-48627bfc2ba6_20250330_001414.jpeg", null, null, true, false, false, 1925, "The Great Gatsby", 15, null, null },
                    { 2, null, null, 2, 8, 1, null, null, "Set in the racially segregated American South during the 1930s, 'To Kill a Mockingbird' follows young Scout Finch as she navigates childhood in a deeply divided society. When her father, Atticus Finch, defends a Black man falsely accused of raping a white woman, Scout and her brother Jem are exposed to the harsh realities of prejudice and injustice. Through innocence, courage, and moral growth, Harper Lee's novel powerfully addresses issues of race, empathy, and ethical integrity in a small Alabama town.", "Uploads/Books/bbc43e3c-beff-4517-a107-e3ad3b7c3fbb_20250330_002428.png", null, null, true, false, false, 1960, "To Kill a Mockingbird", 12, null, null },
                    { 3, null, null, 3, 12, 2, null, null, "In 'Sapiens: A Brief History of Humankind,' Yuval Noah Harari chronicles the journey of Homo sapiens from primitive hunter-gatherers to modern global citizens. Through a multidisciplinary lens that includes biology, anthropology, and economics, the book explores major revolutions—cognitive, agricultural, industrial, and technological—that have shaped human society. Harari challenges readers to reconsider assumptions about history, culture, and the future, offering deep insights into the forces that have governed our development and what it truly means to be human.", "Uploads/Books/ec03a3c1-b718-407b-9465-f8e867353021_20250330_000242.jpeg", null, null, true, false, false, 2011, "Sapiens: A Brief History of Humankind", 20, null, null },
                    { 4, null, null, 4, 5, 3, null, null, "'Educated' is Tara Westover's compelling memoir of resilience and transformation. Born to survivalist parents in rural Idaho, she grows up without formal education and is subjected to physical and emotional hardship. Despite the odds, she teaches herself enough to attend college and eventually earns a PhD from Cambridge University. Her journey is a testament to the power of education, personal determination, and the courage it takes to question one's upbringing while seeking truth, growth, and a life of one's own making.", "Uploads/Books/0ff5c317-7915-4ee3-954f-4ebd7608d428_20250329_235320.jpeg", null, null, true, false, false, 2018, "Educated", 7, null, null },
                    { 5, null, null, 5, 15, 4, null, null, "In 'A Brief History of Time,' renowned physicist Stephen Hawking invites readers into the mysterious world of cosmology. Exploring topics such as black holes, the Big Bang, and quantum mechanics, the book simplifies complex concepts while tackling profound questions about the universe's origin, structure, and fate. Hawking's accessible writing and wit help demystify science, making it engaging for the general audience. The book remains a landmark work that inspires curiosity about the cosmos and our place within it.", "Uploads/Books/2f7ebca3-e6c4-4c0b-aeac-ff396a023c49_20250329_234906.jpeg", null, null, true, false, false, 1988, "A Brief History of Time", 25, null, null },
                    { 6, null, null, 6, 8, 2, null, null, "Richard Dawkins' influential book revolutionized the way we think about evolution. Focusing on the gene as the central unit of selection, Dawkins explains how natural selection operates at the genetic level, shaping behavior and life itself. The book is both a scientific treatise and a compelling narrative about the nature of life.", "Uploads/Books/1ecaf167-5c32-4f68-8c43-57b97dec2a3e_20250330_002042.jpeg", null, null, true, false, false, 1976, "The Selfish Gene", 12, null, null },
                    { 7, null, null, 7, 6, 4, null, null, "Steven Strogatz's 'The Joy of x' brings the beauty and wonder of mathematics to life. Through engaging stories and real-world examples, the book reveals how math shapes our everyday experiences, from the patterns in nature to the logic behind technology, making complex concepts accessible and enjoyable for all readers.", "Uploads/Books/eaeefb94-29ae-486b-baba-078d7ca17429_20250330_001647.jpeg", null, null, true, false, false, 2014, "The Joy of x", 9, null, null },
                    { 8, null, null, 8, 7, 5, null, null, "Edwin A. Abbott's novella explores the nature of dimensions through the story of a two-dimensional world inhabited by geometric shapes. As the protagonist discovers the existence of a third dimension, the book offers a satirical commentary on Victorian society and challenges readers to expand their perspectives on reality.", "Uploads/Books/e8b354e3-7ce0-4824-a92d-6cd434ef30cb_20250329_235623.jpeg", null, null, true, false, false, 1884, "Flatland: A Romance of Many Dimensions", 10, null, null },
                    { 9, null, null, 9, 5, 6, null, null, "Anne Frank's diary chronicles her life in hiding during the Nazi occupation of the Netherlands. Through her candid and poignant entries, Anne offers a powerful account of hope, fear, and resilience in the face of unimaginable adversity, leaving a lasting legacy as a testament to the human spirit.", "Uploads/Books/169f079a-cfff-4d87-8f84-5a873a895504_20250330_001103.jpeg", null, null, true, false, false, 1947, "The Diary of a Young Girl", 8, null, null },
                    { 10, null, null, 10, 12, 2, null, null, "Peter Frankopan's 'The Silk Roads' reimagines world history from the perspective of the ancient trade routes that connected East and West. The book explores the cultural, economic, and political exchanges that shaped civilizations, offering a fresh and expansive view of the forces that have defined our world.", "Uploads/Books/c508f639-13fb-425e-8e56-508c3fc2ba6b_20250330_002117.jpeg", null, null, true, false, false, 2015, "The Silk Roads", 18, null, null },
                    { 11, null, null, 11, 10, 7, null, null, "Walter Isaacson's biography of Steve Jobs offers an intimate look at the life and mind of Apple's visionary co-founder. Drawing on exclusive interviews, the book explores Jobs's relentless drive for innovation, his complex personality, and the creative process behind iconic products like the iPhone and Mac. It's a compelling portrait of genius, ambition, and the price of success.", "Uploads/Books/b5d07a17-b507-4aca-ae02-67407a95e307_20250330_000437.jpeg", null, null, true, false, false, 2011, "Steve Jobs", 15, null, null },
                    { 12, null, null, 12, 8, 6, null, null, "Told to journalist Alex Haley, this powerful autobiography traces Malcolm X's journey from a troubled youth to a prominent civil rights leader. The book explores his transformation through faith, his fight for justice, and his evolving views on race and society. It's a story of resilience, self-discovery, and the enduring struggle for equality.", "Uploads/Books/5fd61fc7-4a57-4cec-bc1e-153df1b8d08b_20250330_000750.jpeg", null, null, true, false, false, 1965, "The Autobiography of Malcolm X", 12, null, null },
                    { 13, null, null, 13, 6, 1, null, null, "Herman Melville's classic novel about the obsessive quest to capture the white whale, Moby-Dick. Through Ishmael's narration, the story delves into themes of obsession, fate, and the struggle between man and nature. Rich in symbolism and philosophical insight, it remains a towering achievement in American literature.", "Uploads/Books/7186fad6-481e-4b35-8730-bb5b38fe44d0_20250330_000006.jpeg", null, null, true, false, false, 1851, "Moby-Dick", 10, null, null },
                    { 14, null, null, 14, 10, 1, null, null, "Jane Austen's beloved novel is a witty and romantic exploration of manners, marriage, and social class in Regency England. The story follows Elizabeth Bennet as she navigates misunderstandings and prejudices, ultimately finding love with the enigmatic Mr. Darcy. It's a timeless tale of character, pride, and the transformative power of love.", "Uploads/Books/5b2c0142-74e5-4317-a9fb-dacaa00f2610_20250330_000111.jpeg", null, null, true, false, false, 1813, "Pride and Prejudice", 14, null, null },
                    { 15, null, null, 15, 7, 4, null, null, "Written by Roman Emperor Marcus Aurelius, 'Meditations' is a collection of personal reflections on Stoic philosophy, leadership, and the human condition. The book offers timeless wisdom on resilience, virtue, and self-mastery, providing readers with practical guidance for living a meaningful and ethical life in the face of adversity.", null, null, null, true, false, false, 180, "Meditations", 10, null, null },
                    { 16, null, null, 16, 8, 5, null, null, "Plato's philosophical masterpiece presents a dialogue on justice, the ideal state, and the nature of the soul. Through Socratic questioning, the book explores the meaning of virtue, the structure of society, and the pursuit of truth. It remains a foundational text in Western philosophy and political thought.", null, null, null, true, false, false, -380, "The Republic", 11, null, null },
                    { 17, null, null, 17, 10, 3, null, null, "Nobel laureate Daniel Kahneman explores the dual systems that drive human thought: the fast, intuitive mind and the slow, deliberate mind. Through engaging examples and groundbreaking research, the book reveals how cognitive biases shape our decisions, offering insights into judgment, risk, and the ways we think about the world.", "Uploads/Books/ddfb6c14-a1f1-4685-a835-16afd6354aac_20250330_002323.jpeg", null, null, true, false, false, 2011, "Thinking, Fast and Slow", 15, null, null },
                    { 18, null, null, 18, 9, 3, null, null, "Charles Duhigg's 'The Power of Habit' uncovers the science behind why habits form and how they can be changed. Drawing on research and real-life stories, the book explains the habit loop and provides strategies for transforming routines, empowering readers to make positive changes in their personal and professional lives.", "Uploads/Books/c70e070d-1a1f-499c-9b66-9373873efd4d_20250330_001755.png", null, null, true, false, false, 2012, "The Power of Habit", 14, null, null },
                    { 19, null, null, 19, 10, 3, null, null, "James Clear's 'Atomic Habits' offers a practical guide to building good habits and breaking bad ones through small, incremental changes. The book combines scientific research with actionable advice, showing how tiny adjustments can lead to remarkable results in productivity, health, and overall well-being.", "Uploads/Books/cdb6b6a0-dfc6-4f79-b81f-d53cbd47f797_20250329_234920.jpeg", null, null, true, false, false, 2018, "Atomic Habits", 15, null, null },
                    { 20, null, null, 20, 14, 3, null, null, "Stephen R. Covey's influential book presents a holistic approach to personal and professional effectiveness. Through seven core habits, Covey guides readers toward greater self-awareness, proactive behavior, and meaningful relationships, offering timeless principles for achieving lasting success and fulfillment in all areas of life.", "Uploads/Books/2d209324-e47a-4a72-b249-c27a8fd9b447_20250330_000600.jpeg", null, null, true, false, false, 1989, "The 7 Habits of Highly Effective People", 20, null, null },
                    { 21, null, null, 21, 8, 5, null, null, "E.H. Gombrich's 'The Story of Art' stands as one of the most accessible and comprehensive introductions to art history ever written. Spanning from prehistoric cave paintings to modern masterpieces, the book presents art as a continuous narrative of human creativity and expression. Gombrich's engaging writing style makes complex artistic movements and techniques understandable to readers of all backgrounds. The book explores how art reflects cultural values, technological advances, and human emotions across different periods and civilizations, offering readers a profound appreciation for the visual arts and their enduring impact on society.", "Uploads/Books/f0e19d8b-bc7a-4630-9f96-0cb3b943bcab_20250330_002206.jpeg", null, null, true, false, false, 1950, "The Story of Art", 12, null, null },
                    { 22, null, null, 22, 6, 5, null, null, "John Berger's revolutionary 'Ways of Seeing' challenges conventional approaches to art appreciation and visual culture. Through a series of essays, Berger examines how we perceive and interpret images, questioning the assumptions behind traditional art criticism. The book explores themes of gender, class, and power in visual representation, revealing how images can reinforce or challenge social hierarchies. Berger's Marxist perspective offers readers new tools for analyzing not just fine art, but advertising, photography, and mass media, making this work essential for understanding the politics of visual culture in modern society.", "Uploads/Books/b1f5b2da-1307-47ba-8ea1-fdbe780bd088_20250330_002539.jpeg", null, null, true, false, false, 1972, "Ways of Seeing", 9, null, null },
                    { 23, null, null, 23, 7, 4, null, null, "Alex Ross's 'The Rest Is Noise' offers a sweeping history of 20th-century classical music, exploring how composers responded to the tumultuous events of their time. From the rise of modernism to the impact of war and political upheaval, Ross traces the evolution of musical styles and the lives of influential composers. The book examines how music reflected and influenced social change, from the avant-garde experiments of Stravinsky to the minimalist movements of the late century. Ross's engaging narrative makes complex musical concepts accessible while revealing the profound connections between art, politics, and human experience.", "Uploads/Books/7147db03-a13b-4773-bfd3-d80fe01c4743_20250330_001923.png", null, null, true, false, false, 2007, "The Rest Is Noise", 10, null, null },
                    { 24, null, null, 24, 8, 4, null, null, "David Byrne's 'How Music Works' is a fascinating exploration of music from multiple perspectives: as a cultural phenomenon, a technological medium, and a fundamental human expression. Drawing on his experience as a musician and his curiosity about different musical traditions, Byrne examines how music is created, performed, and experienced across various contexts. The book covers topics ranging from the physics of sound to the economics of the music industry, from ancient musical traditions to digital innovations. Byrne's insights offer readers a deeper understanding of how music shapes our lives and connects us across cultures and generations.", "Uploads/Books/00e82a7d-5452-4a08-b4a0-a75eb692656c_20250329_235723.png", null, null, true, false, false, 2012, "How Music Works", 12, null, null },
                    { 25, null, null, 25, 10, 3, null, null, "Bessel van der Kolk's groundbreaking work 'The Body Keeps the Score' revolutionizes our understanding of trauma and its profound effects on the brain, mind, and body. Drawing on decades of research and clinical experience, van der Kolk explains how traumatic experiences can alter brain chemistry and function, leading to lasting psychological and physical consequences. The book explores innovative treatment approaches, from traditional therapy to body-based interventions like yoga and neurofeedback. Van der Kolk's compassionate perspective offers hope for healing while providing essential insights for anyone affected by trauma or working with trauma survivors.", "Uploads/Books/d7f01374-6dff-4ea2-8d22-afd607cbdc11_20250330_000838.jpeg", null, null, true, false, false, 2014, "The Body Keeps the Score", 15, null, null },
                    { 26, null, null, 26, 6, 2, null, null, "Christopher McDougall's 'Born to Run' combines adventure, science, and human potential in a compelling narrative about the art and science of running. The book follows McDougall's journey to discover the secrets of the Tarahumara, a remote Mexican tribe known for their extraordinary long-distance running abilities. Through their story, McDougall explores evolutionary biology, biomechanics, and the psychology of endurance, challenging conventional wisdom about running shoes, training methods, and human limitations. The book inspires readers to reconsider their relationship with physical activity and discover the joy of movement that lies within us all.", "Uploads/Books/f845f829-8491-4d04-8358-0d9064c7ec90_20250329_235131.jpeg", null, null, true, false, false, 2009, "Born to Run", 10, null, null },
                    { 27, null, null, 27, 7, 8, null, null, "Irma S. Rombauer's 'The Joy of Cooking' has become an American culinary institution, serving as the definitive cookbook for generations of home cooks. First published during the Great Depression, the book has evolved through multiple editions while maintaining its practical approach to cooking. Rombauer's warm, encouraging voice and comprehensive coverage of techniques make complex recipes accessible to beginners while offering depth for experienced cooks. The book celebrates the joy of preparing food for loved ones, emphasizing the connection between cooking, family, and cultural heritage that makes this more than just a collection of recipes.", "Uploads/Books/c3902039-c0cb-4827-93c2-e523bfbca2e8_20250330_001629.png", null, null, true, false, false, 1931, "The Joy of Cooking", 11, null, null },
                    { 28, null, null, 28, 6, 14, null, null, "Samin Nosrat's 'Salt, Fat, Acid, Heat' revolutionizes how we think about cooking by focusing on the four fundamental elements that make food delicious. Rather than memorizing recipes, Nosrat teaches readers to understand the principles behind great cooking, empowering them to create flavorful dishes with confidence. The book combines scientific explanations with practical techniques, beautiful illustrations, and personal anecdotes that make learning to cook both educational and enjoyable. Nosrat's approach encourages experimentation and creativity, helping readers develop an intuitive understanding of how to balance flavors and create memorable meals.", "Uploads/Books/34a1babd-4c98-4060-83e1-4a5ba9710042_20250330_000128.jpeg", null, null, true, false, false, 2017, "Salt, Fat, Acid, Heat", 8, null, null },
                    { 29, null, null, 29, 8, 8, null, null, "Anthony Bourdain's 'Kitchen Confidential' pulls back the curtain on the culinary world, revealing the intense, chaotic, and often brutal reality behind restaurant kitchens. Bourdain's candid and sometimes controversial memoir exposes the passion, pressure, and personalities that drive the food industry. Through vivid storytelling and sharp wit, he shares the lessons learned from his years in professional kitchens, from the importance of proper knife skills to the unspoken rules of kitchen culture. The book offers readers an insider's perspective on the dedication and sacrifice required to create memorable dining experiences.", "Uploads/Books/a26c1840-336e-4111-a9b6-1992fda7e5ca_20250329_235800.jpeg", null, null, true, false, false, 2000, "Kitchen Confidential", 12, null, null },
                    { 30, null, null, 30, 10, 8, null, null, "Michael Pollan's 'The Omnivore's Dilemma' investigates the complex web of choices involved in what we eat, tracing the journey of food from farm to table. Through four different meals, Pollan explores industrial agriculture, organic farming, hunting and gathering, and sustainable food systems. The book examines the environmental, ethical, and health implications of our food choices, challenging readers to consider the true cost of their meals. Pollan's engaging narrative style makes complex issues accessible while providing practical guidance for making more informed and responsible food decisions in our daily lives.", "Uploads/Books/3f907f78-cd85-443b-82a3-d2663bbf74cd_20250330_001723.jpeg", null, null, true, false, false, 2006, "The Omnivore's Dilemma", 15, null, null },
                    { 31, null, null, 31, 7, 7, null, null, "Stephen King's 'On Writing' is both a memoir and a masterclass in the craft of writing. King shares his personal journey from struggling writer to bestselling author, offering practical advice alongside intimate stories from his life. The book covers essential writing techniques, from developing characters and plot to handling rejection and finding your voice. King's honest, conversational style makes complex writing concepts accessible while providing inspiration for aspiring authors. This is more than a how-to guide—it's a testament to the power of persistence and the joy of storytelling.", "Uploads/Books/317c1742-37a7-439c-9b23-00d0a708f7c8_20250330_000039.jpeg", null, null, true, false, false, 2000, "On Writing", 10, null, null },
                    { 32, null, null, 32, 6, 7, null, null, "Anne Lamott's 'Bird by Bird' offers a compassionate and humorous guide to the writing life, filled with practical wisdom and emotional support for writers at every stage. Lamott addresses the common fears and challenges that writers face, from perfectionism to writer's block, offering gentle encouragement and practical strategies. Through personal anecdotes and honest reflections, she explores the creative process, the importance of community, and the courage required to share your work. The book is both a writing manual and a meditation on the human condition, reminding readers that writing is ultimately about connection and truth.", "Uploads/Books/2b87c9ee-4b19-40aa-ba32-8e45a76d4a88_20250329_235032.jpeg", null, null, true, false, false, 1994, "Bird by Bird", 9, null, null },
                    { 33, null, null, 33, 12, 7, null, null, "William Strunk Jr. and E.B. White's 'The Elements of Style' remains the definitive guide to clear, effective writing. This concise manual covers the fundamental principles of composition, grammar, and style that every writer should master. From basic rules of usage to advanced techniques for creating compelling prose, the book provides practical examples and clear explanations. Its timeless advice on brevity, clarity, and precision has influenced generations of writers, making it an essential reference for students, professionals, and anyone who wants to communicate more effectively through the written word.", "Uploads/Books/3d3e4b70-925b-42e4-98ef-42a94c5ae486_20250330_001224.jpeg", null, null, true, false, false, 1959, "The Elements of Style", 18, null, null },
                    { 34, null, null, 34, 8, 7, null, null, "Steven Pressfield's 'The War of Art' identifies and confronts the internal obstacles that prevent creative people from achieving their potential. Pressfield personifies these barriers as 'Resistance,' a force that manifests as procrastination, self-doubt, and fear. The book provides strategies for recognizing and overcoming these creative blocks, emphasizing the importance of discipline, commitment, and professional approach to creative work. Pressfield's insights help readers understand that the struggle with resistance is universal and that the key to creative success lies in showing up and doing the work consistently.", "Uploads/Books/2a7a7859-0f63-4643-8c93-a8e9951fda2d_20250330_002241.png", null, null, true, false, false, 2002, "The War of Art", 12, null, null },
                    { 35, null, null, 35, 15, 1, null, null, "Paulo Coelho's 'The Alchemist' follows the journey of Santiago, a young Andalusian shepherd who dreams of finding a worldly treasure. His quest takes him from Spain to Egypt, where he encounters various characters who teach him about life, love, and the pursuit of one's Personal Legend. The novel explores themes of destiny, faith, and the interconnectedness of all things, blending elements of magical realism with philosophical insights. Coelho's allegorical tale encourages readers to follow their dreams while recognizing that the journey itself often holds greater value than the destination.", "Uploads/Books/ac5dceb7-753b-4064-9f6e-6cc45176ffb2_20250330_000713.jpeg", null, null, true, false, false, 1988, "The Alchemist", 20, null, null },
                    { 36, null, null, 36, 10, 1, null, null, "George Orwell's '1984' presents a chilling vision of a totalitarian future where Big Brother watches every move and thought crime is punishable by death. The novel follows Winston Smith, a low-ranking member of the ruling Party who begins to question the oppressive regime. Through Winston's journey, Orwell explores themes of surveillance, propaganda, and the manipulation of truth and language. The book serves as a powerful warning about the dangers of unchecked government power and the importance of preserving individual freedom and critical thinking.", "Uploads/Books/46ce4b1e-404e-4aac-8b35-856c527a26b4_20250329_234649.jpeg", null, null, true, false, false, 1949, "1984", 14, null, null },
                    { 37, null, null, 37, 8, 1, null, null, "Aldous Huxley's 'Brave New World' envisions a future society where happiness is achieved through genetic engineering, psychological conditioning, and the use of a drug called soma. The novel explores the conflict between individual freedom and social stability, questioning whether true happiness can exist without suffering and choice. Through the character of John the Savage, who represents natural human emotions and spirituality, Huxley examines the price of a perfectly ordered society and the value of authentic human experience.", "Uploads/Books/2f0c9609-566c-4fda-b9b9-cd9fead1e986_20250329_235216.jpeg", null, null, true, false, false, 1932, "Brave New World", 12, null, null },
                    { 38, null, null, 38, 9, 1, null, null, "Ray Bradbury's 'Fahrenheit 451' depicts a future society where books are banned and burned by firemen, and critical thinking is discouraged. The novel follows Guy Montag, a fireman who begins to question his role in destroying knowledge and literature. Through Montag's transformation, Bradbury explores themes of censorship, the importance of literature and free thought, and the role of technology in shaping society. The book serves as a powerful reminder of the value of books and the dangers of intellectual suppression.", "Uploads/Books/c77cc79e-9e1b-4d65-8c9d-4ba5a67c9c95_20250329_235349.jpeg", null, null, true, false, false, 1953, "Fahrenheit 451", 14, null, null },
                    { 39, null, null, 39, 12, 1, null, null, "J.D. Salinger's 'The Catcher in the Rye' follows Holden Caulfield, a disenchanted teenager who has been expelled from prep school and wanders New York City for three days. Through Holden's first-person narrative, the novel explores themes of alienation, loss of innocence, and the transition from childhood to adulthood. Holden's cynical yet vulnerable voice captures the confusion and disillusionment of adolescence, making the novel a powerful exploration of teenage angst and the search for authenticity in a world that seems phony.", "Uploads/Books/e5ba1036-fa70-4fb2-b647-b4897e63962f_20250330_000909.jpeg", null, null, true, false, false, 1951, "The Catcher in the Rye", 18, null, null },
                    { 40, null, null, 40, 10, 1, null, null, "Margaret Atwood's 'The Handmaid's Tale' is set in a dystopian future where a totalitarian regime has overthrown the United States government and established a theocratic society. The novel follows Offred, a Handmaid whose sole purpose is to bear children for the ruling class. Through Offred's perspective, Atwood explores themes of gender oppression, reproductive rights, and the manipulation of religious ideology for political control. The novel serves as a powerful commentary on women's rights and the dangers of fundamentalism.", "Uploads/Books/23782e39-0ede-4324-b69f-63f70e9785c4_20250330_001449.jpeg", null, null, true, false, false, 1985, "The Handmaid's Tale", 15, null, null },
                    { 41, null, null, 41, 7, 1, null, null, "Cormac McCarthy's 'The Road' follows a father and son as they journey through a post-apocalyptic America, struggling to survive in a world devastated by an unspecified catastrophe. The novel explores themes of love, hope, and the human will to survive in the face of overwhelming despair. Through the father's determination to protect his son and the boy's innocence and compassion, McCarthy examines what it means to remain human in an inhumane world. The novel is a powerful meditation on the bond between parent and child and the resilience of the human spirit.", "Uploads/Books/7d195219-1d98-477a-9b98-d30bae0b3464_20250330_002011.jpeg", null, null, true, false, false, 2006, "The Road", 10, null, null },
                    { 42, null, null, 42, 8, 1, null, null, "Kate Atkinson's 'Life After Life' follows Ursula Todd, who is born in 1910 and dies repeatedly, only to be reborn and live her life again with slight variations. Each iteration allows her to make different choices and experience different outcomes, exploring themes of fate, free will, and the impact of small decisions on the course of history. The novel examines how individual lives intersect with major historical events, particularly World War II, and questions whether we can truly change our destiny or if we are bound by predetermined paths.", "Uploads/Books/4b8da56f-7688-4d5b-b07e-d9853db96d1b_20250329_235845.jpeg", null, null, true, false, false, 2013, "Life After Life", 12, null, null },
                    { 43, null, null, 43, 9, 1, null, null, "Rick Yancey's 'The 5th Wave' is set in a world where Earth has been invaded by aliens who have systematically eliminated most of humanity through four waves of attacks. The novel follows Cassie Sullivan, a teenage girl trying to survive and find her younger brother. As she navigates a world where trust is impossible and survival requires constant vigilance, Cassie must determine who is truly human and who might be an alien in disguise. The novel explores themes of survival, trust, and the resilience of the human spirit in the face of overwhelming odds.", "Uploads/Books/52825395-52a2-4bea-9ee4-67a28f2c38b2_20250330_000508.jpeg", null, null, true, false, false, 2013, "The 5th Wave", 14, null, null },
                    { 44, null, null, 44, 12, 1, null, null, "Suzanne Collins' 'The Hunger Games' is set in a dystopian future where the totalitarian nation of Panem forces children to participate in a televised fight to the death. The novel follows Katniss Everdeen, who volunteers to take her sister's place in the Games. Through Katniss's journey, Collins explores themes of survival, sacrifice, and the effects of violence on young people. The novel also examines the role of media in shaping public opinion and the power of individual resistance against oppressive systems.", "Uploads/Books/c14ad657-c986-44c1-ae6b-2bacc1b2b577_20250330_001551.jpeg", null, null, true, false, false, 2008, "The Hunger Games", 18, null, null },
                    { 45, null, null, 45, 10, 1, null, null, "Veronica Roth's 'Divergent' is set in a dystopian society divided into factions based on virtues. The novel follows Beatrice Prior, who discovers she is Divergent—someone who doesn't fit into any single faction. As she navigates the dangerous initiation process for her chosen faction, Beatrice must hide her Divergence while uncovering a conspiracy that threatens the entire society. The novel explores themes of identity, choice, and the pressure to conform to societal expectations.", "Uploads/Books/eea4aa7e-c852-46ca-9320-c2413be5836a_20250329_235249.jpeg", null, null, true, false, false, 2011, "Divergent", 15, null, null },
                    { 46, null, null, 46, 8, 1, null, null, "Paula Hawkins' 'The Girl on the Train' follows Rachel Watson, an alcoholic woman who becomes obsessed with a seemingly perfect couple she observes from her daily train commute. When the woman goes missing, Rachel becomes involved in the investigation, but her unreliable memory and drinking problem make her an unreliable witness. The novel explores themes of memory, perception, and the unreliability of human observation, while examining the consequences of addiction and the search for redemption.", "Uploads/Books/75eaa5a8-101b-4649-b94a-cc975b6b71d3_20250330_001300.jpeg", null, null, true, false, false, 2015, "The Girl on the Train", 12, null, null },
                    { 47, null, null, 47, 9, 1, null, null, "Gillian Flynn's 'Gone Girl' tells the story of Nick and Amy Dunne, a married couple whose relationship has deteriorated. When Amy disappears on their fifth wedding anniversary, Nick becomes the prime suspect in her disappearance. The novel alternates between Nick's perspective and Amy's diary entries, creating a complex narrative that explores themes of marriage, media manipulation, and the construction of identity. Flynn examines how public perception can be shaped by media coverage and the ways in which people present different versions of themselves.", "Uploads/Books/37e1b6dd-3596-460b-a5ea-75ab35e76de2_20250329_235640.jpeg", null, null, true, false, false, 2012, "Gone Girl", 14, null, null },
                    { 48, null, null, 48, 7, 1, null, null, "Gillian Flynn's 'Sharp Objects' follows Camille Preaker, a journalist who returns to her hometown to investigate the murders of two young girls. As Camille delves into the case, she must confront her own troubled past and the dysfunctional relationship with her mother and half-sister. The novel explores themes of family dysfunction, self-harm, and the lasting effects of childhood trauma. Flynn examines how the past can continue to influence the present and the ways in which people cope with pain and trauma.", "Uploads/Books/93e160f6-53a0-43c6-b70e-b5bf34a40d1d_20250330_000313.jpeg", null, null, true, false, false, 2006, "Sharp Objects", 10, null, null },
                    { 49, null, null, 49, 12, 1, null, null, "Liane Moriarty's 'Big Little Lies' is set in a seemingly perfect coastal town where three women become friends while dealing with their own personal struggles. The novel explores themes of domestic violence, single parenthood, and the pressure to maintain appearances in a judgmental community. Through the perspectives of the three main characters, Moriarty examines the complexities of female friendships and the ways in which women support each other through difficult times. The novel also addresses the impact of social media and gossip on people's lives.", "Uploads/Books/472104fd-a07c-4b6d-833a-f1980ade7088_20250329_234953.jpeg", null, null, true, false, false, 2014, "Big Little Lies", 18, null, null },
                    { 50, null, null, 50, 10, 1, null, null, "Stieg Larsson's 'The Girl with the Dragon Tattoo' follows journalist Mikael Blomkvist and computer hacker Lisbeth Salander as they investigate a decades-old disappearance. The novel explores themes of corruption, violence against women, and the power of investigative journalism. Through the character of Lisbeth Salander, Larsson examines issues of social justice and the ways in which society often fails to protect vulnerable individuals. The novel also addresses themes of revenge, redemption, and the search for truth in a world where powerful people can hide their crimes.", "Uploads/Books/16ccf3cf-cda1-465f-9c2e-ddd95c7e86da_20250330_001343.jpeg", null, null, true, false, false, 2005, "The Girl with the Dragon Tattoo", 15, null, null },
                    { 51, null, null, 1, 6, 1, null, null, "F. Scott Fitzgerald's 'Tender Is the Night' follows the glamorous lives of Dick and Nicole Diver, an American couple living in the French Riviera during the 1920s. The novel explores themes of wealth, mental illness, and the disintegration of relationships against the backdrop of post-war Europe. Through the character of Dick Diver, a promising psychiatrist whose life unravels, Fitzgerald examines the destructive power of privilege and the fragility of human connections.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1934, "Tender Is the Night", 10, null, null },
                    { 52, null, null, 1, 5, 1, null, null, "F. Scott Fitzgerald's debut novel 'This Side of Paradise' follows Amory Blaine from his privileged childhood through his years at Princeton and into early adulthood. The novel captures the spirit of the Jazz Age and explores themes of love, ambition, and the search for identity. Through Amory's journey, Fitzgerald examines the disillusionment of a generation and the challenges of growing up in a rapidly changing world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1920, "This Side of Paradise", 8, null, null },
                    { 53, null, null, 2, 7, 1, null, null, "Harper Lee's 'Go Set a Watchman' follows an adult Scout Finch as she returns to Maycomb, Alabama, to visit her father Atticus. Set during the civil rights movement, the novel explores themes of racial tension, family relationships, and the complexity of moral choices. Through Scout's disillusionment with her father's views, Lee examines how individuals and communities grapple with social change and personal growth.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1430316106i/25388113.jpg", null, null, true, false, false, 2015, "Go Set a Watchman", 12, null, null },
                    { 54, null, null, 3, 8, 2, null, null, "Yuval Noah Harari's 'Homo Deus' explores the future of humanity, examining how technology and artificial intelligence might transform human society. The book discusses the potential for humans to become god-like through genetic engineering, artificial intelligence, and other technological advances. Harari challenges readers to consider what it means to be human in an age where we may transcend our biological limitations.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1468760805i/31138556.jpg", null, null, true, false, false, 2015, "Homo Deus: A Brief History of Tomorrow", 15, null, null },
                    { 55, null, null, 3, 10, 2, null, null, "Yuval Noah Harari's '21 Lessons for the 21st Century' addresses the most pressing issues facing humanity today, from technological disruption to political polarization. The book examines how artificial intelligence, climate change, and globalization are reshaping our world and challenges readers to think critically about the future. Harari provides insights into how individuals can navigate an increasingly complex and uncertain world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1532974590i/41057292.jpg", null, null, true, false, false, 2018, "21 Lessons for the 21st Century", 18, null, null },
                    { 56, null, null, 5, 9, 3, null, null, "Stephen Hawking's 'The Universe in a Nutshell' explores the latest developments in theoretical physics, from string theory to the nature of time. The book uses accessible language and illustrations to explain complex concepts like quantum mechanics and the multiverse theory. Hawking examines how our understanding of the universe has evolved and what mysteries remain to be solved.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2001, "The Universe in a Nutshell", 14, null, null },
                    { 57, null, null, 5, 7, 3, null, null, "Stephen Hawking and Leonard Mlodinow's 'The Grand Design' explores the fundamental questions about the universe and our place in it. The book discusses the latest theories in physics, including M-theory and the possibility of multiple universes. Through accessible explanations, the authors examine whether the universe needs a creator and how science might provide answers to the deepest questions about existence.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2010, "The Grand Design", 12, null, null },
                    { 58, null, null, 6, 8, 2, null, null, "Richard Dawkins' 'The Blind Watchmaker' explains how natural selection can create complex biological structures without the need for a designer. The book uses clear examples and analogies to demonstrate how evolution works and why it produces such remarkable adaptations. Dawkins argues that the complexity of life can be explained by the cumulative effects of natural selection acting over vast periods of time.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1986, "The Blind Watchmaker", 13, null, null },
                    { 59, null, null, 6, 12, 2, null, null, "Richard Dawkins' 'The God Delusion' presents a comprehensive argument against the existence of God and the value of religious belief. The book examines the evidence for and against religious claims, discusses the origins of religion, and explores the relationship between science and faith. Dawkins argues that atheism is a rational position and that religion can be harmful to society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2006, "The God Delusion", 20, null, null },
                    { 60, null, null, 7, 6, 4, null, null, "Steven Strogatz's 'Infinite Powers' tells the story of calculus and how it has shaped our understanding of the world. The book explores how calculus has been used to solve problems in physics, engineering, medicine, and other fields. Through engaging examples and historical anecdotes, Strogatz shows how calculus has revolutionized our ability to understand and manipulate the natural world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2019, "Infinite Powers", 10, null, null },
                    { 61, null, null, 7, 5, 4, null, null, "Steven Strogatz's 'Sync' explores the science of spontaneous order and how synchronization occurs in nature. The book examines how fireflies flash in unison, how the heart's cells beat together, and how other systems achieve coordination without central control. Strogatz explains the mathematical principles behind synchronization and its applications in various fields.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2003, "Sync", 8, null, null },
                    { 62, null, null, 14, 9, 1, null, null, "Jane Austen's 'Emma' follows the titular character as she attempts to matchmake for her friends while learning about love and self-awareness. The novel explores themes of social class, marriage, and personal growth through Emma's journey from a well-meaning but misguided young woman to someone who understands herself and others better. Austen's wit and social commentary make this a classic of English literature.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1815, "Emma", 14, null, null },
                    { 63, null, null, 14, 8, 1, null, null, "Jane Austen's 'Sense and Sensibility' follows the Dashwood sisters as they navigate love and marriage in early 19th-century England. The novel contrasts the practical Elinor with the romantic Marianne, exploring themes of love, family, and social expectations. Through the sisters' experiences, Austen examines the balance between reason and emotion in matters of the heart.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1811, "Sense and Sensibility", 12, null, null },
                    { 64, null, null, 14, 6, 1, null, null, "Jane Austen's 'Mansfield Park' follows Fanny Price, a poor relation who is raised by her wealthy aunt and uncle. The novel explores themes of morality, social class, and the role of women in society through Fanny's experiences. Austen examines the contrast between true virtue and social pretension, creating a complex portrait of early 19th-century English society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1814, "Mansfield Park", 10, null, null },
                    { 65, null, null, 16, 10, 8, null, null, "Plato's 'The Republic' presents a dialogue on justice, the ideal state, and the nature of the soul. Through Socratic questioning, the book explores the meaning of virtue, the structure of society, and the pursuit of truth. The work examines the relationship between individual morality and political justice, proposing that a just society requires just individuals.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, -380, "The Republic", 15, null, null },
                    { 66, null, null, 16, 7, 8, null, null, "Plato's 'The Symposium' presents a series of speeches about love given at a drinking party in ancient Athens. The dialogue explores different conceptions of love, from physical attraction to spiritual connection, culminating in Socrates' account of the ladder of love. The work examines the nature of desire, beauty, and the human quest for transcendence.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, -385, "The Symposium", 11, null, null },
                    { 67, null, null, 16, 8, 8, null, null, "Plato's 'The Apology' records Socrates' defense speech at his trial for impiety and corrupting the youth of Athens. The dialogue presents Socrates' commitment to philosophical inquiry and his willingness to die for his principles. The work examines the conflict between individual conscience and state authority, and the role of the philosopher in society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, -399, "The Apology", 12, null, null },
                    { 68, null, null, 18, 11, 9, null, null, "Charles Duhigg's 'The Power of Habit' uncovers the science behind why habits form and how they can be changed. Drawing on research and real-life stories, the book explains the habit loop and provides strategies for transforming routines. The work examines how habits shape individual behavior, organizational culture, and societal patterns.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2012, "The Power of Habit", 18, null, null },
                    { 69, null, null, 18, 9, 9, null, null, "Charles Duhigg's 'Smarter Faster Better' explores the science of productivity and how successful people and organizations achieve their goals. The book examines eight key concepts that drive productivity, from motivation and focus to decision-making and innovation. Through case studies and research, Duhigg provides insights into how to work more effectively and achieve better results.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2016, "Smarter Faster Better", 15, null, null },
                    { 70, null, null, 20, 7, 10, null, null, "Stephen R. Covey's 'The 8th Habit' builds on his previous work to address the challenges of the knowledge worker age. The book introduces the concept of finding your voice and helping others find theirs, emphasizing the importance of leadership and contribution. Covey examines how individuals can achieve personal and professional fulfillment in an increasingly complex world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2004, "The 8th Habit", 12, null, null },
                    { 71, null, null, 20, 8, 10, null, null, "Stephen R. Covey's 'First Things First' focuses on time management and prioritization based on principles rather than urgency. The book introduces the concept of the time management matrix and emphasizes the importance of aligning daily activities with long-term goals and values. Covey provides practical strategies for achieving balance and effectiveness in life.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1994, "First Things First", 13, null, null },
                    { 72, null, null, 21, 12, 11, null, null, "E.H. Gombrich's 'The Story of Art' provides a comprehensive introduction to art history from prehistoric times to the modern era. The book presents art as a continuous narrative of human creativity and expression, making complex artistic movements accessible to general readers. Gombrich's engaging writing style and clear explanations have made this a classic introduction to art history.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1950, "The Story of Art", 20, null, null },
                    { 73, null, null, 21, 6, 11, null, null, "E.H. Gombrich's 'Art and Illusion' examines the psychology of pictorial representation and how artists create the illusion of reality. The book explores the relationship between perception and artistic representation, drawing on psychology, philosophy, and art history. Gombrich examines how different cultures and periods have approached the challenge of representing the visual world.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1960, "Art and Illusion", 10, null, null },
                    { 74, null, null, 22, 9, 11, null, null, "John Berger's 'Ways of Seeing' challenges conventional approaches to art appreciation and visual culture. Through a series of essays, Berger examines how we perceive and interpret images, questioning the assumptions behind traditional art criticism. The book explores themes of gender, class, and power in visual representation, offering new tools for analyzing visual culture.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1972, "Ways of Seeing", 15, null, null },
                    { 75, null, null, 22, 5, 11, null, null, "John Berger's 'About Looking' is a collection of essays that examine how we see and interpret the world around us. The book explores various aspects of visual culture, from photography and painting to advertising and everyday objects. Berger's insightful analysis helps readers develop a more critical and aware approach to visual information.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1980, "About Looking", 8, null, null },
                    { 76, null, null, 23, 8, 12, null, null, "Alex Ross's 'The Rest Is Noise' offers a sweeping history of 20th-century classical music, exploring how composers responded to the tumultuous events of their time. The book examines how music reflected and influenced social change, from the avant-garde experiments of Stravinsky to the minimalist movements of the late century. Ross's engaging narrative makes complex musical concepts accessible.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2007, "The Rest Is Noise", 13, null, null },
                    { 77, null, null, 23, 6, 12, null, null, "Alex Ross's 'Listen to This' explores the connections between classical music and contemporary culture. The book examines how classical music continues to influence modern composers and performers, and how it intersects with popular music and other art forms. Ross provides insights into the enduring power and relevance of classical music in the 21st century.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2010, "Listen to This", 10, null, null },
                    { 78, null, null, 24, 10, 12, null, null, "David Byrne's 'How Music Works' is a fascinating exploration of music from multiple perspectives: as a cultural phenomenon, a technological medium, and a fundamental human expression. The book covers topics ranging from the physics of sound to the economics of the music industry, from ancient musical traditions to digital innovations. Byrne's insights offer readers a deeper understanding of how music shapes our lives.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2012, "How Music Works", 16, null, null },
                    { 79, null, null, 24, 5, 15, null, null, "David Byrne's 'Bicycle Diaries' chronicles his experiences cycling through various cities around the world. The book explores urban planning, culture, and the relationship between people and their environments. Through Byrne's observations and reflections, readers gain insights into how cities shape human experience and how cycling can provide a unique perspective on urban life.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2009, "Bicycle Diaries", 8, null, null },
                    { 80, null, null, 25, 15, 9, null, null, "Bessel van der Kolk's 'The Body Keeps the Score' revolutionizes our understanding of trauma and its profound effects on the brain, mind, and body. The book explores innovative treatment approaches, from traditional therapy to body-based interventions like yoga and neurofeedback. Van der Kolk's compassionate perspective offers hope for healing while providing essential insights for anyone affected by trauma.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2014, "The Body Keeps the Score", 25, null, null },
                    { 81, null, null, 25, 8, 9, null, null, "Bessel van der Kolk's 'Traumatic Stress' provides a comprehensive overview of the field of trauma studies and treatment. The book examines the neurobiological effects of trauma, the development of PTSD, and various therapeutic approaches. Van der Kolk's extensive clinical experience and research provide a solid foundation for understanding and treating trauma-related disorders.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1996, "Traumatic Stress", 12, null, null },
                    { 82, null, null, 26, 12, 13, null, null, "Christopher McDougall's 'Born to Run' combines adventure, science, and human potential in a compelling narrative about the art and science of running. The book follows McDougall's journey to discover the secrets of the Tarahumara, a remote Mexican tribe known for their extraordinary long-distance running abilities. Through their story, McDougall explores evolutionary biology, biomechanics, and the psychology of endurance.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2009, "Born to Run", 20, null, null },
                    { 83, null, null, 26, 7, 13, null, null, "Christopher McDougall's 'Natural Born Heroes' explores the science of heroism and how ordinary people can achieve extraordinary feats. The book examines the physical and mental techniques used by heroes throughout history, from ancient Greek warriors to modern athletes. McDougall investigates how nutrition, movement, and mindset can unlock human potential.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2015, "Natural Born Heroes", 12, null, null },
                    { 84, null, null, 27, 15, 14, null, null, "Irma S. Rombauer's 'The Joy of Cooking' has become an American culinary institution, serving as the definitive cookbook for generations of home cooks. First published during the Great Depression, the book has evolved through multiple editions while maintaining its practical approach to cooking. Rombauer's warm, encouraging voice and comprehensive coverage of techniques make complex recipes accessible to beginners.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1931, "The Joy of Cooking", 25, null, null },
                    { 85, null, null, 28, 10, 14, null, null, "Samin Nosrat's 'Salt, Fat, Acid, Heat' revolutionizes how we think about cooking by focusing on the four fundamental elements that make food delicious. Rather than memorizing recipes, Nosrat teaches readers to understand the principles behind great cooking, empowering them to create flavorful dishes with confidence. The book combines scientific explanations with practical techniques and beautiful illustrations.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2017, "Salt, Fat, Acid, Heat", 18, null, null },
                    { 86, null, null, 29, 12, 14, null, null, "Anthony Bourdain's 'Kitchen Confidential' pulls back the curtain on the culinary world, revealing the intense, chaotic, and often brutal reality behind restaurant kitchens. Bourdain's candid and sometimes controversial memoir exposes the passion, pressure, and personalities that drive the food industry. Through vivid storytelling and sharp wit, he shares the lessons learned from his years in professional kitchens.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2000, "Kitchen Confidential", 20, null, null },
                    { 87, null, null, 29, 8, 14, null, null, "Anthony Bourdain's 'Medium Raw' is a follow-up to 'Kitchen Confidential' that explores how the food world has changed and how Bourdain's own perspective has evolved. The book examines celebrity chefs, food television, and the changing landscape of the restaurant industry. Bourdain's sharp observations and honest reflections provide insights into the evolution of food culture.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2010, "Medium Raw", 13, null, null },
                    { 88, null, null, 30, 14, 14, null, null, "Michael Pollan's 'The Omnivore's Dilemma' investigates the complex web of choices involved in what we eat, tracing the journey of food from farm to table. Through four different meals, Pollan explores industrial agriculture, organic farming, hunting and gathering, and sustainable food systems. The book examines the environmental, ethical, and health implications of our food choices.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2006, "The Omnivore's Dilemma", 22, null, null },
                    { 89, null, null, 30, 11, 14, null, null, "Michael Pollan's 'In Defense of Food' examines the modern food industry and its impact on human health. The book explores how processed foods and industrial agriculture have changed our diets and health outcomes. Pollan provides practical advice for making healthier food choices and argues for a return to traditional, whole-food diets.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2008, "In Defense of Food", 18, null, null },
                    { 90, null, null, 30, 7, 2, null, null, "Michael Pollan's 'The Botany of Desire' explores the complex relationship between humans and plants, examining how plants have evolved to satisfy human desires for sweetness, beauty, intoxication, and control. The book tells the stories of four plants—apples, tulips, marijuana, and potatoes—and how they have shaped human history and culture.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 2001, "The Botany of Desire", 12, null, null },
                    { 91, null, null, 31, 9, 21, null, null, "Stephen King's debut novel 'Carrie' tells the story of a teenage girl with telekinetic powers who is bullied by her classmates and abused by her religious fanatic mother. The novel explores themes of isolation, revenge, and the destructive power of religious extremism. King's portrayal of high school cruelty and supernatural horror established him as a master of the genre.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1974, "Carrie", 15, null, null },
                    { 92, null, null, 31, 11, 21, null, null, "Stephen King's 'The Shining' follows the Torrance family as they spend the winter as caretakers of the isolated Overlook Hotel. The novel explores themes of isolation, alcoholism, and the supernatural as the hotel's malevolent forces begin to affect the family. King's masterful building of tension and psychological horror makes this one of his most acclaimed works.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1977, "The Shining", 18, null, null },
                    { 93, null, null, 31, 13, 21, null, null, "Stephen King's 'It' follows a group of children who band together to fight an ancient evil that takes the form of a clown and feeds on their fears. The novel alternates between their childhood experiences and their return as adults to face the evil again. King explores themes of friendship, courage, and the power of belief in this epic horror novel.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1986, "It", 20, null, null },
                    { 94, null, null, 31, 10, 18, null, null, "Stephen King's 'The Stand' is an epic post-apocalyptic novel about a deadly virus that wipes out most of humanity, leaving survivors to choose between good and evil. The novel explores themes of morality, community, and the struggle between light and darkness. King's detailed character development and complex plot make this one of his most ambitious works.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1978, "The Stand", 16, null, null },
                    { 95, null, null, 32, 15, 16, null, null, "Maurice Sendak's 'Where the Wild Things Are' follows young Max as he sails to an island inhabited by wild creatures who make him their king. The picture book explores themes of imagination, anger, and the comfort of home. Sendak's innovative illustrations and simple but profound story have made this a beloved classic of children's literature.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1963, "Where the Wild Things Are", 25, null, null },
                    { 96, null, null, 33, 18, 17, null, null, "J.R.R. Tolkien's 'The Hobbit' follows Bilbo Baggins, a hobbit who joins a group of dwarves on a quest to reclaim their homeland from a dragon. The novel explores themes of courage, friendship, and the journey of self-discovery. Tolkien's rich world-building and engaging storytelling established the foundation for his later masterpiece, 'The Lord of the Rings.'", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1937, "The Hobbit", 30, null, null },
                    { 97, null, null, 33, 20, 17, null, null, "J.R.R. Tolkien's 'The Lord of the Rings' is an epic fantasy trilogy that follows the quest to destroy a powerful ring and defeat the dark lord Sauron. The novel explores themes of friendship, sacrifice, and the struggle between good and evil. Tolkien's detailed world-building, complex characters, and profound themes have made this one of the most influential works of fantasy literature.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1954, "The Lord of the Rings", 35, null, null },
                    { 98, null, null, 33, 8, 17, null, null, "J.R.R. Tolkien's 'The Silmarillion' is a collection of mythopoeic stories that form the background to 'The Lord of the Rings.' The book includes the creation myth of Middle-earth, the history of the elves, and the tales of the Silmarils. Tolkien's complex mythology and beautiful prose create a rich foundation for understanding the world of Middle-earth.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1977, "The Silmarillion", 15, null, null },
                    { 99, null, null, 35, 16, 18, null, null, "Frank Herbert's 'Dune' is set on the desert planet Arrakis and follows Paul Atreides as he becomes involved in a complex political and religious struggle. The novel explores themes of ecology, politics, religion, and human evolution. Herbert's detailed world-building and complex plot have made this one of the most influential works of science fiction.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1965, "Dune", 25, null, null },
                    { 100, null, null, 35, 12, 18, null, null, "Frank Herbert's 'Dune Messiah' continues the story of Paul Atreides as he struggles with the consequences of his rise to power and the religious movement that has grown around him. The novel explores themes of leadership, prophecy, and the unintended consequences of political and religious power. Herbert examines the complexities of messianic figures and their impact on society.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327942880i/46164.jpg", null, null, true, false, false, 1969, "Dune Messiah", 20, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_BookId",
                table: "Feedback",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BookId",
                table: "Transaction",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_IssuedByUserId",
                table: "Transaction",
                column: "IssuedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReturnedByUserId",
                table: "Transaction",
                column: "ReturnedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
