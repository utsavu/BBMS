using System.ComponentModel.DataAnnotations;
namespace BBMS.Models
{
    public class SignupModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string BloodGroup { get; set; }

    }
}