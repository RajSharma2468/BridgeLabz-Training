using HealthCareApp.Attributes;

namespace HealthCareApp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Specialization { get; set; } = "";
    }
}
