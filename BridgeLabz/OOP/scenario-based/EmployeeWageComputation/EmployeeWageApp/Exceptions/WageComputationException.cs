using System;

namespace EmployeeWageApp.Exceptions
{
    public class WageComputationException : Exception
    {
        public WageComputationException(string message) : base(message) { }
    }
}
