using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class usereventfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEvents_UserEvents_UserEventsuuid",
                table: "UserEvents");

            migrationBuilder.DropIndex(
                name: "IX_UserEvents_UserEventsuuid",
                table: "UserEvents");

            migrationBuilder.DropColumn(
                name: "UserEventsuuid",
                table: "UserEvents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserEventsuuid",
                table: "UserEvents",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_UserEventsuuid",
                table: "UserEvents",
                column: "UserEventsuuid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_UserEvents_UserEventsuuid",
                table: "UserEvents",
                column: "UserEventsuuid",
                principalTable: "UserEvents",
                principalColumn: "uuid");
        }
    }
}
