using System;

namespace HealthCareApp.Exceptions
{
    public class HealthCareAppException : Exception
    {
        public HealthCareAppException(string message) : base(message) { }
    }
}
