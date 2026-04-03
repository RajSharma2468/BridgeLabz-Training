using EmployeeWageApp.Models;
using EmployeeWageApp.Utils;

namespace EmployeeWageApp.Services
{
    public class WageCalculator
    {
        private const int WagePerHour = 20;
        private const int FullDayHours = 8;
        private const int PartTimeHours = 4;
        private const int MaxWorkingHours = 100;
        private const int MaxWorkingDays = 20;

        public int CalculateDailyWage(Employee emp)
        {
            int hours = emp.Type == "FullTime" ? FullDayHours : PartTimeHours;
            emp.DailyHours = hours;
            emp.TotalHoursWorked += hours;
            return hours * WagePerHour;
        }

        public int CalculateMonthlyWage(Employee emp)
        {
            int totalWage = 0;
            int day = 0;
            while (emp.TotalHoursWorked < MaxWorkingHours && day < MaxWorkingDays)
            {
                if (AttendanceChecker.IsPresent())
                {
                    totalWage += CalculateDailyWage(emp);
                }
                day++;
            }
            return totalWage;
        }
    }
}
