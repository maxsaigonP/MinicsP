using Microsoft.EntityFrameworkCore.Migrations;

namespace ThucHanh_0306191060.Migrations
{
    public partial class updateRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AccountId",
                table: "Rating",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Account_AccountId",
                table: "Rating",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Account_AccountId",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_AccountId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Rating");
        }
    }
}
