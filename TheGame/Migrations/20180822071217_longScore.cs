using Microsoft.EntityFrameworkCore.Migrations;

namespace TheGame.Migrations
{
    public partial class longScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Score",
                table: "GameStates",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "GameStates",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
