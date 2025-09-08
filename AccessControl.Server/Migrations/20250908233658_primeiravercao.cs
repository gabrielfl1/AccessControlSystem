using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Server.Migrations
{
    /// <inheritdoc />
    public partial class primeiravercao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessRule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ip = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Login = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Serial = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<long>(type: "INTEGER", nullable: false),
                    IdDevice = table.Column<long>(type: "INTEGER", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MondayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    MondayEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    TuesdayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    TuesdayEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    WednesdayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    WednesdayEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    ThursdayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    ThursdayEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    FridayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    FridayEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    SaturdayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    SaturdayEnd = table.Column<int>(type: "INTEGER", nullable: false),
                    SundayStart = table.Column<int>(type: "INTEGER", nullable: false),
                    SundayEnd = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateStartLimit = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateEndLimit = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataLastLog = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Pin = table.Column<uint>(type: "INTEGER", nullable: true),
                    Card = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessRuleDevice",
                columns: table => new
                {
                    AccessRulesId = table.Column<long>(type: "INTEGER", nullable: false),
                    DevicesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRuleDevice", x => new { x.AccessRulesId, x.DevicesId });
                    table.ForeignKey(
                        name: "FK_AccessRuleDevice_AccessRule_AccessRulesId",
                        column: x => x.AccessRulesId,
                        principalTable: "AccessRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRuleDevice_Devices_DevicesId",
                        column: x => x.DevicesId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessRuleSchedule",
                columns: table => new
                {
                    AccessRulesId = table.Column<long>(type: "INTEGER", nullable: false),
                    SchedulesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRuleSchedule", x => new { x.AccessRulesId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_AccessRuleSchedule_AccessRule_AccessRulesId",
                        column: x => x.AccessRulesId,
                        principalTable: "AccessRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRuleSchedule_Schedule_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessRuleUser",
                columns: table => new
                {
                    AccessRulesId = table.Column<long>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRuleUser", x => new { x.AccessRulesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AccessRuleUser_AccessRule_AccessRulesId",
                        column: x => x.AccessRulesId,
                        principalTable: "AccessRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRuleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessRuleDevice_DevicesId",
                table: "AccessRuleDevice",
                column: "DevicesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessRuleSchedule_SchedulesId",
                table: "AccessRuleSchedule",
                column: "SchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessRuleUser_UsersId",
                table: "AccessRuleUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessRuleDevice");

            migrationBuilder.DropTable(
                name: "AccessRuleSchedule");

            migrationBuilder.DropTable(
                name: "AccessRuleUser");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "AccessRule");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
