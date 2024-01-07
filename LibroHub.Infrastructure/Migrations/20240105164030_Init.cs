using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibroHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibroHub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookDetailsBookCategory = table.Column<string>(name: "BookDetails_BookCategory", type: "nvarchar(max)", nullable: true),
                    BookDetailsPageNumber = table.Column<int>(name: "BookDetails_PageNumber", type: "int", nullable: true),
                    BookDetailsAuthor = table.Column<string>(name: "BookDetails_Author", type: "nvarchar(max)", nullable: true),
                    BookDetailsRating = table.Column<int>(name: "BookDetails_Rating", type: "int", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroHub", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroHub");
        }
    }
}
