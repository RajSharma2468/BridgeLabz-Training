using System;
using EmployeeWageComputation.Interfaces;
using EmployeeWageComputation.Models;

namespace EmployeeWageComputation.Services
{
    class WageCalculator : IWageCalculator
    {
        private Employee employee;
        private Random random;

        public WageCalculator(Employee emp)
        {
            employee = emp;
            random = new Random();
        }

        // UC 1 - Attendance
        private bool CheckAttendance()
        {
            int attendance = random.Next(2);
            return attendance == 1;
        }

        // UC 3 & UC 4 - Switch Case
        private int GetWorkingHours()
        {
            int workType = random.Next(3);
            int hours;

            switch (workType)
            {
                case 1:
                    hours = employee.GetFullDayHours();
                    break;
                case 2:
                    hours = employee.GetPartTimeHours();
                    break;
                default:
                    hours = 0;
                    break;
            }
            return hours;
        }

        // UC 2 - Daily Wage
        public void CalculateDailyWage()
        {
            if (CheckAttendance())
            {
                int dailyWage = employee.GetFullDayHours() * employee.GetWagePerHour();
                Console.WriteLine("Employee is Present");
                Console.WriteLine("Daily Wage : " + dailyWage);
            }
            else
            {
                Console.WriteLine("Employee is Absent");
                Console.WriteLine("Daily Wage : 0");
            }
        }

        // UC 5 & UC 6 - Monthly Wage
        public void CalculateMonthlyWage(int maxDays, int maxHours)
        {
            int totalDays = 0;
            int totalHours = 0;

            while (totalDays < maxDays && totalHours < maxHours)
            {
                totalDays++;
                totalHours += GetWorkingHours();
            }

            int totalWage = totalHours * employee.GetWagePerHour();

            Console.WriteLine("Total Working Days : " + totalDays);
            Console.WriteLine("Total Working Hours : " + totalHours);
            Console.WriteLine("Total Monthly Wage : " + totalWage);
        }
    }
}
