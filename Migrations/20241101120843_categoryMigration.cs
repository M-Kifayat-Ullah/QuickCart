using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    public partial class categoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_customer",
                table: "tbl_customer");

            migrationBuilder.RenameTable(
                name: "tbl_customer",
                newName: "tbl_Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Customer",
                table: "tbl_Customer",
                column: "Customer_id");

            migrationBuilder.CreateTable(
                name: "tbl_catgegory",
                columns: table => new
                {
                    Category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_catgegory", x => x.Category_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_catgegory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Customer",
                table: "tbl_Customer");

            migrationBuilder.RenameTable(
                name: "tbl_Customer",
                newName: "tbl_customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_customer",
                table: "tbl_customer",
                column: "Customer_id");
        }
    }
}
