using SmartHomeAutomationSystem.Abstract;

namespace SmartHomeAutomationSystem.Appliances
{
    class AC : Appliance
    {
        public AC() : base("Air Conditioner") { }

        public override void TurnOn()
        {
            status = true;
            Console.WriteLine("AC is cooling ❄️");
        }

        public override void TurnOff()
        {
            status = false;
            Console.WriteLine("AC is turned off");
        }
    }
}
