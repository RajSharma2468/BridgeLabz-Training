using System;

namespace HealthCareApp.Models
{
    public class Bill : Entity
    {
        public int VisitID { get; set; }
        public double Amount { get; set; }
        public string PaymentStatus { get; set; } = "UNPAID";
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; }

        public override void Display()
        {
            Console.WriteLine("Bill ID: " + ID +
                              ", VisitID: " + VisitID +
                              ", Amount: " + Amount +
                              ", Status: " + PaymentStatus +
                              (string.IsNullOrEmpty(PaymentMode) ? "" : ", Mode: " + PaymentMode) +
                              ", Payment Date: " + PaymentDate.ToString("dd/MM/yyyy"));
        }
    }
}
