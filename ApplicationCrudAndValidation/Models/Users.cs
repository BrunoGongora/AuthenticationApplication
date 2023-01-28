using System.ComponentModel.DataAnnotations;

namespace ApplicationCrudAndValidation.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Password { get; set; }
    }
}
