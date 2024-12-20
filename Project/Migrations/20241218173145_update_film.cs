using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class update_film : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_films_acteurs_ActeurPID",
                table: "films");

            migrationBuilder.DropForeignKey(
                name: "FK_films_acteurs_ActeurSID",
                table: "films");

            migrationBuilder.DropForeignKey(
                name: "FK_films_categories_CategorieID",
                table: "films");

            migrationBuilder.DropForeignKey(
                name: "FK_films_editeurs_EditeurID",
                table: "films");

            migrationBuilder.DropForeignKey(
                name: "FK_films_langues_LangueID",
                table: "films");

            migrationBuilder.DropForeignKey(
                name: "FK_films_realisateurs_RealisateurID",
                table: "films");

            migrationBuilder.DropIndex(
                name: "IX_films_ActeurPID",
                table: "films");

            migrationBuilder.DropIndex(
                name: "IX_films_ActeurSID",
                table: "films");

            migrationBuilder.DropIndex(
                name: "IX_films_CategorieID",
                table: "films");

            migrationBuilder.DropIndex(
                name: "IX_films_EditeurID",
                table: "films");

            migrationBuilder.DropIndex(
                name: "IX_films_LangueID",
                table: "films");

            migrationBuilder.DropIndex(
                name: "IX_films_RealisateurID",
                table: "films");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_films_RealisateurID",
                table: "films",
                column: "RealisateurID");

            migrationBuilder.AddForeignKey(
                name: "FK_films_acteurs_ActeurPID",
                table: "films",
                column: "ActeurPID",
                principalTable: "acteurs",
                principalColumn: "ActeurID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_films_acteurs_ActeurSID",
                table: "films",
                column: "ActeurSID",
                principalTable: "acteurs",
                principalColumn: "ActeurID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_films_categories_CategorieID",
                table: "films",
                column: "CategorieID",
                principalTable: "categories",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_films_editeurs_EditeurID",
                table: "films",
                column: "EditeurID",
                principalTable: "editeurs",
                principalColumn: "EditeurID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_films_langues_LangueID",
                table: "films",
                column: "LangueID",
                principalTable: "langues",
                principalColumn: "LanguesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_films_realisateurs_RealisateurID",
                table: "films",
                column: "RealisateurID",
                principalTable: "realisateurs",
                principalColumn: "RealisateursID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
