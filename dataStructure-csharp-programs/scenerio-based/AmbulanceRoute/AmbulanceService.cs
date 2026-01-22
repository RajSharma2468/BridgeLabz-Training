using System;
using AmbulanceRoute.Interfaces;
using AmbulanceRoute.Models;
using AmbulanceRoute.DataStructures;

namespace AmbulanceRoute.Services
{
    class AmbulanceService : IRouteService
    {
        private CircularLinkedList route;

        public AmbulanceService()
        {
            route = new CircularLinkedList();
        }

        public void AddUnit()
        {
            route.Add(new EmergencyUnit("Emergency", false));
            route.Add(new EmergencyUnit("Radiology", false));
            route.Add(new EmergencyUnit("Surgery", true));
            route.Add(new EmergencyUnit("ICU", false));
        }

        public void RedirectPatient()
        {
            HospitalUnit unit = route.FindAvailable();

            if (unit != null)
            {
                Console.WriteLine("Patient redirected to " + unit.UnitName);
            }
            else
            {
                Console.WriteLine("No available unit found");
            }
        }

        public void RemoveUnit(string unitName)
        {
            route.Remove(unitName);
            Console.WriteLine(unitName + " removed for maintenance");
        }

        public void DisplayRoute()
        {
            route.Display();
        }
    }
}
