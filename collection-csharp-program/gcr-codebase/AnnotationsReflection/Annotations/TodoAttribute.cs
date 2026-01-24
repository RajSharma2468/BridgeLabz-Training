using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class TodoAttribute : Attribute
{
    public string Task;
    public string AssignedTo;
    public string Priority;

    public TodoAttribute(string task, string assignedTo)
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = "MEDIUM";
    }
}

class Project
{
    [Todo("Fix login", "Raj")]
    [Todo("Optimize DB", "Amit")]
    public void Work()
    {
    }
}

class Program
{
    static void Main()
    {
        MethodInfo method = typeof(Project).GetMethod("Work");
        object[] todos = method.GetCustomAttributes(typeof(TodoAttribute), false);

        foreach (TodoAttribute t in todos)
        {
            Console.WriteLine(t.Task + " - " + t.AssignedTo + " - " + t.Priority);
        }
    }
}
