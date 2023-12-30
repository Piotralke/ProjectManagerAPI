using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Groups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "subjectUuid",
                table: "Projects",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    groupUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    userUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_GroupMembers_AspNetUsers_userUuid",
                        column: x => x.userUuid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Group_groupUuid",
                        column: x => x.groupUuid,
                        principalTable: "Group",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    teacherUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    requirements = table.Column<string>(type: "text", nullable: false),
                    groupUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Subject_AspNetUsers_teacherUuid",
                        column: x => x.teacherUuid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subject_Group_groupUuid",
                        column: x => x.groupUuid,
                        principalTable: "Group",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProposal",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    subjectUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProposal", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_ProjectProposal_Subject_subjectUuid",
                        column: x => x.subjectUuid,
                        principalTable: "Subject",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposalSquad",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    projectProposalUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    userUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalSquad", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_ProposalSquad_AspNetUsers_userUuid",
                        column: x => x.userUuid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProposalSquad_ProjectProposal_projectProposalUuid",
                        column: x => x.projectProposalUuid,
                        principalTable: "ProjectProposal",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_groupUuid",
                table: "GroupMembers",
                column: "groupUuid");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_userUuid",
                table: "GroupMembers",
                column: "userUuid");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProposal_subjectUuid",
                table: "ProjectProposal",
                column: "subjectUuid");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalSquad_projectProposalUuid",
                table: "ProposalSquad",
                column: "projectProposalUuid");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalSquad_userUuid",
                table: "ProposalSquad",
                column: "userUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_groupUuid",
                table: "Subject",
                column: "groupUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_teacherUuid",
                table: "Subject",
                column: "teacherUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "ProposalSquad");

            migrationBuilder.DropTable(
                name: "ProjectProposal");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropColumn(
                name: "subjectUuid",
                table: "Projects");
        }
    }
}
