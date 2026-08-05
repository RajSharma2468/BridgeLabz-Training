using System;

namespace HealthClinicApp.Entity
{
    // Encapsulated Patient entity
    public class Patient
    {
        // Private fields hidden
        private int _patientId;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private DateTime _dateOfBirth;
        private string _gender;

        // Public properties
        public int PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
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

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        // Derived attribute calculates age
        public int GetAge()
        {
            return DateTime.Now.Year - _dateOfBirth.Year;
        }
    }
}