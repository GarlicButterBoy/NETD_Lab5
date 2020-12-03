using Microsoft.EntityFrameworkCore.Migrations;

namespace NETD_Lab5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prompts",
                columns: table => new
                {
                    p_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prompt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prompts", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedPrompts",
                columns: table => new
                {
                    completed_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_id = table.Column<int>(nullable: false),
                    promptsp_id = table.Column<int>(nullable: true),
                    book_name = table.Column<string>(nullable: true),
                    author_name = table.Column<string>(nullable: true),
                    rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedPrompts", x => x.completed_id);
                    table.ForeignKey(
                        name: "FK_CompletedPrompts_Prompts_promptsp_id",
                        column: x => x.promptsp_id,
                        principalTable: "Prompts",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedPrompts_promptsp_id",
                table: "CompletedPrompts",
                column: "promptsp_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedPrompts");

            migrationBuilder.DropTable(
                name: "Prompts");
        }
    }
}
