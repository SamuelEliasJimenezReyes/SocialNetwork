using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coments_Publications_PublicationsID",
                table: "Coments");

            migrationBuilder.DropIndex(
                name: "IX_Coments_PublicationsID",
                table: "Coments");

            migrationBuilder.DropColumn(
                name: "PublicationsID",
                table: "Coments");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Publications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Publications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PublicationID",
                table: "Coments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Coments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FriendsComents",
                columns: table => new
                {
                    ComentID = table.Column<int>(type: "int", nullable: false),
                    FriendID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsComents", x => new { x.ComentID, x.FriendID });
                    table.ForeignKey(
                        name: "FK_FriendsComents_Coments_ComentID",
                        column: x => x.ComentID,
                        principalTable: "Coments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendsComents_Friends_FriendID",
                        column: x => x.FriendID,
                        principalTable: "Friends",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coments_PublicationID",
                table: "Coments",
                column: "PublicationID");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsComents_FriendID",
                table: "FriendsComents",
                column: "FriendID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coments_Publications_PublicationID",
                table: "Coments",
                column: "PublicationID",
                principalTable: "Publications",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coments_Publications_PublicationID",
                table: "Coments");

            migrationBuilder.DropTable(
                name: "FriendsComents");

            migrationBuilder.DropIndex(
                name: "IX_Coments_PublicationID",
                table: "Coments");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "PublicationID",
                table: "Coments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Coments");

            migrationBuilder.AddColumn<int>(
                name: "PublicationsID",
                table: "Coments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coments_PublicationsID",
                table: "Coments",
                column: "PublicationsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coments_Publications_PublicationsID",
                table: "Coments",
                column: "PublicationsID",
                principalTable: "Publications",
                principalColumn: "ID");
        }
    }
}
