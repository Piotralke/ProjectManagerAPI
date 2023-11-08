using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChatChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chats_chatUuid",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_Useruuid",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_senderUuid",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageAttachment_Message_messageUuid",
                table: "MessageAttachment");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageAttachment",
                table: "MessageAttachment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "MessageAttachment",
                newName: "MessageAttachments");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_MessageAttachment_messageUuid",
                table: "MessageAttachments",
                newName: "IX_MessageAttachments_messageUuid");

            migrationBuilder.RenameColumn(
                name: "chatUuid",
                table: "Messages",
                newName: "projectUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Message_Useruuid",
                table: "Messages",
                newName: "IX_Messages_Useruuid");

            migrationBuilder.RenameIndex(
                name: "IX_Message_senderUuid",
                table: "Messages",
                newName: "IX_Messages_senderUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Message_chatUuid",
                table: "Messages",
                newName: "IX_Messages_projectUuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageAttachments",
                table: "MessageAttachments",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageAttachments_Messages_messageUuid",
                table: "MessageAttachments",
                column: "messageUuid",
                principalTable: "Messages",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Projects_projectUuid",
                table: "Messages",
                column: "projectUuid",
                principalTable: "Projects",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_Useruuid",
                table: "Messages",
                column: "Useruuid",
                principalTable: "Users",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_senderUuid",
                table: "Messages",
                column: "senderUuid",
                principalTable: "Users",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageAttachments_Messages_messageUuid",
                table: "MessageAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Projects_projectUuid",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_Useruuid",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_senderUuid",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageAttachments",
                table: "MessageAttachments");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "MessageAttachments",
                newName: "MessageAttachment");

            migrationBuilder.RenameColumn(
                name: "projectUuid",
                table: "Message",
                newName: "chatUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_Useruuid",
                table: "Message",
                newName: "IX_Message_Useruuid");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_senderUuid",
                table: "Message",
                newName: "IX_Message_senderUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_projectUuid",
                table: "Message",
                newName: "IX_Message_chatUuid");

            migrationBuilder.RenameIndex(
                name: "IX_MessageAttachments_messageUuid",
                table: "MessageAttachment",
                newName: "IX_MessageAttachment_messageUuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageAttachment",
                table: "MessageAttachment",
                column: "uuid");

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    memberOneUuid = table.Column<Guid>(type: "uuid", nullable: true),
                    memberTwoUuid = table.Column<Guid>(type: "uuid", nullable: true),
                    projectUuid = table.Column<Guid>(type: "uuid", nullable: true),
                    isGroupChat = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Chats_Projects_projectUuid",
                        column: x => x.projectUuid,
                        principalTable: "Projects",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_Chats_Users_memberOneUuid",
                        column: x => x.memberOneUuid,
                        principalTable: "Users",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_Chats_Users_memberTwoUuid",
                        column: x => x.memberTwoUuid,
                        principalTable: "Users",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_memberOneUuid",
                table: "Chats",
                column: "memberOneUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_memberTwoUuid",
                table: "Chats",
                column: "memberTwoUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_projectUuid",
                table: "Chats",
                column: "projectUuid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chats_chatUuid",
                table: "Message",
                column: "chatUuid",
                principalTable: "Chats",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_Useruuid",
                table: "Message",
                column: "Useruuid",
                principalTable: "Users",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_senderUuid",
                table: "Message",
                column: "senderUuid",
                principalTable: "Users",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageAttachment_Message_messageUuid",
                table: "MessageAttachment",
                column: "messageUuid",
                principalTable: "Message",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
