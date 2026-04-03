using System.ComponentModel.DataAnnotations;

namespace AddressBookSystem.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression("^[A-Za-z]{2,}$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression("^[A-Za-z]{2,}$", ErrorMessage = "Invalid Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Zip must be 6 digits")]
        public string Zip { get; set; }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone must be 10 digits")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
