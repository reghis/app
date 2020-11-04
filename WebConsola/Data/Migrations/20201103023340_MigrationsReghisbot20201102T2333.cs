using Microsoft.EntityFrameworkCore.Migrations;

namespace WebConsola.Data.Migrations
{
    public partial class MigrationsReghisbot20201102T2333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreCod",
                table: "stores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreCod",
                table: "stores");
        }
    }
}
