using System;

[AttributeUsage(AttributeTargets.Method)]
public class AuditTrailAttribute : Attribute
{
    public string EventName { get; set; }

    public AuditTrailAttribute(string eventName)
    {
        EventName = eventName;
    }
}
