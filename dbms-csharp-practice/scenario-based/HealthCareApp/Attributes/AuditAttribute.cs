using System;

namespace HealthCareApp.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuditAttribute : Attribute
    {
        public string Description { get; set; }
        public AuditAttribute(string description)
        {
            Description = description;
        }
    }
}
