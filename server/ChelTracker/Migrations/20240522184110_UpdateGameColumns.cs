using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChelTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2507e3d2-75f1-424f-8aeb-808e8992cfb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e2ea7c5-0a63-42df-be76-80be35716bef");

            migrationBuilder.AddColumn<int>(
                name: "OpponentFaceOffWins",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "OpponentPassingPercentage",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "OpponentPenaltyMinutes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpponentPowerPlayMinutes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "OpponentPowerPlayPercentage",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "OpponentShortHandedGoals",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpponentTimeOnAttack",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserFaceOffWins",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "UserPassingPercentage",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "UserPenaltyMinutes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserPowerPlayMinutes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "UserPowerPlayPercentage",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "UserShortHandedGoals",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserTimeOnAttack",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f6f1b4d-448a-4279-b5bb-ece4e45f5667", null, "Admin", "ADMIN" },
                    { "9dce9eb2-4625-4a23-add0-5d1626d901af", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f6f1b4d-448a-4279-b5bb-ece4e45f5667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dce9eb2-4625-4a23-add0-5d1626d901af");

            migrationBuilder.DropColumn(
                name: "OpponentFaceOffWins",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OpponentPassingPercentage",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OpponentPenaltyMinutes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OpponentPowerPlayMinutes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OpponentPowerPlayPercentage",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OpponentShortHandedGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "OpponentTimeOnAttack",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserFaceOffWins",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserPassingPercentage",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserPenaltyMinutes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserPowerPlayMinutes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserPowerPlayPercentage",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserShortHandedGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserTimeOnAttack",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2507e3d2-75f1-424f-8aeb-808e8992cfb2", null, "User", "USER" },
                    { "2e2ea7c5-0a63-42df-be76-80be35716bef", null, "Admin", "ADMIN" }
                });
        }
    }
}
