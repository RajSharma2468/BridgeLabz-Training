using System;
using System.Threading;
using EmployeePayrollMultiThreading.Model;
using EmployeePayrollMultiThreading.Service;

namespace EmployeePayrollMultiThreading.UC
{
    public class UC3_Synchronization
    {
        private static int connectionCount = 0;
        private static readonly object lockObj = new object();

        public static void AddWithSync(Employee emp)
        {
            lock (lockObj)
            {
                connectionCount++;
                Console.WriteLine("Active Connections: " + connectionCount);
            }

            new EmployeePayrollService().AddEmployeeToPayroll(emp);

            lock (lockObj)
            {
                connectionCount--;
            }
        }
    }
}
