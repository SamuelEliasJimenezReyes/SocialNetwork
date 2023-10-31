using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeletingFriendsComents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendsComents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_FriendsComents_FriendID",
                table: "FriendsComents",
                column: "FriendID");
        }
    }
}
