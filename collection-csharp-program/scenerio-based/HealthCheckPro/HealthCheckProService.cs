using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;

public class HealthCheckProService
{
    public string ScanApis()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        StringBuilder report = new StringBuilder();

        report.AppendLine("=== HealthCheckPro API Documentation ===");
        report.AppendLine();

        foreach (Type type in types)
        {
            if (type.IsSubclassOf(typeof(ControllerBase)))
            {
                report.AppendLine("Controller: " + type.Name);

                MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                foreach (MethodInfo method in methods)
                {
                    bool isPublicApi = method.IsDefined(typeof(PublicAPIAttribute), false);
                    bool requiresAuth = method.IsDefined(typeof(RequiresAuthAttribute), false);
                    bool isInternal = method.IsDefined(typeof(InternalAPIAttribute), false);

                    report.Append("  Method: " + method.Name + " -> ");

                    if (!isPublicApi && !requiresAuth && !isInternal)
                    {
                        report.AppendLine("MISSING API ANNOTATION");
                    }
                    else
                    {
                        report.Append("Annotations: ");
                        if (isPublicApi) report.Append("[PublicAPI] ");
                        if (requiresAuth) report.Append("[RequiresAuth] ");
                        if (isInternal) report.Append("[InternalAPI] ");

                        report.AppendLine();
                    }
                }

                report.AppendLine();
            }
        }

        return report.ToString();
    }
}
