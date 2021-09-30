using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class tagModelComputedColumnfullTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fullTag",
                table: "tags",
                type: "TEXT",
                nullable: true,
                computedColumnSql: "[Tag] + ' ' + [Minimo]",
                stored: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullTag",
                table: "tags");
        }
    }
}
