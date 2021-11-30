using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class AddOneToManyBookAndPublisherRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_id",
                table: "Books",
                column: "Publisher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_Publisher_id",
                table: "Books",
                column: "Publisher_id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_Publisher_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Publisher_id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Publisher_id",
                table: "Books");
        }
    }
}
