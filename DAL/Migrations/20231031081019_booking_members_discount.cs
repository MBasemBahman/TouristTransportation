using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class bookingmembersdiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MembersDiscount",
                table: "CompanyTripBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
            
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$YidDGlMhbK7Z7mhFVVFZ7OK/hRJ8hbQPpGPfAPKNK0FLgTYvCbXCi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembersDiscount",
                table: "CompanyTripBookings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$vTG4Cq3Dbk2rU/n73gpJiOcejCkwja5vkJpZUEMyCRmKUdW4R0cSK");
        }
    }
}
