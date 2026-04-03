using System;

namespace HealthCareApp.Models
{
    public class Doctor : Entity
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Contact { get; set; }
        public double ConsultationFee { get; set; }
        public bool IsActive { get; set; } = true;

        public override void Display()
        {
            Console.WriteLine("Doctor ID: " + ID +
                              ", Name: " + Name +
                              ", Specialty: " + Specialty +
                              ", Active: " + IsActive);
        }
    }
}
