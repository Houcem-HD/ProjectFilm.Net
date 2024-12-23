﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }

        [Required]
        public string Description { get; set; }

        public int DateCreated { get; set; }

        public int Duree { get; set; }

        public string? Poster { get; set; }

        // Foreign Key for Categories
        [ForeignKey("Categories")]
        public int CategorieID { get; set; }

        // Foreign Keys for Acteurs
        [ForeignKey("Acteurs")]  // Foreign key for ActeurPID
        public int ActeurPID { get; set; }

        [ForeignKey("Acteurs")]  // Foreign key for ActeurSID
        public int ActeurSID { get; set; }

        // Foreign Key for Editeurs
        [ForeignKey("Editeurs")]
        public int EditeurID { get; set; }

        // Foreign Key for Langues
        [ForeignKey("Langues")]
        public int LangueID { get; set; }

        // Foreign Key for Realisateurs
        [ForeignKey("Realisateurs")]
        public int RealisateurID { get; set; }
    }
}