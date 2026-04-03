using System;

namespace EmployeeWageApp.Utils
{
    public static class AttendanceChecker
    {
        private static Random random = new Random();
        public static bool IsPresent() => random.Next(0, 2) == 1;
    }
}
