using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Musician.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
========
                    District = table.Column<string>(type: "TEXT", nullable: true),
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enstruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    NormalizedEnstrumentName = table.Column<string>(type: "TEXT", nullable: true)
========
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enstruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
========
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    District = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
========
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    OwnDescription = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    EnstrumentName = table.Column<string>(type: "TEXT", nullable: false),
                    EnstrumentId = table.Column<int>(type: "INTEGER", nullable: true),
                    NormalizedEnstrumentName = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true),
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: true)
========
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: true)
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Enstruments_EnstrumentId",
                        column: x => x.EnstrumentId,
                        principalTable: "Enstruments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    table.ForeignKey(
                        name: "FK_Cards_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
========
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
========
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    District = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
========
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                        name: "FK_Students_Cards_CardId",
========
                        name: "FK_Teachers_Cards_CardId",
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                        name: "FK_Students_Images_ImageId",
========
                        name: "FK_Teachers_Images_ImageId",
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    { "3660a50e-5728-473c-92e9-914fde89d5ff", null, "Öğretmen", "Teacher", "TEACHER" },
                    { "76bc560f-f5d2-4096-aa96-f05b90c7d5f5", null, "Öğrenci", "Student", "STUDENT" },
                    { "7b9dcaf3-2089-46a5-980f-c7d486d616a5", null, "User", "User", "USER" },
                    { "ffda5227-6caa-4e01-ae23-a7226cc62aef", null, "Admin", "Admin", "ADMIN" }
