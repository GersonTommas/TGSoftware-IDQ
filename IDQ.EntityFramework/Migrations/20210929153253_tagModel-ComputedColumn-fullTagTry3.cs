using Microsoft.EntityFrameworkCore.Migrations;

namespace IDQ.EntityFramework.Migrations
{
    public partial class tagModelComputedColumnfullTagTry3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullTag",
                table: "tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fullTag",
                table: "tags",
                type: "TEXT",
                nullable: true,
                computedColumnSql: "[Tag] + ' ' + [Minimo]",
                stored: false);
        }
    }
}
