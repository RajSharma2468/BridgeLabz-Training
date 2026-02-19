using System;
using System.Reflection;
using HealthCareApp.Attributes;

namespace HealthCareApp.Utilities
{
    public static class Validator
    {
        public static void Validate(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                object value = prop.GetValue(obj);

                RequiredAttribute required =
                    (RequiredAttribute)Attribute.GetCustomAttribute(prop, typeof(RequiredAttribute));

                if (required != null)
                {
                    if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    {
                        throw new Exception(prop.Name + " is required.");
                    }
                }

                RegexPatternAttribute regex =
                    (RegexPatternAttribute)Attribute.GetCustomAttribute(prop, typeof(RegexPatternAttribute));

                if (regex != null && value != null)
                {
                    if (!regex.IsValid(value.ToString()))
                    {
                        throw new Exception("Invalid format for " + prop.Name);
                    }
                }
            }
        }
    }
}
