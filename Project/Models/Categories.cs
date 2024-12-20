using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Categories
    {
        [Key]
        public int CategorieID { get; set; }
        [Required(ErrorMessage = "Nom Categorie Obligatoire!")]
        [StringLength(50)]
        [MinLength(1, ErrorMessage = "La categorie doit avoir au moin carc")]
        public string nom { get; set; }
    }
}
