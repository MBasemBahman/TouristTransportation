using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotelFeatureCategory",
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
                    table.PrimaryKey("PK_HotelFeatureCategory", x => x.Id);
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
                name: "HotelFeature",
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
                    table.PrimaryKey("PK_HotelFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFeature_HotelFeatureCategory_Fk_HotelFeatureCategory",
                        column: x => x.FkHotelFeatureCategory,
                        principalTable: "HotelFeatureCategory",
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
                        name: "FK_HotelFeatureCategoryLang_HotelFeatureCategory_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "HotelFeatureCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelAttachment",
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
                    table.PrimaryKey("PK_HotelAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelAttachment_Hotels_Fk_Hotel",
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
                        name: "FK_HotelFeatureLang_HotelFeature_Fk_Source",
                        column: x => x.FkSource,
                        principalTable: "HotelFeature",
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
                        name: "FK_HotelSelectedFeatures_HotelFeature_Fk_HotelFeature",
                        column: x => x.FkHotelFeature,
                        principalTable: "HotelFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelSelectedFeatures_Hotels_Fk_Hotel",
                        column: x => x.FkHotel,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelAttachment_Fk_Hotel",
                table: "HotelAttachment",
                column: "Fk_Hotel");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeature_Fk_HotelFeatureCategory",
                table: "HotelFeature",
                column: "Fk_HotelFeatureCategory");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeature_Name",
                table: "HotelFeature",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelFeatureCategory_Name",
                table: "HotelFeatureCategory",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelAttachment");

            migrationBuilder.DropTable(
                name: "HotelFeatureCategoryLang");

            migrationBuilder.DropTable(
                name: "HotelFeatureLang");

            migrationBuilder.DropTable(
                name: "HotelLang");

            migrationBuilder.DropTable(
                name: "HotelSelectedFeatures");

            migrationBuilder.DropTable(
                name: "HotelFeature");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "HotelFeatureCategory");
        }
    }
}
