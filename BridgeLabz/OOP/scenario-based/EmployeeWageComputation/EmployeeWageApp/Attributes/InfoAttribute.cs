using System;

namespace EmployeeWageApp.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class InfoAttribute : Attribute
    {
        // Properties that can be set via named arguments
        public string Description { get; set; } = "";
        public string Version { get; set; } = "1.0";

        // Optional: default constructor
        public InfoAttribute() { }

        // Optional: constructor with positional description argument
        public InfoAttribute(string description)
        {
            Description = description;
        }

        // Optional: constructor with positional description + version
        public InfoAttribute(string description, string version)
        {
            Description = description;
            Version = version;
        }
    }
}
