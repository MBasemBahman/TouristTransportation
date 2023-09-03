using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class removephoneemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