========
                    { "2feb1920-6a64-4011-9bb4-872114d40811", null, "Öğrenci", "Student", "STUDENT" },
                    { "a06b49d5-7bf2-4fd0-a634-ac89181e3bf7", null, "User", "User", "USER" },
                    { "df1e3c87-c998-44c6-9fdb-f7d191e0f502", null, "Admin", "Admin", "ADMIN" },
                    { "eca23c28-9f4c-47e2-ab06-e4803bc8d3f8", null, "Öğretmen", "Teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Description", "District", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a0738d4a-f1e8-4cbe-90dc-aa9de35f43f0", 0, "İstanbul", "1a1c34b3-48d8-4482-8df0-04109800e9f9", new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd", "Bahçelievler", "efe@gmail.com", false, "Efe", "Erkek", "Son", false, null, "EFE@GMAIL.COM", "EFE", "AQAAAAIAAYagAAAAENxBpgNIj9rkL0MvF4uSHTOGoRAw2fdDjbq/ltietv4unlh6L24MVprJYxLStYlG2Q==", null, false, 0, "382853b2-ba99-4df6-8318-52c1471ef5da", false, "efe" },
                    { "dbcaee8a-6aed-4d64-88a2-0159950691d4", 0, "İstanbul", "e387e1f1-e38b-49d3-ba41-f9c071d2cb8d", new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd", "Kadıköy", "ece@gmail.com", false, "Ece", "Kadın", "Orta", false, null, "ECE@GMAIL.COM", "ECE", "AQAAAAIAAYagAAAAELozV4WFY3cWJFcxcUt+4jLnQgxu41tvnDp4x0X9Z8fR9cgUOHTjdu4nCrLmNLV/Qw==", null, false, 0, "3e3fade3-10fb-4a32-bc6e-640816ffcf0f", false, "ece" },
                    { "e526230e-29de-43c6-a2b4-bd1e22479434", 0, "İstanbul", "e32aac48-8bb8-4fe0-8840-22f5b019964a", new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd", "Beşiktaş", "ege@gmail.com", false, "Ege", "Erkek", "ilk", false, null, "EGE@GMAIL.COM", "EGE", "AQAAAAIAAYagAAAAEPPMpXtB8Ajxu805SyWx4motYCiST5cuQPk6z1v6x49CEXezaH07/22Q22K/9WioNA==", null, false, 0, "e35afb53-d291-4859-b788-88564ce6fc29", false, "ege" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "City", "Description", "EnstrumentId", "EnstrumentName", "FirstName", "ImageId", "NormalizedEnstrumentName", "OwnDescription", "Price", "TeacherId" },
                values: new object[,]
                {
                    { 1, "İstanbul", "Kaval dersi veriyorum", null, "Kaval", "Ahmet", null, "", null, 250m, null },
                    { 2, "İstanbul", "Gitar dersi veriyorum", null, "Gitar", "Mehmet", null, "", null, 270m, null },
                    { 3, "İstanbul", "Kalimba dersi veriyorum", null, "Kalimba", "Ezgi", null, "", null, 240m, null },
                    { 4, "İstanbul", "Kaval dersi veriyorum", null, "Kaval", "Arda", null, "", null, 250m, null },
                    { 5, "İstanbul", "Kaval dersi veriyorum", null, "Kaval", "Erdi", null, "", null, 350m, null },
                    { 6, "İstanbul", "Kaval dersi veriyorum", null, "Kaval", "Ulaş", null, "", null, 150m, null },
                    { 7, "İstanbul", "Kaval dersi veriyorum", null, "Kaval", "Canan", null, "", null, 200m, null },
                    { 8, "İstanbul", "Kaval dersi veriyorum", null, "Kaval", "İlknur", null, "", null, 400m, null },
                    { 9, "İstanbul", "Kaval dersi veriyorum", null, "Kaval", "Hakan", null, "", null, 180m, null }
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                });

            migrationBuilder.InsertData(
                table: "Enstruments",
                columns: new[] { "Id", "IsApproved", "Name", "NormalizedEnstrumentName", "Url" },
                values: new object[,]
                {
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                    { 1, true, "Gitar", "", "gitar" },
                    { 2, true, "Keman", "", "keman" },
                    { 3, true, "Piyano", "", "piyano" },
                    { 4, true, "Bateri", "", "bateri" },
                    { 5, true, "Flüt", "", "flut" },
                    { 6, true, "Klarnet", "", "klarnet" },
                    { 7, true, "Çello", "", "cello" },
                    { 8, true, "Bağlama", "", "baglama" },
                    { 9, true, "Ud", "", "ud" },
                    { 10, true, "Kalimba", "", "kalimba" }
========
                    { 1, true, "Gitar", 0, "gitar" },
                    { 2, true, "Keman", 0, "keman" },
                    { 3, true, "Piyano", 0, "piyano" },
                    { 4, true, "Bateri", 0, "bateri" },
                    { 5, true, "Flüt", 0, "flut" },
                    { 6, true, "Klarnet", 0, "klarnet" },
                    { 7, true, "Çello", 0, "cello" },
                    { 8, true, "Bağlama", 0, "baglama" },
                    { 9, true, "Ud", 0, "ud" },
                    { 10, true, "Kalimba", 0, "kalimba" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "City", "DateOfBirth", "Description", "District", "FirstName", "Gender", "LastName", "Url" },
                values: new object[,]
                {
                    { 1, "İstanbul", new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "gitar öğrenmek istiyorum", "Beşiktaş", "Şeyma", "Kadın", "Cankuş", "seyma-cankus" },
                    { 2, "İstanbul", new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "keman öğrenmek istiyorum", "Beşiktaş", "Sema", "Kadın", "asd", "sema-asd" },
                    { 3, "İstanbul", new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "kalimba öğrenmek istiyorum", "Beşiktaş", "Uğurcan", "Erkek", "Emare", "ugurcan-emare" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CardId", "City", "CreatedDate", "DateOfBirth", "Description", "District", "FirstName", "Gender", "ImageId", "IsApproved", "LastName", "PhoneNumber", "Status", "Url", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, null, "İstanbul", new DateTime(2023, 4, 18, 12, 39, 38, 367, DateTimeKind.Local).AddTicks(3374), new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalimba çalıyorum", "Beşiktaş", "Mehmet", "Erkek", null, true, "Öçgüder", "", "Home", "mehmetocguder", null, "mehmetocguder" },
                    { 2, null, "İstanbul", new DateTime(2023, 4, 18, 12, 39, 38, 367, DateTimeKind.Local).AddTicks(3393), new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalimba çalıyorum", "Beşiktaş", "Canan", "Kadın", null, true, "asd", "", "Home", "canan", null, "canan" },
                    { 3, null, "İstanbul", new DateTime(2023, 4, 18, 12, 39, 38, 367, DateTimeKind.Local).AddTicks(3410), new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalimba çalıyorum", "Beşiktaş", "Ezgi", "Kadın", null, true, "sdf", "", "Home", "ezgi", null, "ezzgi" },
                    { 4, null, "İstanbul", new DateTime(2023, 4, 18, 12, 39, 38, 367, DateTimeKind.Local).AddTicks(3414), new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalimba çalıyorum", "Beşiktaş", "Arda", "Erkek", null, true, "sss", "", "Home", "arda", null, "arda" },
                    { 5, null, "İstanbul", new DateTime(2023, 4, 18, 12, 39, 38, 367, DateTimeKind.Local).AddTicks(3417), new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalimba çalıyorum", "Beşiktaş", "Erdi", "Erkek", null, true, "asdf", "", "Home", "erdi", null, "erdi" },
                    { 6, null, "İstanbul", new DateTime(2023, 4, 18, 12, 39, 38, 367, DateTimeKind.Local).AddTicks(3422), new DateTime(1985, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalimba çalıyorum", "Beşiktaş", "Ahmet", "Erkek", null, true, "fgd", "", "Home", "ahmet", null, "ahmet" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2feb1920-6a64-4011-9bb4-872114d40811", "a0738d4a-f1e8-4cbe-90dc-aa9de35f43f0" },
                    { "eca23c28-9f4c-47e2-ab06-e4803bc8d3f8", "dbcaee8a-6aed-4d64-88a2-0159950691d4" },
                    { "df1e3c87-c998-44c6-9fdb-f7d191e0f502", "e526230e-29de-43c6-a2b4-bd1e22479434" }
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
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
                name: "IX_Cards_EnstrumentId",
                table: "Cards",
                column: "EnstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ImageId",
                table: "Cards",
                column: "ImageId");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                name: "IX_Cards_StudentId",
                table: "Cards",
                column: "StudentId");

            migrationBuilder.CreateIndex(
========
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                name: "IX_Cards_TeacherId",
                table: "Cards",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CardId",
                table: "Requests",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CardId",
                table: "Students",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ImageId",
                table: "Students",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
========
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CardId",
                table: "Teachers",
                column: "CardId");

            migrationBuilder.CreateIndex(
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                name: "IX_Teachers_ImageId",
                table: "Teachers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                name: "FK_Cards_Students_StudentId",
                table: "Cards",
                column: "StudentId",
                principalTable: "Students",
========
                name: "FK_Cards_Teachers_TeacherId",
                table: "Cards",
                column: "TeacherId",
                principalTable: "Teachers",
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images");

            migrationBuilder.DropForeignKey(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
========
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                name: "FK_Teachers_AspNetUsers_UserId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Enstruments_EnstrumentId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Images_ImageId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                name: "FK_Students_Images_ImageId",
                table: "Students");

            migrationBuilder.DropForeignKey(
========
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                name: "FK_Teachers_Images_ImageId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                name: "FK_Cards_Students_StudentId",
========
                name: "FK_Cards_Teachers_TeacherId",
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                table: "Cards");

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
<<<<<<<< HEAD:Musician.Data/Migrations/20230428223307_InitialDb.cs
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Enstruments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
========
>>>>>>>> 5e78a95da77671fc536ce3dbf0d7cbdcd5348791:Musician.Data/Migrations/20230418093938_InitialDb.cs
                name: "Students");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Enstruments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
