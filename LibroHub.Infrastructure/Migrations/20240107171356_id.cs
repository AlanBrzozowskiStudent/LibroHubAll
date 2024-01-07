using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibroHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "LibroHub",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibroHub_CreatedById",
                table: "LibroHub",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_LibroHub_AspNetUsers_CreatedById",
                table: "LibroHub",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibroHub_AspNetUsers_CreatedById",
                table: "LibroHub");

            migrationBuilder.DropIndex(
                name: "IX_LibroHub_CreatedById",
                table: "LibroHub");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "LibroHub");

        }
    }
}
