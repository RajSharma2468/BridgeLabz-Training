using System;
using System.Threading;
using EmployeeWageApp.Models;
using EmployeeWageApp.Services;

namespace EmployeeWageApp.Threads
{
    public class WageThread
    {
        private Employee Employee;
        private WageCalculator Calculator;

        public WageThread(Employee emp, WageCalculator calc)
        {
            Employee = emp;
            Calculator = calc;
        }

        public void ComputeMonthly()
        {
            Thread t = new Thread(() =>
            {
                int wage = Calculator.CalculateMonthlyWage(Employee);
                Console.WriteLine($"\n[Thread] Monthly Wage for {Employee.Name}: {wage}");
            });
            t.Start();
        }
    }
}
