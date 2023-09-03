using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class PointAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromAddress",
                table: "TripPoints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToAddress",
                table: "TripPoints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 3);

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
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 25 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 26 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 27 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 28 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 29 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 30 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 31 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 32 });

            migrationBuilder.UpdateData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[] { 1, 1, 33 });

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrators",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fk_DashboardAdministrationRole", "Fk_User" },
                values: new object[] { 1, 1 });

            //migrationBuilder.InsertData(
            //    table: "DashboardViews",
            //    columns: new[] { "Id", "ColorCode", "Name", "ViewPath" },
            //    values: new object[,]
            //    {
            //        { 34, null, "Trip", "Trip" },
            //        { 35, null, "TripPoint", "TripPoint" }
            //    });

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 21,
                column: "Fk_Source",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 22,
                column: "Fk_Source",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 23,
                column: "Fk_Source",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 24,
                column: "Fk_Source",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 25,
                column: "Fk_Source",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$iX.S3TiMjT9/swMVV0Hd9e2LfiWmFwULsD2SXSu96.I80FixnXfJS");

            //migrationBuilder.InsertData(
            //    table: "AdministrationRolePremissions",
            //    columns: new[] { "Id", "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[,]
            //    {
            //        { 34, 1, 1, 34 },
            //        { 35, 1, 1, 35 }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DropColumn(
                name: "FromAddress",
                table: "TripPoints");

            migrationBuilder.DropColumn(
                name: "ToAddress",
                table: "TripPoints");

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AccountTypeLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 0);

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 3,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 4,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 5,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 6,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 7,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 8,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 9,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 10,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 11,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 12,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 13,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 14,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 15,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 16,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 17,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 18,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 19,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 20,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 21,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 22,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 23,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 24,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 25,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 26,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 27,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 28,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 29,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 30,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 31,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 32,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            //migrationBuilder.UpdateData(
            //    table: "AdministrationRolePremissions",
            //    keyColumn: "Id",
            //    keyValue: 33,
            //    columns: new[] { "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
            //    values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripBookingStateLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CompanyTripStateLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrationRoleLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DashboardAdministrators",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fk_DashboardAdministrationRole", "Fk_User" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 4,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 5,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 7,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 8,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 9,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 10,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 11,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 12,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 13,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 14,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 15,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 16,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 17,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 18,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 19,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 20,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 21,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 22,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 23,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 24,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TripStateLang",
                keyColumn: "Id",
                keyValue: 25,
                column: "Fk_Source",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$xglm0gLtp32VnLt2cje0DeEhBsp/ISIglDWhKZkqg.6WYYerzVxHu");
        }
    }
}
