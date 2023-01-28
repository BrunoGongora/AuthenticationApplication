using System.ComponentModel.DataAnnotations;

namespace ApplicationCrudAndValidation.Models
{
    public class MenuData
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="Este Campo es obligatorio")]
        public string NameDish { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Valoration { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        public string Difficulty { get; set; }

    }
}
