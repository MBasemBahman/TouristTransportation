using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class NewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripBookingStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripBookingStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RateInPounds = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAccessLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateAccess = table.Column<bool>(type: "bit", nullable: false),
                    EditAccess = table.Column<bool>(type: "bit", nullable: false),
                    ViewAccess = table.Column<bool>(type: "bit", nullable: false),
                    DeleteAccess = table.Column<bool>(type: "bit", nullable: false),
                    ExportAccess = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAccessLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAdministrationRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAdministrationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ViewPath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountStateLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountStateLang_AccountState_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "AccountState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypeLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTypeLang_AccountType_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarCategoryLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategoryLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarCategoryLang_CarCategories_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "CarCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkCarCategory = table.Column<int>(name: "Fk_CarCategory", type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarClasses_CarCategories_Fk_CarCategory",
                        column: x => x.FkCarCategory,
                        principalTable: "CarCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripBookingStateLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripBookingStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookingStateLang_CompanyTripBookingStates_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "CompanyTripBookingStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkCompanyTripState = table.Column<int>(name: "Fk_CompanyTripState", type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTrips_CompanyTripStates_Fk_CompanyTripState",
                        column: x => x.FkCompanyTripState,
                        principalTable: "CompanyTripStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripStateLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripStateLang_CompanyTripStates_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "CompanyTripStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkCountry = table.Column<int>(name: "Fk_Country", type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Countries_Fk_Country",
                        column: x => x.FkCountry,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryLang_Countries_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyLang_Currencies_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAdministrationRoleLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAdministrationRoleLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardAdministrationRoleLang_DashboardAdministrationRoles_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "DashboardAdministrationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministrationRolePremissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkDashboardAccessLevel = table.Column<int>(name: "Fk_DashboardAccessLevel", type: "int", nullable: false),
                    FkDashboardAdministrationRole = table.Column<int>(name: "Fk_DashboardAdministrationRole", type: "int", nullable: false),
                    FkDashboardView = table.Column<int>(name: "Fk_DashboardView", type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrationRolePremissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministrationRolePremissions_DashboardAccessLevels_Fk_DashboardAccessLevel",
                        column: x => x.FkDashboardAccessLevel,
                        principalTable: "DashboardAccessLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministrationRolePremissions_DashboardAdministrationRoles_Fk_DashboardAdministrationRole",
                        column: x => x.FkDashboardAdministrationRole,
                        principalTable: "DashboardAdministrationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministrationRolePremissions_DashboardViews_Fk_DashboardView",
                        column: x => x.FkDashboardView,
                        principalTable: "DashboardViews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureCategoryLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureCategoryLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatureCategoryLang_HotelFeatureCategories_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "HotelFeatureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkHotelFeatureCategory = table.Column<int>(name: "Fk_HotelFeatureCategory", type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatures_HotelFeatureCategories_Fk_HotelFeatureCategory",
                        column: x => x.FkHotelFeatureCategory,
                        principalTable: "HotelFeatureCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierLang_Suppliers_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripStateLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripStateLang_TripStates_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "TripStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUser = table.Column<int>(name: "Fk_User", type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkAccountType = table.Column<int>(name: "Fk_AccountType", type: "int", nullable: false),
                    FkAccountState = table.Column<int>(name: "Fk_AccountState", type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSupplier = table.Column<int>(name: "Fk_Supplier", type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountState_Fk_AccountState",
                        column: x => x.FkAccountState,
                        principalTable: "AccountState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountType_Fk_AccountType",
                        column: x => x.FkAccountType,
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Suppliers_Fk_Supplier",
                        column: x => x.FkSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Users_Fk_User",
                        column: x => x.FkUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DashboardAdministrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUser = table.Column<int>(name: "Fk_User", type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkDashboardAdministrationRole = table.Column<int>(name: "Fk_DashboardAdministrationRole", type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAdministrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardAdministrators_DashboardAdministrationRoles_Fk_DashboardAdministrationRole",
                        column: x => x.FkDashboardAdministrationRole,
                        principalTable: "DashboardAdministrationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashboardAdministrators_Users_Fk_User",
                        column: x => x.FkUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUser = table.Column<int>(name: "Fk_User", type: "int", nullable: false),
                    NotificationToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Users_Fk_User",
                        column: x => x.FkUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUser = table.Column<int>(name: "Fk_User", type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_Fk_User",
                        column: x => x.FkUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUser = table.Column<int>(name: "Fk_User", type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verifications_Users_Fk_User",
                        column: x => x.FkUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarClassLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarClassLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarClassLang_CarClasses_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "CarClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkCompanyTrip = table.Column<int>(name: "Fk_CompanyTrip", type: "int", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripAttachments_CompanyTrips_Fk_CompanyTrip",
                        column: x => x.FkCompanyTrip,
                        principalTable: "CompanyTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripLang_CompanyTrips_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "CompanyTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaLang_Areas_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkArea = table.Column<int>(name: "Fk_Area", type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Areas_Fk_Area",
                        column: x => x.FkArea,
                        principalTable: "Areas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HotelFeatureLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFeatureLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeatureLang_HotelFeatures_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkAccount = table.Column<int>(name: "Fk_Account", type: "int", nullable: false),
                    FkCompanyTrip = table.Column<int>(name: "Fk_CompanyTrip", type: "int", nullable: false),
                    FkCurrency = table.Column<int>(name: "Fk_Currency", type: "int", nullable: false),
                    FkCompanyTripBookingState = table.Column<int>(name: "Fk_CompanyTripBookingState", type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CurrencyRate = table.Column<double>(type: "float", nullable: false),
                    MembersCount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookings_Accounts_Fk_Account",
                        column: x => x.FkAccount,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookings_CompanyTripBookingStates_Fk_CompanyTripBookingState",
                        column: x => x.FkCompanyTripBookingState,
                        principalTable: "CompanyTripBookingStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookings_CompanyTrips_Fk_CompanyTrip",
                        column: x => x.FkCompanyTrip,
                        principalTable: "CompanyTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookings_Currencies_Fk_Currency",
                        column: x => x.FkCurrency,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkAccount = table.Column<int>(name: "Fk_Account", type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Accounts_Fk_Account",
                        column: x => x.FkAccount,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkClient = table.Column<int>(name: "Fk_Client", type: "int", nullable: false),
                    FkSupplier = table.Column<int>(name: "Fk_Supplier", type: "int", nullable: true),
                    FkDriver = table.Column<int>(name: "Fk_Driver", type: "int", nullable: true),
                    FkCarClass = table.Column<int>(name: "Fk_CarClass", type: "int", nullable: true),
                    FkTripState = table.Column<int>(name: "Fk_TripState", type: "int", nullable: false),
                    TripAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    WaitingPrice = table.Column<double>(type: "float", nullable: false),
                    MembersCount = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Accounts_Fk_Client",
                        column: x => x.FkClient,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Accounts_Fk_Driver",
                        column: x => x.FkDriver,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_CarClasses_Fk_CarClass",
                        column: x => x.FkCarClass,
                        principalTable: "CarClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_Suppliers_Fk_Supplier",
                        column: x => x.FkSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_TripStates_Fk_TripState",
                        column: x => x.FkTripState,
                        principalTable: "TripStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkHotel = table.Column<int>(name: "Fk_Hotel", type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileLength = table.Column<double>(type: "float", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelAttachments_Hotels_Fk_Hotel",
                        column: x => x.FkHotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelLang_Hotels_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelSelectedFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkHotel = table.Column<int>(name: "Fk_Hotel", type: "int", nullable: false),
                    FkHotelFeature = table.Column<int>(name: "Fk_HotelFeature", type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelSelectedFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelSelectedFeatures_HotelFeatures_Fk_HotelFeature",
                        column: x => x.FkHotelFeature,
                        principalTable: "HotelFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelSelectedFeatures_Hotels_Fk_Hotel",
                        column: x => x.FkHotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripBookingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkCompanyTripBooking = table.Column<int>(name: "Fk_CompanyTripBooking", type: "int", nullable: false),
                    FkCompanyTripBookingState = table.Column<int>(name: "Fk_CompanyTripBookingState", type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTripBookingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookingHistories_CompanyTripBookingStates_Fk_CompanyTripBookingState",
                        column: x => x.FkCompanyTripBookingState,
                        principalTable: "CompanyTripBookingStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookingHistories_CompanyTripBookings_Fk_CompanyTripBooking",
                        column: x => x.FkCompanyTripBooking,
                        principalTable: "CompanyTripBookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkPost = table.Column<int>(name: "Fk_Post", type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileLength = table.Column<double>(type: "float", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostAttachment_Posts_Fk_Post",
                        column: x => x.FkPost,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostReaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkPost = table.Column<int>(name: "Fk_Post", type: "int", nullable: false),
                    FkAccount = table.Column<int>(name: "Fk_Account", type: "int", nullable: false),
                    Reaction = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReaction_Accounts_Fk_Account",
                        column: x => x.FkAccount,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReaction_Posts_Fk_Post",
                        column: x => x.FkPost,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkTrip = table.Column<int>(name: "Fk_Trip", type: "int", nullable: false),
                    FkSupplier = table.Column<int>(name: "Fk_Supplier", type: "int", nullable: true),
                    FkDriver = table.Column<int>(name: "Fk_Driver", type: "int", nullable: true),
                    FkTripState = table.Column<int>(name: "Fk_TripState", type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripHistories_Accounts_Fk_Driver",
                        column: x => x.FkDriver,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripHistories_Suppliers_Fk_Supplier",
                        column: x => x.FkSupplier,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripHistories_TripStates_Fk_TripState",
                        column: x => x.FkTripState,
                        principalTable: "TripStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripHistories_Trips_Fk_Trip",
                        column: x => x.FkTrip,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkTrip = table.Column<int>(name: "Fk_Trip", type: "int", nullable: false),
                    FromLatitude = table.Column<double>(type: "float", nullable: true),
                    FromLongitude = table.Column<double>(type: "float", nullable: true),
                    ToLatitude = table.Column<double>(type: "float", nullable: true),
                    ToLongitude = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TripAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeaveAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaitingTime = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripPoints_Trips_Fk_Trip",
                        column: x => x.FkTrip,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DashboardAccessLevels",
                columns: new[] { "Id", "ColorCode", "CreateAccess", "DeleteAccess", "EditAccess", "ExportAccess", "Name", "ViewAccess" },
                values: new object[,]
                {
                    { 1, null, true, true, true, true, "FullAccess", true },
                    { 2, null, true, false, true, true, "DataControl", true },
                    { 3, null, false, false, false, false, "Viewer", true }
                });

            migrationBuilder.InsertData(
                table: "DashboardAdministrationRoles",
                columns: new[] { "Id", "ColorCode", "Name" },
                values: new object[] { 1, null, "Developer" });

            migrationBuilder.InsertData(
                table: "DashboardViews",
                columns: new[] { "Id", "ColorCode", "Name", "ViewPath" },
                values: new object[,]
                {
                    { 1, null, "Home", "Home" },
                    { 2, null, "User", "User" },
                    { 3, null, "DashboardAdministrator", "DashboardAdministrator" },
                    { 4, null, "DashboardAccessLevel", "DashboardAccessLevel" },
                    { 5, null, "DashboardAdministrationRole", "DashboardAdministrationRole" },
                    { 6, null, "DashboardView", "DashboardView" },
                    { 7, null, "RefreshToken", "RefreshToken" },
                    { 8, null, "UserDevice", "UserDevice" },
                    { 9, null, "Verification", "Verification" },
                    { 10, null, "DBLogs", "DBLogs" },
                    { 11, null, "Audit", "Audit" },
                    { 12, null, "Account", "Account" },
                    { 13, null, "CompanyTripState", "CompanyTripState" },
                    { 14, null, "AccountState", "AccountState" },
                    { 15, null, "AccountType", "AccountType" },
                    { 16, null, "Area", "Area" },
                    { 17, null, "Country", "Country" },
                    { 18, null, "Currency", "Currency" },
                    { 19, null, "Supplier", "Supplier" },
                    { 20, null, "Post", "Post" },
                    { 21, null, "PostAttachment", "PostAttachment" },
                    { 22, null, "PostReaction", "PostReaction" },
                    { 23, null, "Hotel", "Hotel" },
                    { 24, null, "HotelAttachment", "HotelAttachment" },
                    { 25, null, "CarClass", "CarClass" },
                    { 26, null, "CarCategory", "CarCategory" },
                    { 27, null, "TripState", "TripState" },
                    { 28, null, "HotelFeatureCategory", "HotelFeatureCategory" },
                    { 29, null, "HotelFeature", "HotelFeature" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Culture", "EmailAddress", "LastModifiedBy", "Name", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, null, "user@mail.com", null, "Developer", "$2a$11$X7kHlHtht9ZNOg8VGEXo8ea6tJ0D5xiCYt8abAY7oYbQbRVqZCxlC", null, "Developer" });

            migrationBuilder.InsertData(
                table: "AdministrationRolePremissions",
                columns: new[] { "Id", "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 1, 1, 3 },
                    { 4, 1, 1, 4 },
                    { 5, 1, 1, 5 },
                    { 6, 1, 1, 6 },
                    { 7, 1, 1, 7 },
                    { 8, 1, 1, 8 },
                    { 9, 1, 1, 9 },
                    { 10, 1, 1, 10 },
                    { 11, 1, 1, 11 },
                    { 12, 1, 1, 12 },
                    { 13, 1, 1, 13 },
                    { 14, 1, 1, 14 },
                    { 15, 1, 1, 15 },
                    { 16, 1, 1, 16 },
                    { 17, 1, 1, 17 },
                    { 18, 1, 1, 18 },
                    { 19, 1, 1, 19 },
                    { 20, 1, 1, 20 },
                    { 21, 1, 1, 21 },
                    { 22, 1, 1, 22 },
                    { 23, 1, 1, 23 },
                    { 24, 1, 1, 24 },
                    { 25, 1, 1, 25 },
                    { 26, 1, 1, 26 },
                    { 27, 1, 1, 27 },
                    { 28, 1, 1, 28 },
                    { 29, 1, 1, 29 }
                });

            migrationBuilder.InsertData(
                table: "DashboardAdministrationRoleLang",
                columns: new[] { "Id", "Fk_Source", "Language", "LastModifiedBy", "Name" },
                values: new object[] { 1, 1, 0, null, "Developer" });

            migrationBuilder.InsertData(
                table: "DashboardAdministrators",
                columns: new[] { "Id", "Fk_DashboardAdministrationRole", "Fk_User", "JobTitle", "LastModifiedBy" },
                values: new object[] { 1, 1, 1, "Developer", null });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_AccountState",
                table: "Accounts",
                column: "Fk_AccountState");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_AccountType",
                table: "Accounts",
                column: "Fk_AccountType");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_Supplier",
                table: "Accounts",
                column: "Fk_Supplier");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_User",
                table: "Accounts",
                column: "Fk_User",
                unique: true,
                filter: "[Fk_User] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountState_Name",
                table: "AccountState",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountStateLang_Fk_Source",
                table: "AccountStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_Name",
                table: "AccountType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeLang_Fk_Source",
                table: "AccountTypeLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationRolePremissions_Fk_DashboardAccessLevel",
                table: "AdministrationRolePremissions",
                column: "Fk_DashboardAccessLevel");

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationRolePremissions_Fk_DashboardAdministrationRole_Fk_DashboardView",
                table: "AdministrationRolePremissions",
                columns: new[] { "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdministrationRolePremissions_Fk_DashboardView",
                table: "AdministrationRolePremissions",
                column: "Fk_DashboardView");

            migrationBuilder.CreateIndex(
                name: "IX_AreaLang_Fk_Source",
                table: "AreaLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Fk_Country",
                table: "Areas",
                column: "Fk_Country");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarCategories_Name",
                table: "CarCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarCategoryLang_Fk_Source",
                table: "CarCategoryLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_CarClasses_Fk_CarCategory",
                table: "CarClasses",
                column: "Fk_CarCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CarClassLang_Fk_Source",
                table: "CarClassLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripAttachments_Fk_CompanyTrip",
                table: "CompanyTripAttachments",
                column: "Fk_CompanyTrip");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookingHistories_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistories",
                column: "Fk_CompanyTripBooking");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookingHistories_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistories",
                column: "Fk_CompanyTripBookingState");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookings_Fk_Account",
                table: "CompanyTripBookings",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookings_Fk_CompanyTrip",
                table: "CompanyTripBookings",
                column: "Fk_CompanyTrip");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookings_Fk_CompanyTripBookingState",
                table: "CompanyTripBookings",
                column: "Fk_CompanyTripBookingState");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookings_Fk_Currency",
                table: "CompanyTripBookings",
                column: "Fk_Currency");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookingStateLang_Fk_Source",
                table: "CompanyTripBookingStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookingStates_Name",
                table: "CompanyTripBookingStates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripLang_Fk_Source",
                table: "CompanyTripLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTrips_Fk_CompanyTripState",
                table: "CompanyTrips",
                column: "Fk_CompanyTripState");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripStateLang_Fk_Source",
                table: "CompanyTripStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripStates_Name",
                table: "CompanyTripStates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryLang_Fk_Source",
                table: "CountryLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Name",
                table: "Currencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLang_Fk_Source",
                table: "CurrencyLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAccessLevels_Name",
                table: "DashboardAccessLevels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrationRoleLang_Fk_Source",
                table: "DashboardAdministrationRoleLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrationRoles_Name",
                table: "DashboardAdministrationRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrators_Fk_DashboardAdministrationRole",
                table: "DashboardAdministrators",
                column: "Fk_DashboardAdministrationRole");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrators_Fk_User",
                table: "DashboardAdministrators",
                column: "Fk_User",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardViews_Name",
                table: "DashboardViews",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardViews_ViewPath",
                table: "DashboardViews",
                column: "ViewPath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_Fk_User",
                table: "Devices",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_NotificationToken",
                table: "Devices",
                column: "NotificationToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelAttachments_Fk_Hotel",
                table: "HotelAttachments",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureCategories_Name",
                table: "HotelFeatureCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureCategoryLang_Fk_Source",
                table: "HotelFeatureCategoryLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureLang_Fk_Source",
                table: "HotelFeatureLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_Fk_HotelFeatureCategory",
                table: "HotelFeatures",
                column: "Fk_HotelFeatureCategory");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatures_Name",
                table: "HotelFeatures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelLang_Fk_Source",
                table: "HotelLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Fk_Area",
                table: "Hotels",
                column: "Fk_Area");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSelectedFeatures_Fk_Hotel",
                table: "HotelSelectedFeatures",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelSelectedFeatures_Fk_HotelFeature",
                table: "HotelSelectedFeatures",
                column: "Fk_HotelFeature");

            migrationBuilder.CreateIndex(
                name: "IX_PostAttachment_Fk_Post",
                table: "PostAttachment",
                column: "Fk_Post");

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_Fk_Account",
                table: "PostReaction",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_Fk_Post",
                table: "PostReaction",
                column: "Fk_Post");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Fk_Account",
                table: "Posts",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Fk_User",
                table: "RefreshTokens",
                column: "Fk_User");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierLang_Fk_Source",
                table: "SupplierLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_TripHistories_Fk_Driver",
                table: "TripHistories",
                column: "Fk_Driver");

            migrationBuilder.CreateIndex(
                name: "IX_TripHistories_Fk_Supplier",
                table: "TripHistories",
                column: "Fk_Supplier");

            migrationBuilder.CreateIndex(
                name: "IX_TripHistories_Fk_Trip",
                table: "TripHistories",
                column: "Fk_Trip");

            migrationBuilder.CreateIndex(
                name: "IX_TripHistories_Fk_TripState",
                table: "TripHistories",
                column: "Fk_TripState");

            migrationBuilder.CreateIndex(
                name: "IX_TripPoints_Fk_Trip",
                table: "TripPoints",
                column: "Fk_Trip");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Fk_CarClass",
                table: "Trips",
                column: "Fk_CarClass");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Fk_Client",
                table: "Trips",
                column: "Fk_Client");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Fk_Driver",
                table: "Trips",
                column: "Fk_Driver");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Fk_Supplier",
                table: "Trips",
                column: "Fk_Supplier");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_Fk_TripState",
                table: "Trips",
                column: "Fk_TripState");

            migrationBuilder.CreateIndex(
                name: "IX_TripStateLang_Fk_Source",
                table: "TripStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_TripStates_Name",
                table: "TripStates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verifications_Code",
                table: "Verifications",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verifications_Fk_User",
                table: "Verifications",
                column: "Fk_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountStateLang");

            migrationBuilder.DropTable(
                name: "AccountTypeLang");

            migrationBuilder.DropTable(
                name: "AdministrationRolePremissions");

            migrationBuilder.DropTable(
                name: "AreaLang");

            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DropTable(
                name: "CarCategoryLang");

            migrationBuilder.DropTable(
                name: "CarClassLang");

            migrationBuilder.DropTable(
                name: "CompanyTripAttachments");

            migrationBuilder.DropTable(
                name: "CompanyTripBookingHistories");

            migrationBuilder.DropTable(
                name: "CompanyTripBookingStateLang");

            migrationBuilder.DropTable(
                name: "CompanyTripLang");

            migrationBuilder.DropTable(
                name: "CompanyTripStateLang");

            migrationBuilder.DropTable(
                name: "CountryLang");

            migrationBuilder.DropTable(
                name: "CurrencyLang");

            migrationBuilder.DropTable(
                name: "DashboardAdministrationRoleLang");

            migrationBuilder.DropTable(
                name: "DashboardAdministrators");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "HotelAttachments");

            migrationBuilder.DropTable(
                name: "HotelFeatureCategoryLang");

            migrationBuilder.DropTable(
                name: "HotelFeatureLang");

            migrationBuilder.DropTable(
                name: "HotelLang");

            migrationBuilder.DropTable(
                name: "HotelSelectedFeatures");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PostAttachment");

            migrationBuilder.DropTable(
                name: "PostReaction");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SupplierLang");

            migrationBuilder.DropTable(
                name: "TripHistories");

            migrationBuilder.DropTable(
                name: "TripPoints");

            migrationBuilder.DropTable(
                name: "TripStateLang");

            migrationBuilder.DropTable(
                name: "Verifications");

            migrationBuilder.DropTable(
                name: "DashboardAccessLevels");

            migrationBuilder.DropTable(
                name: "DashboardViews");

            migrationBuilder.DropTable(
                name: "CompanyTripBookings");

            migrationBuilder.DropTable(
                name: "DashboardAdministrationRoles");

            migrationBuilder.DropTable(
                name: "HotelFeatures");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "CompanyTripBookingStates");

            migrationBuilder.DropTable(
                name: "CompanyTrips");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "HotelFeatureCategories");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CarClasses");

            migrationBuilder.DropTable(
                name: "TripStates");

            migrationBuilder.DropTable(
                name: "CompanyTripStates");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AccountState");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarCategories");
        }
    }
}
