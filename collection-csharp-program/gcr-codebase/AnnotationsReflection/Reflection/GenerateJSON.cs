using System;
using System.Reflection;

class Employee
{
    public int Id = 1;
    public string Name = "Amit";
    public string Dept = "IT";
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();
        Type t = emp.GetType();

        FieldInfo[] fields = t.GetFields(
            BindingFlags.Public | BindingFlags.Instance);

        string json = "{";

        for (int i = 0; i < fields.Length; i++)
        {
            string fieldName = fields[i].Name;
            object fieldValue = fields[i].GetValue(emp);

            json = json + "\"" + fieldName + "\":\"" + fieldValue + "\"";

            if (i < fields.Length - 1)
            {
                json = json + ",";
            }
        }

        json = json + "}";

        Console.WriteLine(json);
    }
}
