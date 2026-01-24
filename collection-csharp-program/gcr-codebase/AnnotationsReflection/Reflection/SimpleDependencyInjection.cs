using System;
using System.Reflection;

/* Custom Attribute */
class InjectAttribute : Attribute
{
}

/* Dependency Class */
class Service
{
    public void Execute()
    {
        Console.WriteLine("Service Executed");
    }
}

/* Consumer Class */
class Controller
{
    [Inject]
    public Service service;
}

/* Main Program */
class Program
{
    static void Main()
    {
        Controller controller = new Controller();
        Type t = typeof(Controller);

        FieldInfo[] fields = t.GetFields(
            BindingFlags.Public | BindingFlags.Instance);

        for (int i = 0; i < fields.Length; i++)
        {
            FieldInfo field = fields[i];

            if (Attribute.IsDefined(field, typeof(InjectAttribute)))
            {
                object dependency =
                    Activator.CreateInstance(field.FieldType);

                field.SetValue(controller, dependency);
            }
        }

        controller.service.Execute();
    }
}
