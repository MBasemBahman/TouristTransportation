using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class editattachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FileLength",
                table: "CompanyTripAttachments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CompanyTripAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "CompanyTripAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "CompanyTripAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageUrl",
                table: "CompanyTripAttachments",
                type: "nvarchar(max)",
                nullable: true);
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileLength",
                table: "CompanyTripAttachments");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CompanyTripAttachments");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "CompanyTripAttachments");

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "CompanyTripAttachments");

            migrationBuilder.DropColumn(
                name: "StorageUrl",
                table: "CompanyTripAttachments");
            
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$X7kHlHtht9ZNOg8VGEXo8ea6tJ0D5xiCYt8abAY7oYbQbRVqZCxlC");
        }
    }
}
