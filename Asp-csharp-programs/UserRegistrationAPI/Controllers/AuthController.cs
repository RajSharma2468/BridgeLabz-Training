using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // UC1 - User Registration
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        var result = await _authService.RegisterAsync(request);

        var status = (int)result.GetType().GetProperty("status")!.GetValue(result)!;

        if (status == 400)
            return BadRequest(result);

        return Ok(result);
    }
}