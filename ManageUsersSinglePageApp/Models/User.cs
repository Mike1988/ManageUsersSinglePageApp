using System.ComponentModel.DataAnnotations;

namespace ManageUsersCoreApp.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Name field must not be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        public int? Age { get; set; }

        [MaxLength(50, ErrorMessage = "The Address field must not be longer than 50 characters.")]
        public string Address { get; set; }
    }
}