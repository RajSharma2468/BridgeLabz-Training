using System;
using AmbulanceRoute.Interfaces;
using AmbulanceRoute.Services;

namespace AmbulanceRoute
{
    class Program
    {
        static void Main()
        {
            IRouteService service = new AmbulanceService();

            service.AddUnit();

            Console.WriteLine("Hospital Circular Route");
            service.DisplayRoute();

            Console.WriteLine();
            service.RedirectPatient();

            Console.WriteLine();
            service.RemoveUnit("Surgery");

            Console.WriteLine();
            service.RedirectPatient();
        }
    }
}
