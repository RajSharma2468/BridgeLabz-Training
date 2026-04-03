using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using EmployeePayrollMultiThreading.Model;
using EmployeePayrollMultiThreading.Service;

namespace EmployeePayrollMultiThreading.UC
{
    public class UC2_ThreadedAdd
    {
        public static void Run(List<Employee> employees)
        {
            EmployeePayrollService service = new EmployeePayrollService();
            List<Thread> threads = new List<Thread>();
            Stopwatch sw = Stopwatch.StartNew();

            foreach (var emp in employees)
            {
                Thread t = new Thread(() => service.AddEmployeeToPayroll(emp));
                threads.Add(t);
                t.Start();
            }

            foreach (var t in threads)
                t.Join();

            sw.Stop();
            Console.WriteLine("UC2 Threaded Time: " + sw.ElapsedMilliseconds);
        }
    }
}
