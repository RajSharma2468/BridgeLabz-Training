using System;

namespace HealthCareApp.Models
{
    public class Appointment : Entity
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "SCHEDULED";

        public override void Display()
        {
            Console.WriteLine("Appointment ID: " + ID +
                              ", PatientID: " + PatientID +
                              ", DoctorID: " + DoctorID +
                              ", Date: " + AppointmentDate.ToString("dd/MM/yyyy HH:mm") +
                              ", Status: " + Status);
        }
    }
}
