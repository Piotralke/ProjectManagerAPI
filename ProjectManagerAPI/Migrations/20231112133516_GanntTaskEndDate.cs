using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class GanntTaskEndDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GanntPrevviousTasks_GanntTasks_previousTaskId",
                table: "GanntPrevviousTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_GanntPrevviousTasks_GanntTasks_taskId",
                table: "GanntPrevviousTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GanntPrevviousTasks",
                table: "GanntPrevviousTasks");

            migrationBuilder.DropColumn(
                name: "howLong",
                table: "GanntTasks");

            migrationBuilder.RenameTable(
                name: "GanntPrevviousTasks",
                newName: "GanntPreviousTasks");

            migrationBuilder.RenameIndex(
                name: "IX_GanntPrevviousTasks_taskId",
                table: "GanntPreviousTasks",
                newName: "IX_GanntPreviousTasks_taskId");

            migrationBuilder.RenameIndex(
                name: "IX_GanntPrevviousTasks_previousTaskId",
                table: "GanntPreviousTasks",
                newName: "IX_GanntPreviousTasks_previousTaskId");

            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "GanntTasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GanntPreviousTasks",
                table: "GanntPreviousTasks",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_GanntPreviousTasks_GanntTasks_previousTaskId",
                table: "GanntPreviousTasks",
                column: "previousTaskId",
                principalTable: "GanntTasks",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GanntPreviousTasks_GanntTasks_taskId",
                table: "GanntPreviousTasks",
                column: "taskId",
                principalTable: "GanntTasks",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GanntPreviousTasks_GanntTasks_previousTaskId",
                table: "GanntPreviousTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_GanntPreviousTasks_GanntTasks_taskId",
                table: "GanntPreviousTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GanntPreviousTasks",
                table: "GanntPreviousTasks");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "GanntTasks");

            migrationBuilder.RenameTable(
                name: "GanntPreviousTasks",
                newName: "GanntPrevviousTasks");

            migrationBuilder.RenameIndex(
                name: "IX_GanntPreviousTasks_taskId",
                table: "GanntPrevviousTasks",
                newName: "IX_GanntPrevviousTasks_taskId");

            migrationBuilder.RenameIndex(
                name: "IX_GanntPreviousTasks_previousTaskId",
                table: "GanntPrevviousTasks",
                newName: "IX_GanntPrevviousTasks_previousTaskId");

            migrationBuilder.AddColumn<long>(
                name: "howLong",
                table: "GanntTasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GanntPrevviousTasks",
                table: "GanntPrevviousTasks",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_GanntPrevviousTasks_GanntTasks_previousTaskId",
                table: "GanntPrevviousTasks",
                column: "previousTaskId",
                principalTable: "GanntTasks",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GanntPrevviousTasks_GanntTasks_taskId",
                table: "GanntPrevviousTasks",
                column: "taskId",
                principalTable: "GanntTasks",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
