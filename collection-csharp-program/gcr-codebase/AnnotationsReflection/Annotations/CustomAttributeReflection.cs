using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class TaskInfoAttribute : Attribute
{
    public string Priority;
    public string AssignedTo;

    public TaskInfoAttribute(string priority, string assignedTo)
    {
        Priority = priority;
        AssignedTo = assignedTo;
    }
}

class TaskManager
{
    [TaskInfo("HIGH", "Raj")]
    public void CompleteTask()
    {
    }
}

class Program
{
    static void Main()
    {
        MethodInfo method = typeof(TaskManager).GetMethod("CompleteTask");
        TaskInfoAttribute attr =
            (TaskInfoAttribute)Attribute.GetCustomAttribute(
                method, typeof(TaskInfoAttribute));

        Console.WriteLine(attr.Priority);
        Console.WriteLine(attr.AssignedTo);
    }
}
