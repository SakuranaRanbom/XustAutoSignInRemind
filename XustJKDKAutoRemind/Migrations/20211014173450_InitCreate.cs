using Microsoft.EntityFrameworkCore.Migrations;

namespace XustJKDKAutoRemind.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QQStus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GH = table.Column<string>(type: "TEXT", nullable: true),
                    XM = table.Column<string>(type: "TEXT", nullable: true),
                    QQ = table.Column<string>(type: "TEXT", nullable: true),
                    Group = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QQStus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QQStus");
        }
    }
}
