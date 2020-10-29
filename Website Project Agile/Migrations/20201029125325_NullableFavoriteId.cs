using Microsoft.EntityFrameworkCore.Migrations;

namespace Website_Project_Agile.Migrations
{
    public partial class NullableFavoriteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favorites_Favorite_id",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Favorite_id",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favorites_Favorite_id",
                table: "AspNetUsers",
                column: "Favorite_id",
                principalTable: "Favorites",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Favorites_Favorite_id",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Favorite_id",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Favorites_Favorite_id",
                table: "AspNetUsers",
                column: "Favorite_id",
                principalTable: "Favorites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
