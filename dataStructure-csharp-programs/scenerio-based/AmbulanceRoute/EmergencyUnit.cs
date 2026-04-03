namespace AmbulanceRoute.Models
{
    class EmergencyUnit : HospitalUnit
    {
        public EmergencyUnit(string name, bool available)
            : base(name, available)
        {
        }

        public override string GetUnitType()
        {
            return "Critical Care Unit";
        }
    }
}
