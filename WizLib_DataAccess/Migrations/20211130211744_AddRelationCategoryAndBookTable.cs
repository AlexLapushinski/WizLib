using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddRelationCategoryAndBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Category_id",
                table: "Books",
                column: "Category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Category_id",
                table: "Books",
                column: "Category_id",
                principalTable: "Categories",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Category_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Category_id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Category_id",
                table: "Books");
        }
    }
}
