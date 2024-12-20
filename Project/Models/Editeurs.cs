using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Editeurs
    {
        [Key]
        public int EditeurID { get; set; }

        [Required(ErrorMessage = "Nom Acteurs Obligatoire!")]
        [StringLength(50)]
        public string nom { get; set; }

        [Required(ErrorMessage = "Prenom Acteurs Obligatoire!")]
        [StringLength(50)]
        public string prenom { get; set; }

        [Required(ErrorMessage = "nationalite Acteurs Obligatoire!")]
        [StringLength(50)]
        public string nationalite { get; set; }

        [Required(ErrorMessage = "date_naissance Acteurs Obligatoire!")]
        [DataType(DataType.Date)]
        public DateTime date_naissance { get; set; }
    }
}
