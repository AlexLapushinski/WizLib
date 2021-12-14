using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class MakeBookDetailIdNullableInBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_id",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetail_id",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_id",
                table: "Books",
                column: "BookDetail_id",
                unique: true,
                filter: "[BookDetail_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id",
                table: "Books",
                column: "BookDetail_id",
                principalTable: "BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_id",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookDetail_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_id",
                table: "Books",
                column: "BookDetail_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_id",
                table: "Books",
                column: "BookDetail_id",
                principalTable: "BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
