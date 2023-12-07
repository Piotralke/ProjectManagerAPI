using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_pinnedProjectUuid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "pinnedProjectUuid",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_pinnedProjectUuid",
                table: "AspNetUsers",
                column: "pinnedProjectUuid",
                principalTable: "Projects",
                principalColumn: "uuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_pinnedProjectUuid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "pinnedProjectUuid",
                table: "AspNetUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_pinnedProjectUuid",
                table: "AspNetUsers",
                column: "pinnedProjectUuid",
                principalTable: "Projects",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
