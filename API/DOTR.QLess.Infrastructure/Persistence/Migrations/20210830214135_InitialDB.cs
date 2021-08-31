using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOTR.QLess.Infrastructure.Persistence.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsLocalNetworkUser = table.Column<bool>(type: "bit", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: true),
                    CustomerUniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByAppUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedByAppUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ForgotPasswordUrlParam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForgotPasswordExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_CreatedByAppUserId",
                        column: x => x.CreatedByAppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId");
                    table.ForeignKey(
                        name: "FK_AppUsers_AppUsers_LastModifiedByAppUserId",
                        column: x => x.LastModifiedByAppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId");
                });

            migrationBuilder.CreateTable(
                name: "TicketNumberSeeder",
                columns: table => new
                {
                    TicketNumberSeederId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    SeedValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketNumberSeeder", x => x.TicketNumberSeederId);
                });

            migrationBuilder.CreateTable(
                name: "TicketTypes",
                columns: table => new
                {
                    TicketTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialLoad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedByAppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByAppUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTypes", x => x.TicketTypeId);
                    table.ForeignKey(
                        name: "FK_TicketTypes_AppUsers_CreatedByAppUserId",
                        column: x => x.CreatedByAppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTypes_AppUsers_LastModifiedByAppUserId",
                        column: x => x.LastModifiedByAppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketTypeId = table.Column<int>(type: "int", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUsedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByAppUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByAppUserId = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_AppUsers_CreatedByAppUserId",
                        column: x => x.CreatedByAppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_AppUsers_LastModifiedByAppUserId",
                        column: x => x.LastModifiedByAppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "AppUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketTypes_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketTypes",
                        principalColumn: "TicketTypeId");
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "CreatedByAppUserId", "CreatedDate", "CustomerUniqueId", "Email", "FirstName", "ForgotPasswordExpiryDate", "ForgotPasswordUrlParam", "IsActivated", "IsActive", "IsLocalNetworkUser", "LastModifiedByAppUserId", "LastModifiedDate", "LastName", "MiddleName", "PasswordHash", "PasswordSalt", "Qualifier", "Username" },
                values: new object[] { 1, null, new DateTime(2021, 8, 31, 5, 41, 34, 680, DateTimeKind.Local).AddTicks(8492), new Guid("8f563b98-6f6b-4579-b386-b8096b0adbbd"), null, null, null, null, null, true, null, null, null, null, null, "A553D8120F09422C8A640176970D7FB5767BB6EE31414146838873B4F9460554E5AD7B29FA70504EF322CAC81AF52A86CE82886B07E343FD5C6D13056506CABE", "F6B8AFAE8D503045BBD69ADA97CD46E9BD465570B261673BE60EA5AE801E82492D07A6784EABEC7FECE2D65B51881374F7E681B271AD6400FACCD57C145EB14F", null, "sys.default" });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "TicketTypeId", "CreatedByAppUserId", "CreatedDate", "FixRate", "InitialLoad", "IsActive", "LastModifiedByAppUserId", "LastModifiedDate", "Name" },
                values: new object[] { 1, 1, new DateTime(2021, 8, 31, 5, 41, 34, 682, DateTimeKind.Local).AddTicks(9639), 15m, 100m, true, null, null, "Regular" });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "TicketTypeId", "CreatedByAppUserId", "CreatedDate", "FixRate", "InitialLoad", "IsActive", "LastModifiedByAppUserId", "LastModifiedDate", "Name" },
                values: new object[] { 2, 1, new DateTime(2021, 8, 31, 5, 41, 34, 683, DateTimeKind.Local).AddTicks(448), 10m, 500m, true, null, null, "Discounted" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CreatedByAppUserId",
                table: "AppUsers",
                column: "CreatedByAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_LastModifiedByAppUserId",
                table: "AppUsers",
                column: "LastModifiedByAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Username",
                table: "AppUsers",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedByAppUserId",
                table: "Tickets",
                column: "CreatedByAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_LastModifiedByAppUserId",
                table: "Tickets",
                column: "LastModifiedByAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketNumber",
                table: "Tickets",
                column: "TicketNumber",
                unique: true,
                filter: "[TicketNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_CreatedByAppUserId",
                table: "TicketTypes",
                column: "CreatedByAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketTypes_LastModifiedByAppUserId",
                table: "TicketTypes",
                column: "LastModifiedByAppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketNumberSeeder");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketTypes");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
