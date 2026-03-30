using System.ComponentModel.DataAnnotations;

namespace CogniStack_Website.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string Phone { get; set; }
        public string Service { get; set; }

        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters")]
        public string Message { get; set; }

        public DateTime MessageDate { get; set; } = DateTime.Now;
    }
}
