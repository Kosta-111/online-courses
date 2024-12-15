using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "AspNetRoles",
            columns: table => new
            {
                Id = table.Column<string>(type: "text", nullable: false),
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
                Id = table.Column<string>(type: "text", nullable: false),
                BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                FirstName = table.Column<string>(type: "text", nullable: true),
                LastName = table.Column<string>(type: "text", nullable: true),
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
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Levels",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Levels", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Students",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Phone = table.Column<string>(type: "text", nullable: true),
                Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Balance = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                BirthDate = table.Column<DateOnly>(type: "date", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Students", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "AspNetRoleClaims",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                RoleId = table.Column<string>(type: "text", nullable: false),
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
                UserId = table.Column<string>(type: "text", nullable: false),
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
                LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                UserId = table.Column<string>(type: "text", nullable: false)
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
                UserId = table.Column<string>(type: "text", nullable: false),
                RoleId = table.Column<string>(type: "text", nullable: false)
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
                UserId = table.Column<string>(type: "text", nullable: false),
                LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
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
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UserId = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
                table.ForeignKey(
                    name: "FK_Orders_AspNetUsers_UserId",
                    column: x => x.UserId,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Courses",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                ImageUrl = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                Language = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Price = table.Column<decimal>(type: "numeric", nullable: false),
                Discount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                Rating = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                IsCertificate = table.Column<bool>(type: "boolean", nullable: false),
                LevelId = table.Column<int>(type: "integer", nullable: false),
                CategoryId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Courses", x => x.Id);
                table.ForeignKey(
                    name: "FK_Courses_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Courses_Levels_LevelId",
                    column: x => x.LevelId,
                    principalTable: "Levels",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "CourseOrder",
            columns: table => new
            {
                CoursesId = table.Column<int>(type: "integer", nullable: false),
                OrdersId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CourseOrder", x => new { x.CoursesId, x.OrdersId });
                table.ForeignKey(
                    name: "FK_CourseOrder_Courses_CoursesId",
                    column: x => x.CoursesId,
                    principalTable: "Courses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CourseOrder_Orders_OrdersId",
                    column: x => x.OrdersId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "CourseStudent",
            columns: table => new
            {
                CoursesId = table.Column<int>(type: "integer", nullable: false),
                StudentsId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                table.ForeignKey(
                    name: "FK_CourseStudent_Courses_CoursesId",
                    column: x => x.CoursesId,
                    principalTable: "Courses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CourseStudent_Students_StudentsId",
                    column: x => x.StudentsId,
                    principalTable: "Students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Lectures",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Number = table.Column<int>(type: "integer", nullable: false),
                Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                ImageUrl = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                CourseId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Lectures", x => x.Id);
                table.ForeignKey(
                    name: "FK_Lectures_Courses_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Courses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Materials",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                Duration = table.Column<int>(type: "integer", nullable: true),
                LectureId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Materials", x => x.Id);
                table.ForeignKey(
                    name: "FK_Materials_Lectures_LectureId",
                    column: x => x.LectureId,
                    principalTable: "Lectures",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Categories",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "Design" },
                { 2, "Programming" },
                { 3, "Networks" },
                { 4, "Project management" },
                { 5, "Database analyst" }
            });

        migrationBuilder.InsertData(
            table: "Levels",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "Beginner" },
                { 2, "Middle" },
                { 3, "Strong middle" },
                { 4, "High" },
                { 5, "Super PRO" }
            });

        migrationBuilder.InsertData(
            table: "Students",
            columns: new[] { "Id", "Balance", "BirthDate", "Country", "Email", "FirstName", "LastName", "Phone" },
            values: new object[] { 1, 10m, new DateOnly(1990, 12, 1), "Ukraine", "ivanenko@gmail.com", "Ivan", "Ivanenko", "+380965800214" });

        migrationBuilder.InsertData(
            table: "Students",
            columns: new[] { "Id", "BirthDate", "Country", "Email", "FirstName", "LastName", "Phone" },
            values: new object[] { 2, new DateOnly(2000, 11, 2), "Ukraine", "petro.petrenko@gmail.com", "Petro", "Petrenko", "+380971234567" });

        migrationBuilder.InsertData(
            table: "Students",
            columns: new[] { "Id", "Balance", "BirthDate", "Country", "Email", "FirstName", "LastName", "Phone" },
            values: new object[,]
            {
                { 3, 100m, new DateOnly(2001, 5, 8), "Ukraine", "novak@gmail.com", "Oleg", "Mamchur", "+380936547821" },
                { 4, 1000m, new DateOnly(2005, 1, 10), "Ukraine", "bondar@gmail.com", "Olexandr", "Bondar", "+380671200077" },
                { 5, 5m, new DateOnly(1999, 7, 9), "Ukraine", "sheva@gmail.com", "Taras", "Shevshenko", "+380509811199" }
            });

        migrationBuilder.InsertData(
            table: "Courses",
            columns: new[] { "Id", "CategoryId", "Description", "Discount", "ImageUrl", "IsCertificate", "Language", "LevelId", "Name", "Price", "Rating" },
            values: new object[,]
            {
                { 1, 2, "Super course about Python, realy!", 10, "https://loudbench.com/wp-content/uploads/2023/02/Python-logo-696x392.png", true, "English", 2, "Python", 100m, 3.5 },
                { 2, 2, "Super course about C++, realy!", 5, "https://www.vikingsoftware.com/wp-content/uploads/2024/02/C-2.png", true, "English", 3, "C++", 150m, 4.5 },
                { 3, 5, "Super course about Data bases, realy!", 15, "https://miro.medium.com/v2/resize:fit:640/format:webp/1*1fc2dDk1RywRv6nDw_EE_A.png", true, "English", 4, "Data bases", 450m, 3.0 },
                { 4, 3, "Super course about Networks security, realy!", 10, "https://purplesec.us/wp-content/uploads/2020/11/what-is-network-security-300x239.png", true, "English", 5, "Networks security", 300m, 4.2000000000000002 }
            });

        migrationBuilder.InsertData(
            table: "Courses",
            columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsCertificate", "Language", "LevelId", "Name", "Price", "Rating" },
            values: new object[] { 5, 1, "Super course about Photoshop, realy!", "https://logos-world.net/wp-content/uploads/2020/11/Adobe-Photoshop-Logo.png", false, "English", 1, "Photoshop for housewifes", 100m, 4.7999999999999998 });

        migrationBuilder.InsertData(
            table: "Lectures",
            columns: new[] { "Id", "CourseId", "Description", "ImageUrl", "Name", "Number" },
            values: new object[,]
            {
                { 1, 2, "Very interesting Intro lecture...", null, "Intro", 1 },
                { 2, 2, "Very interesting lecture about Data types and variables", null, "Data types and variables", 2 },
                { 3, 2, "Very interesting lecture about Algorithms", null, "Algorithms", 3 },
                { 4, 2, "Very interesting lecture about Functions...", null, "Functions", 4 },
                { 5, 2, "Very interesting lecture about Arrays...", null, "Arrays", 5 }
            });

        migrationBuilder.InsertData(
            table: "Materials",
            columns: new[] { "Id", "Duration", "LectureId", "Name", "Url" },
            values: new object[,]
            {
                { 1, 95, 1, "Lesson 1. Intro to C++", "./video/C/1.mp4" },
                { 2, 115, 2, "Lesson 2. Data types", "./video/C/2_1.mp4" },
                { 3, 60, 2, "Lesson 2. Variables", "./video/C/2_2.mp4" },
                { 4, 75, 3, "Lesson 3. Algorithms", "./video/C/3.mp4" },
                { 5, 100, 4, "Lesson 4. Functions", "./video/C/4.mp4" }
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
            name: "IX_CourseOrder_OrdersId",
            table: "CourseOrder",
            column: "OrdersId");

        migrationBuilder.CreateIndex(
            name: "IX_Courses_CategoryId",
            table: "Courses",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Courses_LevelId",
            table: "Courses",
            column: "LevelId");

        migrationBuilder.CreateIndex(
            name: "IX_CourseStudent_StudentsId",
            table: "CourseStudent",
            column: "StudentsId");

        migrationBuilder.CreateIndex(
            name: "IX_Lectures_CourseId",
            table: "Lectures",
            column: "CourseId");

        migrationBuilder.CreateIndex(
            name: "IX_Materials_LectureId",
            table: "Materials",
            column: "LectureId");

        migrationBuilder.CreateIndex(
            name: "IX_Orders_UserId",
            table: "Orders",
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
            name: "CourseOrder");

        migrationBuilder.DropTable(
            name: "CourseStudent");

        migrationBuilder.DropTable(
            name: "Materials");

        migrationBuilder.DropTable(
            name: "AspNetRoles");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Students");

        migrationBuilder.DropTable(
            name: "Lectures");

        migrationBuilder.DropTable(
            name: "AspNetUsers");

        migrationBuilder.DropTable(
            name: "Courses");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Levels");
    }
}
