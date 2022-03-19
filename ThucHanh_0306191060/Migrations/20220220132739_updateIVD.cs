using Microsoft.EntityFrameworkCore.Migrations;

namespace ThucHanh_0306191060.Migrations
{
    public partial class updateIVD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "InvoiceDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "InvoiceDetail");
        }
    }
}
