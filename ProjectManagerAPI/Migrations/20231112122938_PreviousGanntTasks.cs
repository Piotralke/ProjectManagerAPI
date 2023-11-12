using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class PreviousGanntTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GanntPrevviousTasks",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    taskId = table.Column<Guid>(type: "uuid", nullable: false),
                    previousTaskId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GanntPrevviousTasks", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_GanntPrevviousTasks_GanntTasks_previousTaskId",
                        column: x => x.previousTaskId,
                        principalTable: "GanntTasks",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GanntPrevviousTasks_GanntTasks_taskId",
                        column: x => x.taskId,
                        principalTable: "GanntTasks",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GanntPrevviousTasks_previousTaskId",
                table: "GanntPrevviousTasks",
                column: "previousTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_GanntPrevviousTasks_taskId",
                table: "GanntPrevviousTasks",
                column: "taskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GanntPrevviousTasks");
        }
    }
}
