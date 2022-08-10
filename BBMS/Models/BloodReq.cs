using System.ComponentModel.DataAnnotations;

namespace BBMS.Models
{
    public class BloodReq
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public String State { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid Mobile Number.")]
        public int PhoneNo { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string BloodGroup { get; set; }

    }
}
