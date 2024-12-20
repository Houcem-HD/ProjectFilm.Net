using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Realisateurs
    {
        [Key]
        public int RealisateursID { get; set; }
        [Required(ErrorMessage = "nom Obligatoire!")]
        [StringLength(50)]
        [MinLength(1, ErrorMessage = "Le nom doit avoir au moin carc")]
        public string nom { get; set; }
    }
}
