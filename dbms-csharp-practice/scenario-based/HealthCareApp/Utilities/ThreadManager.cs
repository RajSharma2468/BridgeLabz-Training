using System;
using System.Threading;

namespace HealthCareApp.Utilities
{
    public static class ThreadManager
    {
        public static void RunInBackground(Action task)
        {
            Thread thread = new Thread(new ThreadStart(task));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
