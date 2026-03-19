using LMS.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsTrending = table.Column<bool>(type: "bit", nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BorrowDays = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastOverdueNotified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrendingBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendingBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrendingBooks_Book_BookId",
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
                    { 1, null, null, 1, 10, 1, null, null, "A novel about the American dream and the Jazz Age.", "Uploads/Books/240a09b8-7452-4cda-99e4-48627bfc2ba6_20250330_001414.jpeg", null, null, true, false, false, 1925, "The Great Gatsby", 15, null, null },
                    { 2, null, null, 2, 8, 1, null, null, "A novel about racial injustice in the Deep South.", "Uploads/Books/bbc43e3c-beff-4517-a107-e3ad3b7c3fbb_20250330_002428.png", null, null, true, false, false, 1960, "To Kill a Mockingbird", 12, null, null },
                    { 3, null, null, 3, 12, 2, null, null, "A sweeping history of humanity from ancient times to the present.", "Uploads/Books/ec03a3c1-b718-407b-9465-f8e867353021_20250330_000242.jpeg", null, null, true, false, false, 2011, "Sapiens: A Brief History of Humankind", 20, null, null },
                    { 4, null, null, 4, 5, 3, null, null, "A memoir about a woman who grows up in a survivalist family and eventually escapes for an education.", "Uploads/Books/0ff5c317-7915-4ee3-954f-4ebd7608d428_20250329_235320.jpeg", null, null, true, false, false, 2018, "Educated", 7, null, null },
                    { 5, null, null, 5, 15, 4, null, null, "A landmark book by physicist Stephen Hawking about the origins and nature of the universe.", "Uploads/Books/2f7ebca3-e6c4-4c0b-aeac-ff396a023c49_20250329_234906.jpeg", null, null, true, false, false, 1988, "A Brief History of Time", 25, null, null },
                    { 6, null, null, 6, 8, 2, null, null, "A seminal work on evolutionary biology, focusing on the gene-centered view of evolution.", "Uploads/Books/1ecaf167-5c32-4f68-8c43-57b97dec2a3e_20250330_002042.jpeg", null, null, true, false, false, 1976, "The Selfish Gene", 12, null, null },
                    { 7, null, null, 7, 6, 4, null, null, "A book about the beauty and wonder of mathematics and its applications.", "Uploads/Books/eaeefb94-29ae-486b-baba-078d7ca17429_20250330_001647.jpeg", null, null, true, false, false, 2014, "The Joy of x", 9, null, null },
                    { 8, null, null, 8, 7, 5, null, null, "A novella exploring the nature of dimensions and our perception of reality.", "Uploads/Books/e8b354e3-7ce0-4824-a92d-6cd434ef30cb_20250329_235623.jpeg", null, null, true, false, false, 1884, "Flatland: A Romance of Many Dimensions", 10, null, null },
                    { 9, null, null, 9, 5, 6, null, null, "The diary of Anne Frank, chronicling her life in hiding during the Holocaust.", "Uploads/Books/169f079a-cfff-4d87-8f84-5a873a895504_20250330_001103.jpeg", null, null, true, false, false, 1947, "The Diary of a Young Girl", 8, null, null },
                    { 10, null, null, 10, 12, 2, null, null, "A history of the world from the perspective of the Silk Roads trade routes.", "Uploads/Books/c508f639-13fb-425e-8e56-508c3fc2ba6b_20250330_002117.jpeg", null, null, true, false, false, 2015, "The Silk Roads", 18, null, null },
                    { 11, null, null, 11, 10, 7, null, null, "A biography of the Apple co-founder, written by Walter Isaacson.", "Uploads/Books/b5d07a17-b507-4aca-ae02-67407a95e307_20250330_000437.jpeg", null, null, true, false, false, 2011, "Steve Jobs", 15, null, null },
                    { 12, null, null, 12, 8, 6, null, null, "The life story of the influential civil rights leader, as told to journalist Alex Haley.", "Uploads/Books/5fd61fc7-4a57-4cec-bc1e-153df1b8d08b_20250330_000750.jpeg", null, null, true, false, false, 1965, "The Autobiography of Malcolm X", 12, null, null },
                    { 13, null, null, 13, 6, 1, null, null, "Herman Melville's classic novel about the obsessive quest to capture the white whale.", "Uploads/Books/7186fad6-481e-4b35-8730-bb5b38fe44d0_20250330_000006.jpeg", null, null, true, false, false, 1851, "Moby-Dick", 10, null, null },
                    { 14, null, null, 14, 10, 1, null, null, "Jane Austen's timeless romantic novel set in the British Regency era.", "Uploads/Books/5b2c0142-74e5-4317-a9fb-dacaa00f2610_20250330_000111.jpeg", null, null, true, false, false, 1813, "Pride and Prejudice", 14, null, null },
                    { 15, null, null, 15, 7, 4, null, null, "The personal writings of the Roman Emperor Marcus Aurelius on Stoic philosophy.", null, null, null, true, false, false, 180, "Meditations", 10, null, null },
                    { 16, null, null, 16, 8, 5, null, null, "Plato's philosophical dialogue about justice, the ideal state, and the nature of the human soul.", null, null, null, true, false, false, -380, "The Republic", 11, null, null },
                    { 17, null, null, 17, 10, 3, null, null, "A groundbreaking book on human decision-making and cognitive biases by Nobel laureate Daniel Kahneman.", "Uploads/Books/ddfb6c14-a1f1-4685-a835-16afd6354aac_20250330_002323.jpeg", null, null, true, false, false, 2011, "Thinking, Fast and Slow", 15, null, null },
                    { 18, null, null, 18, 9, 3, null, null, "A book exploring the science of habit formation and how it impacts our daily lives.", "Uploads/Books/c70e070d-1a1f-499c-9b66-9373873efd4d_20250330_001755.png", null, null, true, false, false, 2012, "The Power of Habit", 14, null, null },
                    { 19, null, null, 19, 10, 3, null, null, "James Clear's guide to breaking bad habits and building good ones through small, consistent changes.", "Uploads/Books/cdb6b6a0-dfc6-4f79-b81f-d53cbd47f797_20250329_234920.jpeg", null, null, true, false, false, 2018, "Atomic Habits", 15, null, null },
                    { 20, null, null, 20, 14, 3, null, null, "Stephen R. Covey's classic book on personal and professional effectiveness.", "Uploads/Books/2d209324-e47a-4a72-b249-c27a8fd9b447_20250330_000600.jpeg", null, null, true, false, false, 1989, "The 7 Habits of Highly Effective People", 20, null, null },
                    { 21, null, null, 21, 8, 5, null, null, "An accessible introduction to the history of art by renowned art historian E.H. Gombrich.", "Uploads/Books/f0e19d8b-bc7a-4630-9f96-0cb3b943bcab_20250330_002206.jpeg", null, null, true, false, false, 1950, "The Story of Art", 12, null, null },
                    { 22, null, null, 22, 6, 5, null, null, "A groundbreaking book on visual culture and how we perceive art, written by John Berger.", "Uploads/Books/b1f5b2da-1307-47ba-8ea1-fdbe780bd088_20250330_002539.jpeg", null, null, true, false, false, 1972, "Ways of Seeing", 9, null, null },
                    { 23, null, null, 23, 7, 4, null, null, "A history of 20th-century classical music by music critic Alex Ross.", "Uploads/Books/7147db03-a13b-4773-bfd3-d80fe01c4743_20250330_001923.png", null, null, true, false, false, 2007, "The Rest Is Noise", 10, null, null },
                    { 24, null, null, 24, 8, 4, null, null, "David Byrne’s exploration of music, its history, and its cultural impact.", "Uploads/Books/00e82a7d-5452-4a08-b4a0-a75eb692656c_20250329_235723.png", null, null, true, false, false, 2012, "How Music Works", 12, null, null },
                    { 25, null, null, 25, 10, 3, null, null, "Bessel van der Kolk’s exploration of trauma and its effect on the brain and body.", "Uploads/Books/d7f01374-6dff-4ea2-8d22-afd607cbdc11_20250330_000838.jpeg", null, null, true, false, false, 2014, "The Body Keeps the Score", 15, null, null },
                    { 26, null, null, 26, 6, 2, null, null, "A book about the science of running and the story of a remote tribe of ultra-runners.", "Uploads/Books/f845f829-8491-4d04-8358-0d9064c7ec90_20250329_235131.jpeg", null, null, true, false, false, 2009, "Born to Run", 10, null, null },
                    { 27, null, null, 27, 7, 8, null, null, "Irma S. Rombauer’s classic cookbook that has become an American institution.", "Uploads/Books/c3902039-c0cb-4827-93c2-e523bfbca2e8_20250330_001629.png", null, null, true, false, false, 1931, "The Joy of Cooking", 11, null, null },
                    { 28, null, null, 28, 6, 14, null, null, "A guide to understanding the fundamental elements of cooking by Samin Nosrat.", "Uploads/Books/34a1babd-4c98-4060-83e1-4a5ba9710042_20250330_000128.jpeg", null, null, true, false, false, 2017, "Salt, Fat, Acid, Heat", 8, null, null },
                    { 29, null, null, 29, 8, 8, null, null, "Anthony Bourdain’s behind-the-scenes look at the culinary world.", "Uploads/Books/a26c1840-336e-4111-a9b6-1992fda7e5ca_20250329_235800.jpeg", null, null, true, false, false, 2000, "Kitchen Confidential", 12, null, null },
                    { 30, null, null, 30, 10, 8, null, null, "Michael Pollan’s exploration of where our food comes from and its environmental impact.", "Uploads/Books/3f907f78-cd85-443b-82a3-d2663bbf74cd_20250330_001723.jpeg", null, null, true, false, false, 2006, "The Omnivore's Dilemma", 15, null, null },
                    { 31, null, null, 31, 7, 7, null, null, "Stephen King's memoir and guide to writing.", "Uploads/Books/317c1742-37a7-439c-9b23-00d0a708f7c8_20250330_000039.jpeg", null, null, true, false, false, 2000, "On Writing", 10, null, null },
                    { 32, null, null, 32, 6, 7, null, null, "Anne Lamott's insightful and humorous take on writing and life.", "Uploads/Books/2b87c9ee-4b19-40aa-ba32-8e45a76d4a88_20250329_235032.jpeg", null, null, true, false, false, 1994, "Bird by Bird", 9, null, null },
                    { 33, null, null, 33, 12, 7, null, null, "A concise guide to the principles of good writing, by William Strunk Jr. and E.B. White.", "Uploads/Books/3d3e4b70-925b-42e4-98ef-42a94c5ae486_20250330_001224.jpeg", null, null, true, false, false, 1959, "The Elements of Style", 18, null, null },
                    { 34, null, null, 34, 8, 7, null, null, "Steven Pressfield’s book on overcoming resistance to creative work.", "Uploads/Books/2a7a7859-0f63-4643-8c93-a8e9951fda2d_20250330_002241.png", null, null, true, false, false, 2002, "The War of Art", 12, null, null },
                    { 35, null, null, 35, 15, 1, null, null, "Paulo Coelho's philosophical novel about pursuing your dreams and finding your destiny.", "Uploads/Books/ac5dceb7-753b-4064-9f6e-6cc45176ffb2_20250330_000713.jpeg", null, null, true, false, false, 1988, "The Alchemist", 20, null, null },
                    { 36, null, null, 36, 10, 1, null, null, "George Orwell's dystopian novel about totalitarianism, surveillance, and the power of propaganda.", "Uploads/Books/46ce4b1e-404e-4aac-8b35-856c527a26b4_20250329_234649.jpeg", null, null, true, false, false, 1949, "1984", 14, null, null },
                    { 37, null, null, 37, 8, 1, null, null, "Aldous Huxley's novel exploring a future society controlled by technology and conformity.", "Uploads/Books/2f0c9609-566c-4fda-b9b9-cd9fead1e986_20250329_235216.jpeg", null, null, true, false, false, 1932, "Brave New World", 12, null, null },
                    { 38, null, null, 38, 9, 1, null, null, "Ray Bradbury's classic novel about a dystopian society where books are banned.", "Uploads/Books/c77cc79e-9e1b-4d65-8c9d-4ba5a67c9c95_20250329_235349.jpeg", null, null, true, false, false, 1953, "Fahrenheit 451", 14, null, null },
                    { 39, null, null, 39, 12, 1, null, null, "J.D. Salinger's novel about teenage rebellion and disillusionment.", "Uploads/Books/e5ba1036-fa70-4fb2-b647-b4897e63962f_20250330_000909.jpeg", null, null, true, false, false, 1951, "The Catcher in the Rye", 18, null, null },
                    { 40, null, null, 40, 10, 1, null, null, "Margaret Atwood’s dystopian novel about gender oppression and the loss of personal freedom.", "Uploads/Books/23782e39-0ede-4324-b69f-63f70e9785c4_20250330_001449.jpeg", null, null, true, false, false, 1985, "The Handmaid's Tale", 15, null, null },
                    { 41, null, null, 41, 7, 1, null, null, "Cormac McCarthy's post-apocalyptic novel about a father and son struggling to survive.", "Uploads/Books/7d195219-1d98-477a-9b98-d30bae0b3464_20250330_002011.jpeg", null, null, true, false, false, 2006, "The Road", 10, null, null },
                    { 42, null, null, 42, 8, 1, null, null, "Kate Atkinson's novel about a woman who lives multiple lives in different timelines.", "Uploads/Books/4b8da56f-7688-4d5b-b07e-d9853db96d1b_20250329_235845.jpeg", null, null, true, false, false, 2013, "Life After Life", 12, null, null },
                    { 43, null, null, 43, 9, 1, null, null, "Rick Yancey's thrilling novel about an alien invasion and the fight for survival.", "Uploads/Books/52825395-52a2-4bea-9ee4-67a28f2c38b2_20250330_000508.jpeg", null, null, true, false, false, 2013, "The 5th Wave", 14, null, null },
                    { 44, null, null, 44, 12, 1, null, null, "Suzanne Collins' dystopian novel about a televised fight to the death.", "Uploads/Books/c14ad657-c986-44c1-ae6b-2bacc1b2b577_20250330_001551.jpeg", null, null, true, false, false, 2008, "The Hunger Games", 18, null, null },
                    { 45, null, null, 45, 10, 1, null, null, "Veronica Roth's novel set in a dystopian society divided into factions based on virtues.", "Uploads/Books/eea4aa7e-c852-46ca-9320-c2413be5836a_20250329_235249.jpeg", null, null, true, false, false, 2011, "Divergent", 15, null, null },
                    { 46, null, null, 46, 8, 1, null, null, "Paula Hawkins' psychological thriller about a woman who gets involved in a missing person's case.", "Uploads/Books/75eaa5a8-101b-4649-b94a-cc975b6b71d3_20250330_001300.jpeg", null, null, true, false, false, 2015, "The Girl on the Train", 12, null, null },
                    { 47, null, null, 47, 9, 1, null, null, "Gillian Flynn's mystery novel about a marriage gone wrong and the disappearance of a wife.", "Uploads/Books/37e1b6dd-3596-460b-a5ea-75ab35e76de2_20250329_235640.jpeg", null, null, true, false, false, 2012, "Gone Girl", 14, null, null },
                    { 48, null, null, 48, 7, 1, null, null, "Gillian Flynn’s psychological thriller about a journalist returning to her hometown to investigate a series of murders.", "Uploads/Books/93e160f6-53a0-43c6-b70e-b5bf34a40d1d_20250330_000313.jpeg", null, null, true, false, false, 2006, "Sharp Objects", 10, null, null },
                    { 49, null, null, 49, 12, 1, null, null, "Liane Moriarty's novel about the secrets and lies in a tight-knit community.", "Uploads/Books/472104fd-a07c-4b6d-833a-f1980ade7088_20250329_234953.jpeg", null, null, true, false, false, 2014, "Big Little Lies", 18, null, null },
                    { 50, null, null, 50, 10, 1, null, null, "Stieg Larsson's crime thriller about a journalist and a hacker uncovering corruption in Sweden.", "Uploads/Books/16ccf3cf-cda1-465f-9c2e-ddd95c7e86da_20250330_001343.jpeg", null, null, true, false, false, 2005, "The Girl with the Dragon Tattoo", 15, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrendingBooks_BookId",
                table: "TrendingBooks",
                column: "BookId");
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
                name: "TrendingBooks");

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
