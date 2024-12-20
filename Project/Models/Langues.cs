using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Langues
    {
        [Key]
        public int LanguesID { get; set; }
        [Required(ErrorMessage = "langues Obligatoire!")]
        [StringLength(50)]
        [MinLength(1, ErrorMessage = "La langue doit avoir au moin carc")]
        public string langues { get; set; }
    }
}
