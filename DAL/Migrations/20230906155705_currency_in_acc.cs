using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class currencyinacc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_Currency",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Fk_Currency",
                table: "Accounts",
                column: "Fk_Currency");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_Fk_Currency",
                table: "Accounts",
                column: "Fk_Currency",
                principalTable: "Currencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_Fk_Currency",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Fk_Currency",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Fk_Currency",
                table: "Accounts");
        }
    }
}
