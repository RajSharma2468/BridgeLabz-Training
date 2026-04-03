using System;

namespace HealthCareApp.Models
{
    public class Visit : Entity
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }

        public override void Display()
        {
            Console.WriteLine("Visit ID: " + ID +
                              ", PatientID: " + PatientID +
                              ", DoctorID: " + DoctorID +
                              ", Date: " + VisitDate.ToString("dd/MM/yyyy") +
                              ", Diagnosis: " + Diagnosis +
                              (string.IsNullOrEmpty(Prescription) ? "" : ", Prescription: " + Prescription) +
                              (string.IsNullOrEmpty(Notes) ? "" : ", Notes: " + Notes));
        }
    }
}
