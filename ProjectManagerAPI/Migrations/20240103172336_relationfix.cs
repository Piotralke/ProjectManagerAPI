using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class relationfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_groupSubjectUuid",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_groupSubjectUuid",
                table: "Projects",
                column: "groupSubjectUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_groupSubjectUuid",
                table: "Projects");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_groupSubjectUuid",
                table: "Projects",
                column: "groupSubjectUuid",
                unique: true);
        }
    }
}
