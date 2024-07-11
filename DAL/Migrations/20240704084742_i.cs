using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class i : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bolumlers_Parent_Parentid",
                table: "Bolumlers");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropIndex(
                name: "IX_Bolumlers_Parentid",
                table: "Bolumlers");

            migrationBuilder.DropColumn(
                name: "Parentid",
                table: "Bolumlers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Parentid",
                table: "Bolumlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolumlers_Parentid",
                table: "Bolumlers",
                column: "Parentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bolumlers_Parent_Parentid",
                table: "Bolumlers",
                column: "Parentid",
                principalTable: "Parent",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
