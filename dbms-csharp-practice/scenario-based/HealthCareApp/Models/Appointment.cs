using System;
using HealthCareApp.Attributes;

namespace HealthCareApp.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [RegexPattern("^[a-zA-Z0-9 ,.-]{3,200}$")]
        public string Reason { get; set; } = "";
    }
}
