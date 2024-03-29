using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Notifying.API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    AttachedFiles_JsonData = table.Column<string>(type: "TEXT", nullable: true),
                    TimeOfSending = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NotificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSent = table.Column<bool>(type: "INTEGER", nullable: false),
                    TimeOfReading = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipients_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "AttachedFiles_JsonData", "Body", "TimeOfSending", "Title" },
                values: new object[,]
                {
                    { 1, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body1", new DateTime(2024, 1, 18, 16, 22, 4, 361, DateTimeKind.Local).AddTicks(2963), "Title1" },
                    { 2, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body2", new DateTime(2024, 1, 18, 16, 15, 4, 361, DateTimeKind.Local).AddTicks(3046), "Title2" },
                    { 3, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body3", new DateTime(2024, 1, 18, 17, 25, 4, 361, DateTimeKind.Local).AddTicks(3052), "Title3" },
                    { 4, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body4", new DateTime(2024, 1, 18, 17, 16, 4, 361, DateTimeKind.Local).AddTicks(3056), "Title4" },
                    { 5, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body5", new DateTime(2024, 1, 18, 17, 36, 4, 361, DateTimeKind.Local).AddTicks(3061), "Title5" },
                    { 6, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body6", new DateTime(2024, 1, 18, 16, 38, 4, 361, DateTimeKind.Local).AddTicks(3065), "Title6" },
                    { 7, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body7", new DateTime(2024, 1, 18, 17, 21, 4, 361, DateTimeKind.Local).AddTicks(3070), "Title7" },
                    { 8, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body8", new DateTime(2024, 1, 18, 17, 44, 4, 361, DateTimeKind.Local).AddTicks(3075), "Title8" },
                    { 9, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body9", new DateTime(2024, 1, 18, 16, 18, 4, 361, DateTimeKind.Local).AddTicks(3148), "Title9" },
                    { 10, "[\"https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png\"]", "Body10", new DateTime(2024, 1, 18, 16, 53, 4, 361, DateTimeKind.Local).AddTicks(3154), "Title10" }
                });

            migrationBuilder.InsertData(
                table: "Recipients",
                columns: new[] { "Id", "IsSent", "NotificationId", "TimeOfReading", "UserId" },
                values: new object[,]
                {
                    { 1, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, false, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_NotificationId",
                table: "Recipients",
                column: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}