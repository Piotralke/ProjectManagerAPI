using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gitLink = table.Column<string>(type: "text", nullable: false),
                    isPrivate = table.Column<bool>(type: "boolean", nullable: false),
                    ownerUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Projects_Users_ownerUuid",
                        column: x => x.ownerUuid,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEvents",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    dueTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    startTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    projectUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEvents", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_ProjectEvents_Projects_projectUuid",
                        column: x => x.projectUuid,
                        principalTable: "Projects",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMembers",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    projectUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    userUuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMembers", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_ProjectMembers_Projects_projectUuid",
                        column: x => x.projectUuid,
                        principalTable: "Projects",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMembers_Users_userUuid",
                        column: x => x.userUuid,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    eventUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    userUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserEventsuuid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_UserEvents_ProjectEvents_eventUuid",
                        column: x => x.eventUuid,
                        principalTable: "ProjectEvents",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvents_UserEvents_UserEventsuuid",
                        column: x => x.UserEventsuuid,
                        principalTable: "UserEvents",
                        principalColumn: "uuid");
                    table.ForeignKey(
                        name: "FK_UserEvents_Users_userUuid",
                        column: x => x.userUuid,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEvents_projectUuid",
                table: "ProjectEvents",
                column: "projectUuid");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_projectUuid",
                table: "ProjectMembers",
                column: "projectUuid");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMembers_userUuid",
                table: "ProjectMembers",
                column: "userUuid");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ownerUuid",
                table: "Projects",
                column: "ownerUuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_eventUuid",
                table: "UserEvents",
                column: "eventUuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_UserEventsuuid",
                table: "UserEvents",
                column: "UserEventsuuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_userUuid",
                table: "UserEvents",
                column: "userUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectMembers");

            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "ProjectEvents");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
