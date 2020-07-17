using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStore.Infrastructure.Migrations
{
    public partial class MovieCastTableModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCase_Cast_CastId",
                table: "MovieCase");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCase_Movie_MovieId",
                table: "MovieCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCase",
                table: "MovieCase");

            migrationBuilder.RenameTable(
                name: "MovieCase",
                newName: "MovieCast");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCase_MovieId",
                table: "MovieCast",
                newName: "IX_MovieCast_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "CastId", "MovieId", "Character" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Cast_CastId",
                table: "MovieCast",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Movie_MovieId",
                table: "MovieCast",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Cast_CastId",
                table: "MovieCast");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Movie_MovieId",
                table: "MovieCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.RenameTable(
                name: "MovieCast",
                newName: "MovieCase");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCase",
                newName: "IX_MovieCase_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCase",
                table: "MovieCase",
                columns: new[] { "CastId", "MovieId", "Character" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCase_Cast_CastId",
                table: "MovieCase",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCase_Movie_MovieId",
                table: "MovieCase",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
