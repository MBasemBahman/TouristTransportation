using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class FHHHVBBVBVBV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripAttachment_CompanyTrips_Fk_CompanyTrip",
                table: "CompanyTripAttachment");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookingHistory_CompanyTripBookingState_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookingHistory_CompanyTripBookings_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookings_CompanyTripBookingState_Fk_CompanyTripBookingState",
                table: "CompanyTripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookingStateLang_CompanyTripBookingState_Fk_Source",
                table: "CompanyTripBookingStateLang");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTrips_CompanyTripState_Fk_CompanyTripState",
                table: "CompanyTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripStateLang_CompanyTripState_Fk_Source",
                table: "CompanyTripStateLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripState",
                table: "CompanyTripState");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripBookingState",
                table: "CompanyTripBookingState");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripBookingHistory",
                table: "CompanyTripBookingHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripAttachment",
                table: "CompanyTripAttachment");

            migrationBuilder.RenameTable(
                name: "CompanyTripState",
                newName: "CompanyTripStates");

            migrationBuilder.RenameTable(
                name: "CompanyTripBookingState",
                newName: "CompanyTripBookingStates");

            migrationBuilder.RenameTable(
                name: "CompanyTripBookingHistory",
                newName: "CompanyTripBookingHistories");

            migrationBuilder.RenameTable(
                name: "CompanyTripAttachment",
                newName: "CompanyTripAttachments");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripState_Name",
                table: "CompanyTripStates",
                newName: "IX_CompanyTripStates_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripBookingState_Name",
                table: "CompanyTripBookingStates",
                newName: "IX_CompanyTripBookingStates_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripBookingHistory_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistories",
                newName: "IX_CompanyTripBookingHistories_Fk_CompanyTripBookingState");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripBookingHistory_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistories",
                newName: "IX_CompanyTripBookingHistories_Fk_CompanyTripBooking");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripAttachment_Fk_CompanyTrip",
                table: "CompanyTripAttachments",
                newName: "IX_CompanyTripAttachments_Fk_CompanyTrip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripStates",
                table: "CompanyTripStates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripBookingStates",
                table: "CompanyTripBookingStates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripBookingHistories",
                table: "CompanyTripBookingHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripAttachments",
                table: "CompanyTripAttachments",
                column: "Id");

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
                name: "HotelAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkHotel = table.Column<int>(name: "Fk_Hotel", type: "int", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 4 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 6 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 7 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 8 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 9 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 10 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 11 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 12 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 13 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 14 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 15 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 16 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 17 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 18 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 19 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 20 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 21 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 22 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 23 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 24 });

            migrationBuilder.UpdateData(
                table: "DashboardAccessLevelLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAccessLevelLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DashboardAccessLevelLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrators",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fk_DashboardAdministrationRole", "Fk_User" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 6);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 7);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 8);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 9);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 10);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 11);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 12);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 13);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 14);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 15);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 16);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 17);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 18);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 19);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 20);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 21,
                column: "Fk_Source",
                value: 21);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 22,
                column: "Fk_Source",
                value: 22);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 23,
                column: "Fk_Source",
                value: 23);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 24,
                column: "Fk_Source",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$AC3whocz.xYgNrjVEhXfveytzgrUSI/1Qek5sDgauazF92DAT5ePa");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripAttachments_CompanyTrips_Fk_CompanyTrip",
                table: "CompanyTripAttachments",
                column: "Fk_CompanyTrip",
                principalTable: "CompanyTrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookingHistories_CompanyTripBookingStates_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistories",
                column: "Fk_CompanyTripBookingState",
                principalTable: "CompanyTripBookingStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookingHistories_CompanyTripBookings_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistories",
                column: "Fk_CompanyTripBooking",
                principalTable: "CompanyTripBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookings_CompanyTripBookingStates_Fk_CompanyTripBookingState",
                table: "CompanyTripBookings",
                column: "Fk_CompanyTripBookingState",
                principalTable: "CompanyTripBookingStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookingStateLang_CompanyTripBookingStates_Fk_Source",
                table: "CompanyTripBookingStateLang",
                column: "Fk_Source",
                principalTable: "CompanyTripBookingStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTrips_CompanyTripStates_Fk_CompanyTripState",
                table: "CompanyTrips",
                column: "Fk_CompanyTripState",
                principalTable: "CompanyTripStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripStateLang_CompanyTripStates_Fk_Source",
                table: "CompanyTripStateLang",
                column: "Fk_Source",
                principalTable: "CompanyTripStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripAttachments_CompanyTrips_Fk_CompanyTrip",
                table: "CompanyTripAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookingHistories_CompanyTripBookingStates_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookingHistories_CompanyTripBookings_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookings_CompanyTripBookingStates_Fk_CompanyTripBookingState",
                table: "CompanyTripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripBookingStateLang_CompanyTripBookingStates_Fk_Source",
                table: "CompanyTripBookingStateLang");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTrips_CompanyTripStates_Fk_CompanyTripState",
                table: "CompanyTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTripStateLang_CompanyTripStates_Fk_Source",
                table: "CompanyTripStateLang");

            migrationBuilder.DropTable(
                name: "CarCategoryLang");

            migrationBuilder.DropTable(
                name: "CarClassLang");

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
                name: "TripHistories");

            migrationBuilder.DropTable(
                name: "TripPoints");

            migrationBuilder.DropTable(
                name: "TripStateLang");

            migrationBuilder.DropTable(
                name: "HotelFeatures");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "HotelFeatureCategories");

            migrationBuilder.DropTable(
                name: "CarClasses");

            migrationBuilder.DropTable(
                name: "TripStates");

            migrationBuilder.DropTable(
                name: "CarCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripStates",
                table: "CompanyTripStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripBookingStates",
                table: "CompanyTripBookingStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripBookingHistories",
                table: "CompanyTripBookingHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTripAttachments",
                table: "CompanyTripAttachments");

            migrationBuilder.RenameTable(
                name: "CompanyTripStates",
                newName: "CompanyTripState");

            migrationBuilder.RenameTable(
                name: "CompanyTripBookingStates",
                newName: "CompanyTripBookingState");

            migrationBuilder.RenameTable(
                name: "CompanyTripBookingHistories",
                newName: "CompanyTripBookingHistory");

            migrationBuilder.RenameTable(
                name: "CompanyTripAttachments",
                newName: "CompanyTripAttachment");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripStates_Name",
                table: "CompanyTripState",
                newName: "IX_CompanyTripState_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripBookingStates_Name",
                table: "CompanyTripBookingState",
                newName: "IX_CompanyTripBookingState_Name");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripBookingHistories_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistory",
                newName: "IX_CompanyTripBookingHistory_Fk_CompanyTripBookingState");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripBookingHistories_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistory",
                newName: "IX_CompanyTripBookingHistory_Fk_CompanyTripBooking");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTripAttachments_Fk_CompanyTrip",
                table: "CompanyTripAttachment",
                newName: "IX_CompanyTripAttachment_Fk_CompanyTrip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripState",
                table: "CompanyTripState",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripBookingState",
                table: "CompanyTripBookingState",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripBookingHistory",
                table: "CompanyTripBookingHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTripAttachment",
                table: "CompanyTripAttachment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "DashboardAccessLevelLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAccessLevelLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAccessLevelLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrators",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fk_DashboardAdministrationRole", "Fk_User" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 21,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 22,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 23,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 24,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$7bvpP6TQVDuI5FfnBYG.kOLDFltEX61F5eZ7IhDsh7hbSybu8ev/m");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripAttachment_CompanyTrips_Fk_CompanyTrip",
                table: "CompanyTripAttachment",
                column: "Fk_CompanyTrip",
                principalTable: "CompanyTrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookingHistory_CompanyTripBookingState_Fk_CompanyTripBookingState",
                table: "CompanyTripBookingHistory",
                column: "Fk_CompanyTripBookingState",
                principalTable: "CompanyTripBookingState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookingHistory_CompanyTripBookings_Fk_CompanyTripBooking",
                table: "CompanyTripBookingHistory",
                column: "Fk_CompanyTripBooking",
                principalTable: "CompanyTripBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookings_CompanyTripBookingState_Fk_CompanyTripBookingState",
                table: "CompanyTripBookings",
                column: "Fk_CompanyTripBookingState",
                principalTable: "CompanyTripBookingState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripBookingStateLang_CompanyTripBookingState_Fk_Source",
                table: "CompanyTripBookingStateLang",
                column: "Fk_Source",
                principalTable: "CompanyTripBookingState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTrips_CompanyTripState_Fk_CompanyTripState",
                table: "CompanyTrips",
                column: "Fk_CompanyTripState",
                principalTable: "CompanyTripState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTripStateLang_CompanyTripState_Fk_Source",
                table: "CompanyTripStateLang",
                column: "Fk_Source",
                principalTable: "CompanyTripState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
