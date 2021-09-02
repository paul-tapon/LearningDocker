using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOTR.QLess.Infrastructure.Persistence.Migrations
{
    public partial class InitialDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpirationInMonths",
                table: "TicketTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2021, 9, 1, 2, 32, 14, 100, DateTimeKind.Local).AddTicks(6390), "C18EB64337F215B3FD54A7EC73CBCE6BAAA2AF0F2F7BB8F68F311C2274EB903628AC26149CF94BC310624F1FE9C2B18FF718F121755273995D4574E9BF2D2464", "811439E1442F7FD2F5B3E28410EC984094EB8036C7C3781973B56E0C7020EBF076DB83CD8BDE2D9EA2838361259FB7489B6779B6310EDBCAB2958896B7AC6BFC" });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "TicketTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ExpirationInMonths" },
                values: new object[] { new DateTime(2021, 9, 1, 2, 32, 14, 111, DateTimeKind.Local).AddTicks(5570), 60 });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "TicketTypeId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ExpirationInMonths" },
                values: new object[] { new DateTime(2021, 9, 1, 2, 32, 14, 111, DateTimeKind.Local).AddTicks(6610), 36 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationInMonths",
                table: "TicketTypes");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "AppUserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2021, 8, 31, 5, 41, 34, 680, DateTimeKind.Local).AddTicks(8492), "A553D8120F09422C8A640176970D7FB5767BB6EE31414146838873B4F9460554E5AD7B29FA70504EF322CAC81AF52A86CE82886B07E343FD5C6D13056506CABE", "F6B8AFAE8D503045BBD69ADA97CD46E9BD465570B261673BE60EA5AE801E82492D07A6784EABEC7FECE2D65B51881374F7E681B271AD6400FACCD57C145EB14F" });

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "TicketTypeId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 31, 5, 41, 34, 682, DateTimeKind.Local).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "TicketTypes",
                keyColumn: "TicketTypeId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 8, 31, 5, 41, 34, 683, DateTimeKind.Local).AddTicks(448));
        }
    }
}
