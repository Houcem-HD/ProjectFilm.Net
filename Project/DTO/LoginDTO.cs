using System.ComponentModel.DataAnnotations;

namespace Project.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "username obligatoire")]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
