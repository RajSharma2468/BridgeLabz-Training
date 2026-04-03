using SmartHomeAutomationSystem.Abstract;

namespace SmartHomeAutomationSystem.Appliances
{
    class Light : Appliance
    {
        public Light() : base("Light") { }

        public override void TurnOn()
        {
            status = true;
            Console.WriteLine("Light is glowing 💡");
        }

        public override void TurnOff()
        {
            status = false;
            Console.WriteLine("Light is turned off");
        }
    }
}
