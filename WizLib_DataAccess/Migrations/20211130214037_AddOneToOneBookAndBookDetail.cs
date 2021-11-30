using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToOneBookAndBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Category_id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_Category_id",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Category_id",
                table: "Books",
                newName: "BookDetail_id");

            migrationBuilder.CreateTable(
                name: "BookDetail",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetail", x => x.BookDetail_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_id",
                table: "Books",
                column: "BookDetail_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetail_BookDetail_id",
                table: "Books",
                column: "BookDetail_id",
                principalTable: "BookDetail",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetail_BookDetail_id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDetail");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_id",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookDetail_id",
                table: "Books",
                newName: "Category_id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_Id);
                });

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
    }
}
