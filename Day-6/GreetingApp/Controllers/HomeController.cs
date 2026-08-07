using Microsoft.AspNetCore.Mvc;
using GreetingApp.Models;

namespace GreetingApp.Controllers
{
    // Handles greeting page requests
    public class HomeController : Controller
    {
        // Shows the input form
        public IActionResult Index()
        {
            return View();
        }

        // Processes name and shows greeting
        [HttpPost]
        public IActionResult GetGreeting(string name)
        {
            Greeting greeting = new Greeting();
            greeting.Name = name;

            // Decide message based on current time
            int hour = DateTime.Now.Hour;
            string timeGreeting;

            if (hour < 12)
                timeGreeting = "Good Morning";
            else if (hour < 17)
                timeGreeting = "Good Afternoon";
            else
                timeGreeting = "Good Evening";

            greeting.Message = $"{timeGreeting}, {name}! Welcome to the Greeting App.";

            return View("Result", greeting);
        }
    }
}