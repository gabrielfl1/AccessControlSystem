using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Server.Migrations
{
    /// <inheritdoc />
    public partial class subindoobancocomdados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessRules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRules", x => x.Id);
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
                    Status = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Schedules", x => x.Id);
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
                name: "DeviceAccessRules",
                columns: table => new
                {
                    AccessRuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceAccessRules", x => new { x.AccessRuleId, x.DeviceId });
                    table.ForeignKey(
                        name: "FK_AccessRuleDevice_AccessRuleId",
                        column: x => x.AccessRuleId,
                        principalTable: "AccessRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRuleDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleAccessRules",
                columns: table => new
                {
                    AccessRuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    ScheduleId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAccessRules", x => new { x.AccessRuleId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_AccessRuleSchedule_AccessRuleId",
                        column: x => x.AccessRuleId,
                        principalTable: "AccessRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRuleSchedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessRules",
                columns: table => new
                {
                    AccessRuleId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessRules", x => new { x.AccessRuleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AccessRuleUser_AccessRuleId",
                        column: x => x.AccessRuleId,
                        principalTable: "AccessRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessRuleUser_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccessRules",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Regra padrão" });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "FridayEnd", "FridayStart", "MondayEnd", "MondayStart", "Name", "SaturdayEnd", "SaturdayStart", "SundayEnd", "SundayStart", "ThursdayEnd", "ThursdayStart", "TuesdayEnd", "TuesdayStart", "WednesdayEnd", "WednesdayStart" },
                values: new object[] { 1L, 86400, 0, 86400, 0, "Full Access", 86400, 0, 86400, 0, 86400, 0, 86400, 0, 86400, 0 });

            migrationBuilder.InsertData(
                table: "ScheduleAccessRules",
                columns: new[] { "AccessRuleId", "ScheduleId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceAccessRules_DeviceId",
                table: "DeviceAccessRules",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAccessRules_ScheduleId",
                table: "ScheduleAccessRules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessRules_UserId",
                table: "UserAccessRules",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceAccessRules");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ScheduleAccessRules");

            migrationBuilder.DropTable(
                name: "UserAccessRules");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "AccessRules");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
