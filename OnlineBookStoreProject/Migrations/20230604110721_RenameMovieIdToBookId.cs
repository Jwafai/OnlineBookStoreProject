using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookStoreProject.Migrations
{
    public partial class RenameMovieIdToBookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "BookGenre",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "MovieImage",
                table: "Book",
                newName: "BookImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookGenre",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "BookImage",
                table: "Book",
                newName: "MovieImage");
        }
    }
}
