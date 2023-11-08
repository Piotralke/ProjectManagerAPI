using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Projects_projectUuid",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Users_memberOneUuid",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Users_memberTwoUuid",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chat_chatUuid",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_projectUuid",
                table: "Chats",
                newName: "IX_Chats_projectUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_memberTwoUuid",
                table: "Chats",
                newName: "IX_Chats_memberTwoUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_memberOneUuid",
                table: "Chats",
                newName: "IX_Chats_memberOneUuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Projects_projectUuid",
                table: "Chats",
                column: "projectUuid",
                principalTable: "Projects",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_memberOneUuid",
                table: "Chats",
                column: "memberOneUuid",
                principalTable: "Users",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_memberTwoUuid",
                table: "Chats",
                column: "memberTwoUuid",
                principalTable: "Users",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chats_chatUuid",
                table: "Message",
                column: "chatUuid",
                principalTable: "Chats",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Projects_projectUuid",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_memberOneUuid",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_memberTwoUuid",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chats_chatUuid",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_projectUuid",
                table: "Chat",
                newName: "IX_Chat_projectUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_memberTwoUuid",
                table: "Chat",
                newName: "IX_Chat_memberTwoUuid");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_memberOneUuid",
                table: "Chat",
                newName: "IX_Chat_memberOneUuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Projects_projectUuid",
                table: "Chat",
                column: "projectUuid",
                principalTable: "Projects",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users_memberOneUuid",
                table: "Chat",
                column: "memberOneUuid",
                principalTable: "Users",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Users_memberTwoUuid",
                table: "Chat",
                column: "memberTwoUuid",
                principalTable: "Users",
                principalColumn: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chat_chatUuid",
                table: "Message",
                column: "chatUuid",
                principalTable: "Chat",
                principalColumn: "uuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
