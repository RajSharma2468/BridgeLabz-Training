using HealthCareApp.Attributes;

namespace HealthCareApp.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        [RegexPattern("^[0-9]{10}$")]
        public string Phone { get; set; } = "";

        [Required]
        [RegexPattern("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$")]
        public string Email { get; set; } = "";
    }
}
