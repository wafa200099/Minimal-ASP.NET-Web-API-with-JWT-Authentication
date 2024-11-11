namespace Minimal_ASP.NET_Web_API_with_JWT_Authentication.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetWeather()
    {
        return Ok("You are authorized to see this message!");
    }
}
