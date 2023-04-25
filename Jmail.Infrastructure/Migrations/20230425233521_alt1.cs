using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jmail.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Messages_MessageId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Folders_FolderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FolderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_MessageId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FolderMessage",
                columns: table => new
                {
                    FoldersId = table.Column<int>(type: "int", nullable: false),
                    MessagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolderMessage", x => new { x.FoldersId, x.MessagesId });
                    table.ForeignKey(
                        name: "FK_FolderMessage_Folders_FoldersId",
                        column: x => x.FoldersId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FolderMessage_Messages_MessagesId",
                        column: x => x.MessagesId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AccountId",
                table: "Messages",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FolderMessage_MessagesId",
                table: "FolderMessage",
                column: "MessagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_AccountId",
                table: "Messages",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_AccountId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "FolderMessage");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AccountId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FolderId",
                table: "Messages",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MessageId",
                table: "Accounts",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Messages_MessageId",
                table: "Accounts",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Folders_FolderId",
                table: "Messages",
                column: "FolderId",
                principalTable: "Folders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
