using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/labtests")]
public class LabTestController : ControllerBase
{
    [HttpGet]
    [PublicAPI]
    public string GetAllTests()
    {
        return "List of lab tests";
    }

    [HttpPost("book")]
    [PublicAPI]
    [RequiresAuth]
    public string BookLabTest()
    {
        return "Lab test booked";
    }

    [HttpDelete("cancel")]
    [RequiresAuth]
    public string CancelBooking()
    {
        return "Booking cancelled";
    }

    [HttpGet("internal")]
    public string InternalProcessing()
    {
        return "Internal processing";
    }
}
