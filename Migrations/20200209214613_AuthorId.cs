using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApi.Migrations
{
    public partial class AuthorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorID");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
