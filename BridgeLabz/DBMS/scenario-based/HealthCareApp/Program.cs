using System;
using System.Reflection;
using HealthCareApp.Models;
using HealthCareApp.Services;
using HealthCareApp.Utilities;

namespace HealthCareApp
{
    class Program
    {
        static PatientService patientService = new PatientService();
        static DoctorService doctorService = new DoctorService();
        static AppointmentService appointmentService = new AppointmentService();
        static VisitService visitService = new VisitService();
        static BillingService billingService = new BillingService();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- HealthCare App Menu ---");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Book Appointment");
                Console.WriteLine("4. Record Visit");
                Console.WriteLine("5. Generate Bill");
                Console.WriteLine("6. View Audit Methods");
                Console.WriteLine("7. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterPatientUI();
                        break;
                    case "2":
                        AddDoctorUI();
                        break;
                    case "3":
                        BookAppointmentUI();
                        break;
                    case "4":
                        RecordVisitUI();
                        break;
                    case "5":
                        GenerateBillUI();
                        break;
                    case "6":
                        ShowAuditMethods();
                        break;
                    case "7":
                        running = false;
                        break;
                }
            }
        }

        static void RegisterPatientUI()
        {
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("DOB (yyyy-mm-dd): "); DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Contact: "); string contact = Console.ReadLine();
            Console.Write("Address: "); string address = Console.ReadLine();
            Console.Write("Blood Group: "); string bg = Console.ReadLine();

            patientService.Register(new Patient
            {
                Name = name,
                DOB = dob,
                Contact = contact,
                Address = address,
                BloodGroup = bg
            });

            // ThreadManager.RunInBackground(() =>
            // {
            //     // Fixed here: use Play() instead of PlayNotification()
            //     AudioPlayer.Play("notify.wav");
            // });
        }

        static void AddDoctorUI()
        {
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Specialty: "); string spec = Console.ReadLine();
            Console.Write("Contact: "); string contact = Console.ReadLine();
            Console.Write("Fee: "); double fee = double.Parse(Console.ReadLine());

            doctorService.AddDoctor(new Doctor
            {
                Name = name,
                Specialty = spec,
                Contact = contact,
                ConsultationFee = fee
            });
        }

        static void BookAppointmentUI()
        {
            Console.Write("PatientID: "); int pid = int.Parse(Console.ReadLine());
            Console.Write("DoctorID: "); int did = int.Parse(Console.ReadLine());
            Console.Write("Date (yyyy-mm-dd HH:mm): "); DateTime dt = DateTime.Parse(Console.ReadLine());

            appointmentService.BookAppointment(pid, did, dt);
        }

        static void RecordVisitUI()
        {
            Console.Write("PatientID: "); int pid = int.Parse(Console.ReadLine());
            Console.Write("DoctorID: "); int did = int.Parse(Console.ReadLine());
            Console.Write("Diagnosis: "); string diag = Console.ReadLine();
            Console.Write("Prescription: "); string pres = Console.ReadLine();
            Console.Write("Notes: "); string notes = Console.ReadLine();

            visitService.RecordVisit(pid, did, diag, pres, notes);
        }

        static void GenerateBillUI()
        {
            Console.Write("VisitID: "); int vid = int.Parse(Console.ReadLine());
            Console.Write("Amount: "); double amt = double.Parse(Console.ReadLine());
            billingService.GenerateBill(vid, amt);

            Console.Write("Payment Mode (Cash/Card/UPI): "); string mode = Console.ReadLine();
            billingService.RecordPayment(vid, mode);
        }

        static void ShowAuditMethods()
        {
            object[] services = new object[] { patientService, doctorService, appointmentService, visitService, billingService };
            foreach (object service in services)
            {
                MethodInfo[] methods = service.GetType().GetMethods();
                foreach (MethodInfo m in methods)
                {
                    object[] attrs = m.GetCustomAttributes(typeof(HealthCareApp.Attributes.AuditAttribute), false);
                    foreach (HealthCareApp.Attributes.AuditAttribute a in attrs)
                    {
                        Console.WriteLine(service.GetType().Name + "." + m.Name + " => " + a.Description);
                    }
                }
            }
        }
    }
}
