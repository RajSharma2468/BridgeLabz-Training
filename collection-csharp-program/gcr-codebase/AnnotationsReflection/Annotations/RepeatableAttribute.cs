using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description;

    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

class Software
{
    [BugReport("Null reference issue")]
    [BugReport("Performance issue")]
    public void Process()
    {
    }
}

class Program
{
    static void Main()
    {
        MethodInfo method = typeof(Software).GetMethod("Process");
        object[] attrs = method.GetCustomAttributes(typeof(BugReportAttribute), false);

        foreach (BugReportAttribute bug in attrs)
        {
            Console.WriteLine(bug.Description);
        }
    }
}
