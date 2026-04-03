using System;
using System.Reflection;
using System.Text.Json;
using System.Collections.Generic;

public class EventTrackerEngine
{
    public static void RunAudit()
    {
        List<AuditLog> logs = new List<AuditLog>();

        Assembly assembly = Assembly.GetExecutingAssembly();

        foreach (Type type in assembly.GetTypes())
        {
            foreach (MethodInfo method in type.GetMethods())
            {
                var attribute = method.GetCustomAttribute<AuditTrailAttribute>();

                if (attribute != null)
                {
                    object instance = Activator.CreateInstance(type);

                    try
                    {
                        method.Invoke(instance, null);

                        logs.Add(new AuditLog
                        {
                            Event = attribute.EventName,
                            Class = type.Name,
                            Method = method.Name,
                            Timestamp = DateTime.Now,
                            Status = "Success"
                        });
                    }
                    catch
                    {
                        logs.Add(new AuditLog
                        {
                            Event = attribute.EventName,
                            Class = type.Name,
                            Method = method.Name,
                            Timestamp = DateTime.Now,
                            Status = "Failed"
                        });
                    }
                }
            }
        }

        string json = JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("\n=== JSON AUDIT LOGS ===");
        Console.WriteLine(json);
    }
}
