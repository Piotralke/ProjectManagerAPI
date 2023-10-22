using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    memberOneUuid = table.Column<Guid>(type: "uuid", nullable: true),
                    memberTwoUuid = table.Column<Guid>(type: "uuid", nullable: true),
                    isGroupChat = table.Column<bool>(type: "boolean", nullable: false),
                    projectUuid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Chat_Projects_projectUuid",
                        column: x => x.projectUuid,
                        principalTable: "Projects",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_Chat_Users_memberOneUuid",
                        column: x => x.memberOneUuid,
                        principalTable: "Users",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_Chat_Users_memberTwoUuid",
                        column: x => x.memberTwoUuid,
                        principalTable: "Users",
                        principalColumn: "uuid");
                });

            migrationBuilder.CreateTable(
                name: "GanntTasks",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    howLong = table.Column<long>(type: "bigint", nullable: false),
                    startDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    projectUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GanntTasks", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_GanntTasks_Projects_projectUuid",
                        column: x => x.projectUuid,
                        principalTable: "Projects",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    hasAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    chatUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    senderUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Useruuid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Message_Chat_chatUuid",
                        column: x => x.chatUuid,
                        principalTable: "Chat",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_Users_Useruuid",
                        column: x => x.Useruuid,
                        principalTable: "Users",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_Message_Users_senderUuid",
                        column: x => x.senderUuid,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageAttachment",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    fileName = table.Column<string>(type: "text", nullable: false),
                    fileType = table.Column<string>(type: "text", nullable: false),
                    filePath = table.Column<string>(type: "text", nullable: false),
                    messageUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageAttachment", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_MessageAttachment_Message_messageUuid",
                        column: x => x.messageUuid,
                        principalTable: "Message",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_memberOneUuid",
                table: "Chat",
                column: "memberOneUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chat_memberTwoUuid",
                table: "Chat",
                column: "memberTwoUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chat_projectUuid",
                table: "Chat",
                column: "projectUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GanntTasks_projectUuid",
                table: "GanntTasks",
                column: "projectUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Message_chatUuid",
                table: "Message",
                column: "chatUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Message_senderUuid",
                table: "Message",
                column: "senderUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_Useruuid",
                table: "Message",
                column: "Useruuid");

            migrationBuilder.CreateIndex(
                name: "IX_MessageAttachment_messageUuid",
                table: "MessageAttachment",
                column: "messageUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GanntTasks");

            migrationBuilder.DropTable(
                name: "MessageAttachment");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Chat");
        }
    }
}
