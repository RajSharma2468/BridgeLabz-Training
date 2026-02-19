using System;
using System.IO;
using System.Threading;

namespace HealthCareApp.Utilities
{
    public static class AuditLogger
    {
        public static void Log(string message)
        {
            Thread thread = new Thread(() =>
            {
                File.AppendAllText("audit.txt",
                    DateTime.Now + " : " + message + Environment.NewLine);
            });

            thread.Start();
        }
    }
}
