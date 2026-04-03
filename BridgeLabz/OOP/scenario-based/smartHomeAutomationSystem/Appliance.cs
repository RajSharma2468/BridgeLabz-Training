using SmartHomeAutomationSystem.Interfaces;

namespace SmartHomeAutomationSystem.Abstract
{
    abstract class Appliance : IControllable
    {
        protected string name;
        protected bool status;

        public Appliance(string name)
        {
            this.name = name;
            status = false;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();

        public virtual void ShowStatus()
        {
            Console.WriteLine($"{name} Status: {(status ? "ON" : "OFF")}");
        }
    }
}
