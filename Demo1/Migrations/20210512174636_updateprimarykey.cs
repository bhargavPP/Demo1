using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo1.Migrations
{
    public partial class updateprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrderDetail",
                table: "SalesOrderDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrderDetail",
                table: "SalesOrderDetail",
                columns: new[] { "OrderID", "Sequence" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrderDetail",
                table: "SalesOrderDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrderDetail",
                table: "SalesOrderDetail",
                column: "OrderID");
        }
    }
}
