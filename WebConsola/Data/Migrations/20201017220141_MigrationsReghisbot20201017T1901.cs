using Microsoft.EntityFrameworkCore.Migrations;

namespace WebConsola.Data.Migrations
{
    public partial class MigrationsReghisbot20201017T1901 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    storesid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.storesid);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    total_in_shelf = table.Column<decimal>(nullable: false),
                    total_in_vault = table.Column<decimal>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    storesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.id);
                    table.ForeignKey(
                        name: "FK_articles_stores_storesid",
                        column: x => x.storesid,
                        principalTable: "stores",
                        principalColumn: "storesid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_storesid",
                table: "articles",
                column: "storesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "stores");
        }
    }
}
