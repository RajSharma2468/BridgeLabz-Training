using System;

public class FileService
{
    [AuditTrail("File Upload")]
    public void UploadFile()
    {
        Console.WriteLine("File uploaded.");
    }

    [AuditTrail("File Delete")]
    public void DeleteFile()
    {
        Console.WriteLine("File deleted.");
    }
}
