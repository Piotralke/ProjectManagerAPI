using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SubjectRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Groups_groupUuid",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_groupUuid",
                table: "Subjects");

            migrationBuilder.CreateTable(
                name: "GroupSubjects",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    groupUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    subjectUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSubjects", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_GroupSubjects_Groups_groupUuid",
                        column: x => x.groupUuid,
                        principalTable: "Groups",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSubjects_Subjects_subjectUuid",
                        column: x => x.subjectUuid,
                        principalTable: "Subjects",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupSubjects_groupUuid",
                table: "GroupSubjects",
                column: "groupUuid");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSubjects_subjectUuid",
                table: "GroupSubjects",
                column: "subjectUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_groupUuid",
                table: "Subjects",
                column: "groupUuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Groups_groupUuid",
                table: "Subjects",
                column: "groupUuid",
                principalTable: "Groups",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
