using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/healthcheck")]
public class HealthCheckController : ControllerBase
{
    private readonly HealthCheckProService _service;

    public HealthCheckController(HealthCheckProService service)
    {
        _service = service;
    }

    [HttpGet("report")]
    public string GetApiReport()
    {
        return _service.ScanApis();
    }
}
