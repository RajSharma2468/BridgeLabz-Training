using SmartHomeAutomationSystem.Appliances;
using SmartHomeAutomationSystem.Abstract;

class Program
{
    static void Main()
    {
        Appliance light = new Light();
        Appliance fan = new Fan();
        Appliance ac = new AC();

        while (true)
        {
            Console.WriteLine("\nSMART HOME AUTOMATION");
            Console.WriteLine("1. Turn ON Light");
            Console.WriteLine("2. Turn OFF Light");
            Console.WriteLine("3. Turn ON Fan");
            Console.WriteLine("4. Turn OFF Fan");
            Console.WriteLine("5. Turn ON AC");
            Console.WriteLine("6. Turn OFF AC");
            Console.WriteLine("7. Show Status");
            Console.WriteLine("8. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: light.TurnOn(); break;
                case 2: light.TurnOff(); break;
                case 3: fan.TurnOn(); break;
                case 4: fan.TurnOff(); break;
                case 5: ac.TurnOn(); break;
                case 6: ac.TurnOff(); break;
                case 7:
                    light.ShowStatus();
                    fan.ShowStatus();
                    ac.ShowStatus();
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
