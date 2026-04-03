using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/reports")]
public class ReportController : ControllerBase
{
    [HttpGet("download")]
    [PublicAPI]
    public string DownloadReport()
    {
        return "Report downloaded";
    }

    [HttpPost("upload")]
    [RequiresAuth]
    public string UploadReport()
    {
        return "Report uploaded";
    }
}
