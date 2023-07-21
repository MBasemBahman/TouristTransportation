using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class ffhfhfcbcv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "DashboardViews",
                columns: new[] { "Id", "ColorCode", "Name", "ViewPath" },
                values: new object[,]
                {
                    { 14, null, "AccountState", "AccountState" },
                    { 15, null, "AccountType", "AccountType" },
                    { 16, null, "Area", "Area" },
                    { 17, null, "Country", "Country" },
                    { 18, null, "Currency", "Currency" },
                    { 19, null, "Supplier", "Supplier" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$rr.zNNP4uKcbN8pU7w/XuuLeOmKyFPvgCEenVkBa4koEIC.b8iFXi");

            migrationBuilder.InsertData(
                table: "AdministrationRolePremissions",
                columns: new[] { "Id", "Fk_DashboardAccessLevel", "Fk_DashboardAdministrationRole", "Fk_DashboardView" },
                values: new object[,]
                {
                    { 14, 1, 1, 14 },
                    { 15, 1, 1, 15 },
                    { 16, 1, 1, 16 },
                    { 17, 1, 1, 17 },
                    { 18, 1, 1, 18 },
                    { 19, 1, 1, 19 }
                });

            migrationBuilder.InsertData(
                table: "DashboardViewLang",
                columns: new[] { "Id", "Fk_Source", "Name" },
                values: new object[,]
                {
                    { 14, 14, "AccountState" },
                    { 15, 15, "AccountType" },
                    { 16, 16, "Area" },
                    { 17, 17, "Country" },
                    { 18, 18, "Currency" },
                    { 19, 19, "Supplier" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AdministrationRolePremissions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DashboardViewLang",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DashboardViews",
                keyColumn: "Id",
                keyValue: 19);

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$uMnuoXn7fqrPSY5DhilQ1OPvvKb9HLalz6lN8GufFgGK6/PPRvUWS");
        }
    }
}
