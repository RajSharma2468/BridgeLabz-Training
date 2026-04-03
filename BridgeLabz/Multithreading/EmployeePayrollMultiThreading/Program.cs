using System.Collections.Generic;
using EmployeePayrollMultiThreading.Model;
using EmployeePayrollMultiThreading.UC;

namespace EmployeePayrollMultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "Alice", Salary = 30000 },
                new Employee { Name = "Bob", Salary = 35000 },
                new Employee { Name = "Charlie", Salary = 40000 }
            };

            UC1_SequentialAdd.Run(employees);
            UC2_ThreadedAdd.Run(employees);
        }
    }
}
