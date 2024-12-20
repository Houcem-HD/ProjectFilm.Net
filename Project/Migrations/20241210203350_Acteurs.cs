using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Acteurs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "categories",
                newName: "nom");

            migrationBuilder.RenameIndex(
                name: "IX_categories_Nom",
                table: "categories",
                newName: "IX_categories_nom");

            migrationBuilder.CreateTable(
                name: "acteurs",
                columns: table => new
                {
                    ActeurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nationalite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    date_naissance = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acteurs", x => x.ActeurID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acteurs");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "categories",
                newName: "Nom");

            migrationBuilder.RenameIndex(
                name: "IX_categories_nom",
                table: "categories",
                newName: "IX_categories_Nom");
        }
    }
}
