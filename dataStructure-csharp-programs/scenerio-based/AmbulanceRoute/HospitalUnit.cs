namespace AmbulanceRoute.Models
{
    abstract class HospitalUnit
    {
        private string unitName;
        private bool isAvailable;

        public string UnitName
        {
            get { return unitName; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }

        public HospitalUnit(string name, bool available)
        {
            unitName = name;
            isAvailable = available;
        }

        public abstract string GetUnitType();
    }
}
