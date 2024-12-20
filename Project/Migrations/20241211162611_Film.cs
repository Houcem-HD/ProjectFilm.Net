using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Film : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "films",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<int>(type: "int", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false),
                    ActeurPID = table.Column<int>(type: "int", nullable: false),
                    ActeurSID = table.Column<int>(type: "int", nullable: false),
                    EditeurID = table.Column<int>(type: "int", nullable: false),
                    LangueID = table.Column<int>(type: "int", nullable: false),
                    realisateurID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.FilmID);
                    table.ForeignKey(
                        name: "FK_films_acteurs_ActeurPID",
                        column: x => x.ActeurPID,
                        principalTable: "acteurs",
                        principalColumn: "ActeurID",
                        onDelete: ReferentialAction.Cascade); // Cascade on ActeurPID
                    table.ForeignKey(
                        name: "FK_films_acteurs_ActeurSID",
                        column: x => x.ActeurSID,
                        principalTable: "acteurs",
                        principalColumn: "ActeurID",
                        onDelete: ReferentialAction.NoAction); // No action on ActeurSID
                    table.ForeignKey(
                        name: "FK_films_categories_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "categories",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_editeurs_EditeurID",
                        column: x => x.EditeurID,
                        principalTable: "editeurs",
                        principalColumn: "EditeurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_langues_LangueID",
                        column: x => x.LangueID,
                        principalTable: "langues",
                        principalColumn: "LanguesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_realisateurs_realisateurID",
                        column: x => x.realisateurID,
                        principalTable: "realisateurs",
                        principalColumn: "RealisateursID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_films_ActeurPID",
                table: "films",
                column: "ActeurPID");

            migrationBuilder.CreateIndex(
                name: "IX_films_ActeurSID",
                table: "films",
                column: "ActeurSID");

            migrationBuilder.CreateIndex(
                name: "IX_films_CategorieID",
                table: "films",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_films_EditeurID",
                table: "films",
                column: "EditeurID");

            migrationBuilder.CreateIndex(
                name: "IX_films_LangueID",
                table: "films",
                column: "LangueID");

            migrationBuilder.CreateIndex(
                name: "IX_films_realisateurID",
                table: "films",
                column: "realisateurID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "films");
        }
    }
}
