using System;

namespace HealthCareApp.Models
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }

        // Console me patient details display karne ke liye
        public override void Display()
        {
            Console.WriteLine("Patient ID: " + ID + 
                              ", Name: " + Name + 
                              ", DOB: " + DOB.ToShortDateString() + 
                              ", Contact: " + Contact + 
                              ", BloodGroup: " + BloodGroup);
        }
    }
}
