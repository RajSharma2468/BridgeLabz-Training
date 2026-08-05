using System;

namespace HealthClinicApp.Entity
{
    // Encapsulated Appointment entity
    public class Appointment
    {
        // Private fields hidden
        private int _appointmentId;
        private int _patientId;
        private int _doctorId;
        private DateTime _appointmentDate;
        private string _status;

        // Public properties
        public int AppointmentId
        {
            get { return _appointmentId; }
            set { _appointmentId = value; }
        }

        public int PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        public int DoctorId
        {
            get { return _doctorId; }
            set { _doctorId = value; }
        }

        public DateTime AppointmentDate
        {
            get { return _appointmentDate; }
            set { _appointmentDate = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}