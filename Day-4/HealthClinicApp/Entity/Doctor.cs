namespace HealthClinicApp.Entity
{
    // Encapsulated Doctor entity
    public class Doctor
    {
        // Private fields hidden
        private int _doctorId;
        private string _firstName;
        private string _lastName;
        private string _specialization;
        private string _phone;

        // Public properties
        public int DoctorId
        {
            get { return _doctorId; }
            set { _doctorId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Specialization
        {
            get { return _specialization; }
            set { _specialization = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Returns full doctor name
        public string GetFullName()
        {
            return _firstName + " " + _lastName;
        }
    }
}