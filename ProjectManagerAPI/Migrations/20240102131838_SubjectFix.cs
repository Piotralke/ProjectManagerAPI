using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SubjectFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Group_groupUuid",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProposal_Subject_subjectUuid",
                table: "ProjectProposal");

            migrationBuilder.DropForeignKey(
                name: "FK_ProposalSquad_AspNetUsers_userUuid",
                table: "ProposalSquad");

            migrationBuilder.DropForeignKey(
                name: "FK_ProposalSquad_ProjectProposal_projectProposalUuid",
                table: "ProposalSquad");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_teacherUuid",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Group_groupUuid",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProposalSquad",
                table: "ProposalSquad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProposal",
                table: "ProjectProposal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "ProposalSquad",
                newName: "ProposalSquads");

            migrationBuilder.RenameTable(
                name: "ProjectProposal",
                newName: "ProjectProposals");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_teacherUuid",
                table: "Subjects",
                newName: "IX_Subjects_teacherUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_groupUuid",
                table: "Subjects",
                newName: "IX_Subjects_groupUuid");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalSquad_userUuid",
                table: "ProposalSquads",
                newName: "IX_ProposalSquads_userUuid");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalSquad_projectProposalUuid",
                table: "ProposalSquads",
                newName: "IX_ProposalSquads_projectProposalUuid");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectProposal_subjectUuid",
                table: "ProjectProposals",
                newName: "IX_ProjectProposals_subjectUuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "cretedAt",
                table: "ProjectProposals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "editedAt",
                table: "ProjectProposals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProposalSquads",
                table: "ProposalSquads",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProposals",
                table: "ProjectProposals",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Groups_groupUuid",
                table: "GroupMembers",
                column: "groupUuid",
                principalTable: "Groups",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProposals_Subjects_subjectUuid",
                table: "ProjectProposals",
                column: "subjectUuid",
                principalTable: "Subjects",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalSquads_AspNetUsers_userUuid",
                table: "ProposalSquads",
                column: "userUuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalSquads_ProjectProposals_projectProposalUuid",
                table: "ProposalSquads",
                column: "projectProposalUuid",
                principalTable: "ProjectProposals",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AspNetUsers_teacherUuid",
                table: "Subjects",
                column: "teacherUuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Groups_groupUuid",
                table: "Subjects",
                column: "groupUuid",
                principalTable: "Groups",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_Groups_groupUuid",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProposals_Subjects_subjectUuid",
                table: "ProjectProposals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProposalSquads_AspNetUsers_userUuid",
                table: "ProposalSquads");

            migrationBuilder.DropForeignKey(
                name: "FK_ProposalSquads_ProjectProposals_projectProposalUuid",
                table: "ProposalSquads");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AspNetUsers_teacherUuid",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Groups_groupUuid",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProposalSquads",
                table: "ProposalSquads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProposals",
                table: "ProjectProposals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "cretedAt",
                table: "ProjectProposals");

            migrationBuilder.DropColumn(
                name: "editedAt",
                table: "ProjectProposals");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "ProposalSquads",
                newName: "ProposalSquad");

            migrationBuilder.RenameTable(
                name: "ProjectProposals",
                newName: "ProjectProposal");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_teacherUuid",
                table: "Subject",
                newName: "IX_Subject_teacherUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_groupUuid",
                table: "Subject",
                newName: "IX_Subject_groupUuid");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalSquads_userUuid",
                table: "ProposalSquad",
                newName: "IX_ProposalSquad_userUuid");

            migrationBuilder.RenameIndex(
                name: "IX_ProposalSquads_projectProposalUuid",
                table: "ProposalSquad",
                newName: "IX_ProposalSquad_projectProposalUuid");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectProposals_subjectUuid",
                table: "ProjectProposal",
                newName: "IX_ProjectProposal_subjectUuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProposalSquad",
                table: "ProposalSquad",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProposal",
                table: "ProjectProposal",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Group_groupUuid",
                table: "GroupMembers",
                column: "groupUuid",
                principalTable: "Group",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProposal_Subject_subjectUuid",
                table: "ProjectProposal",
                column: "subjectUuid",
                principalTable: "Subject",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalSquad_AspNetUsers_userUuid",
                table: "ProposalSquad",
                column: "userUuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalSquad_ProjectProposal_projectProposalUuid",
                table: "ProposalSquad",
                column: "projectProposalUuid",
                principalTable: "ProjectProposal",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_teacherUuid",
                table: "Subject",
                column: "teacherUuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Group_groupUuid",
                table: "Subject",
                column: "groupUuid",
                principalTable: "Group",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
