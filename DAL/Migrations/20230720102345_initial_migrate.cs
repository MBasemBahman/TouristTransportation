using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class initialmigrate : Migration
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
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
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
                name: "CompanyTripBookingState",
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
                    table.PrimaryKey("PK_CompanyTripBookingState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripState",
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
                    table.PrimaryKey("PK_CompanyTripState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
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
                    table.PrimaryKey("PK_Currency", x => x.Id);
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
                name: "Supplier",
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
                    table.PrimaryKey("PK_Supplier", x => x.Id);
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
                        name: "FK_CompanyTripBookingStateLang_CompanyTripBookingState_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "CompanyTripBookingState",
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
                        name: "FK_CompanyTrips_CompanyTripState_Fk_CompanyTripState",
                        column: x => x.FkCompanyTripState,
                        principalTable: "CompanyTripState",
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
                        name: "FK_CompanyTripStateLang_CompanyTripState_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "CompanyTripState",
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
                        name: "FK_CurrencyLang_Currency_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardAccessLevelLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardAccessLevelLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardAccessLevelLang_DashboardAccessLevels_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "DashboardAccessLevels",
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
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
                name: "DashboardViewLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    FkSource = table.Column<int>(name: "Fk_Source", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardViewLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardViewLang_DashboardViews_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "DashboardViews",
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
                        name: "FK_SupplierLang_Supplier_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "Supplier",
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
                        name: "FK_Accounts_Supplier_Fk_Supplier",
                        column: x => x.FkSupplier,
                        principalTable: "Supplier",
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
                name: "CompanyTripAttachment",
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
                    table.PrimaryKey("PK_CompanyTripAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripAttachment_CompanyTrips_Fk_CompanyTrip",
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
                        name: "FK_CompanyTripBookings_CompanyTripBookingState_Fk_CompanyTripBookingState",
                        column: x => x.FkCompanyTripBookingState,
                        principalTable: "CompanyTripBookingState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookings_CompanyTrips_Fk_CompanyTrip",
                        column: x => x.FkCompanyTrip,
                        principalTable: "CompanyTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookings_Currency_Fk_Currency",
                        column: x => x.FkCurrency,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
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
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Accounts_Fk_Account",
                        column: x => x.FkAccount,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyTripBookingHistory",
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
                    table.PrimaryKey("PK_CompanyTripBookingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookingHistory_CompanyTripBookingState_Fk_CompanyTripBookingState",
                        column: x => x.FkCompanyTripBookingState,
                        principalTable: "CompanyTripBookingState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CompanyTripBookingHistory_CompanyTripBookings_Fk_CompanyTripBooking",
                        column: x => x.FkCompanyTripBooking,
                        principalTable: "CompanyTripBookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PostAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkPost = table.Column<int>(name: "Fk_Post", type: "int", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostAttachment_Post_Fk_Post",
                        column: x => x.FkPost,
                        principalTable: "Post",
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PostReaction_Post_Fk_Post",
                        column: x => x.FkPost,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    { 13, null, "CompanyTripState", "CompanyTripState" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Culture", "EmailAddress", "LastModifiedBy", "Name", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, null, "user@mail.com", null, "Developer", "$2a$11$uMnuoXn7fqrPSY5DhilQ1OPvvKb9HLalz6lN8GufFgGK6/PPRvUWS", null, "Developer" });

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
                    { 13, 1, 1, 13 }
                });

            migrationBuilder.InsertData(
                table: "DashboardAccessLevelLang",
                columns: new[] { "Id", "Fk_Source", "Name" },
                values: new object[,]
                {
                    { 1, 1, "FullAccess" },
                    { 2, 2, "DataControl" },
                    { 3, 3, "Viewer" }
                });

            migrationBuilder.InsertData(
                table: "DashboardAdministrationRoleLang",
                columns: new[] { "Id", "Fk_Source", "Name" },
                values: new object[] { 1, 1, "Developer" });

            migrationBuilder.InsertData(
                table: "DashboardAdministrators",
                columns: new[] { "Id", "Fk_DashboardAdministrationRole", "Fk_User", "JobTitle", "LastModifiedBy" },
                values: new object[] { 1, 1, 1, "Developer", null });

            migrationBuilder.InsertData(
                table: "DashboardViewLang",
                columns: new[] { "Id", "Fk_Source", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Home" },
                    { 2, 2, "User" },
                    { 3, 3, "DashboardAdministrator" },
                    { 4, 4, "DashboardAccessLevel" },
                    { 5, 5, "DashboardAdministrationRole" },
                    { 6, 6, "DashboardView" },
                    { 7, 7, "RefreshToken" },
                    { 8, 8, "UserDevice" },
                    { 9, 9, "Verification" },
                    { 10, 10, "DBLogs" },
                    { 11, 11, "Audit" },
                    { 12, 12, "Account" },
                    { 13, 13, "CompanyTripState" }
                });

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
                name: "IX_CompanyTripAttachment_Fk_CompanyTrip",
                table: "CompanyTripAttachment",
                column: "Fk_CompanyTrip");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookingHistory_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistory",
                column: "Fk_CompanyTripBooking");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookingHistory_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistory",
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
                name: "IX_CompanyTripBookingState_Name",
                table: "CompanyTripBookingState",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripBookingStateLang_Fk_Source",
                table: "CompanyTripBookingStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripLang_Fk_Source",
                table: "CompanyTripLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTrips_Fk_CompanyTripState",
                table: "CompanyTrips",
                column: "Fk_CompanyTripState");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripState_Name",
                table: "CompanyTripState",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTripStateLang_Fk_Source",
                table: "CompanyTripStateLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Name",
                table: "Currency",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLang_Fk_Source",
                table: "CurrencyLang",
                column: "Fk_Source");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAccessLevelLang_Fk_Source",
                table: "DashboardAccessLevelLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAccessLevels_Name",
                table: "DashboardAccessLevels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DashboardAdministrationRoleLang_Fk_Source",
                table: "DashboardAdministrationRoleLang",
                column: "Fk_Source",
                unique: true);

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
                name: "IX_DashboardViewLang_Fk_Source",
                table: "DashboardViewLang",
                column: "Fk_Source",
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
                name: "IX_Post_Fk_Account",
                table: "Post",
                column: "Fk_Account");

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
                name: "Audits");

            migrationBuilder.DropTable(
                name: "CompanyTripAttachment");

            migrationBuilder.DropTable(
                name: "CompanyTripBookingHistory");

            migrationBuilder.DropTable(
                name: "CompanyTripBookingStateLang");

            migrationBuilder.DropTable(
                name: "CompanyTripLang");

            migrationBuilder.DropTable(
                name: "CompanyTripStateLang");

            migrationBuilder.DropTable(
                name: "CurrencyLang");

            migrationBuilder.DropTable(
                name: "DashboardAccessLevelLang");

            migrationBuilder.DropTable(
                name: "DashboardAdministrationRoleLang");

            migrationBuilder.DropTable(
                name: "DashboardAdministrators");

            migrationBuilder.DropTable(
                name: "DashboardViewLang");

            migrationBuilder.DropTable(
                name: "Devices");

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
                name: "Verifications");

            migrationBuilder.DropTable(
                name: "CompanyTripBookings");

            migrationBuilder.DropTable(
                name: "DashboardAccessLevels");

            migrationBuilder.DropTable(
                name: "DashboardAdministrationRoles");

            migrationBuilder.DropTable(
                name: "DashboardViews");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "CompanyTripBookingState");

            migrationBuilder.DropTable(
                name: "CompanyTrips");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CompanyTripState");

            migrationBuilder.DropTable(
                name: "AccountState");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
