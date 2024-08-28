using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamLeagueRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LeagueId" },
                values: new object[] { new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LeagueId" },
                values: new object[] { new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LeagueId" },
                values: new object[] { new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId",
                table: "Teams");

            migrationBuilder.AlterColumn<int>(
                name: "LeagueId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LeagueId" },
                values: new object[] { new DateTime(2024, 8, 25, 19, 23, 30, 285, DateTimeKind.Unspecified).AddTicks(7711), 0 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LeagueId" },
                values: new object[] { new DateTime(2024, 8, 25, 19, 23, 30, 285, DateTimeKind.Unspecified).AddTicks(7747), 0 });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LeagueId" },
                values: new object[] { new DateTime(2024, 8, 25, 19, 23, 30, 285, DateTimeKind.Unspecified).AddTicks(7748), 0 });
        }
    }
}
