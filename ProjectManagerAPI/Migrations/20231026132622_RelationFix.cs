using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ownerUuid",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ownerUuid",
                table: "Projects",
                column: "ownerUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ownerUuid",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ownerUuid",
                table: "Projects",
                column: "ownerUuid",
                unique: true);
        }
    }
}
