using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToOneFluentBookAndBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetail_id",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_BookDetail_id",
                table: "Fluent_Books",
                column: "BookDetail_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_BookDetails_BookDetail_id",
                table: "Fluent_Books",
                column: "BookDetail_id",
                principalTable: "Fluent_BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_BookDetails_BookDetail_id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_BookDetail_id",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "BookDetail_id",
                table: "Fluent_Books");
        }
    }
}
