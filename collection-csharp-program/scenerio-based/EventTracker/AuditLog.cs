using System;

public class AuditLog
{
    public string Event { get; set; }
    public string Class { get; set; }
    public string Method { get; set; }
    public DateTime Timestamp { get; set; }
    public string Status { get; set; }
}
