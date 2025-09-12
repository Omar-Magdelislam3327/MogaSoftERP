using Microsoft.AspNetCore.Mvc;
using mogaERP.Domain.Contracts.Auth;
using mogaERP.Domain.Interfaces.Auth;

namespace mogaERP.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService _authService = authService;

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.LoginAsync(request, cancellationToken);
        return Ok(authResult);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var authResult = await _authService.RegisterAsync(request, cancellationToken);
        return Ok(authResult);
    }

}