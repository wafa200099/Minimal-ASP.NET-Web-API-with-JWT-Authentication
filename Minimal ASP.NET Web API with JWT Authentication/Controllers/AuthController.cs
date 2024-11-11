namespace Minimal_ASP.NET_Web_API_with_JWT_Authentication.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthController(JwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Test user credentials
        string testUsername = "w";
        string testPassword = "ww";

        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Username and password are required.");
        }
        
        if (request.Username != testUsername || request.Password != testPassword)
        {
            return Unauthorized("Invalid username or password.");
        }

        var token = _jwtTokenGenerator.GenerateToken(request.Username);
        return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
