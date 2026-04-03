public interface IAuthService
{
    Task<object> RegisterAsync(RegisterRequestDto request);
}