using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskImark.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ManagerId",
                table: "Visitors",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Managers_ManagerId",
                table: "Visitors",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Managers_ManagerId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_ManagerId",
                table: "Visitors");
        }
    }
}
