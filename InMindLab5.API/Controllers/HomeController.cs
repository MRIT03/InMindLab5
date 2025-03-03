using Asp.Versioning;
using InMindLab5.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


[ApiVersion(1.0)]
[ApiController]
[Route("api/v{apiVersion:apiVersion}/[controller]")]
public class SampleController : ControllerBase
{
    private readonly IStringLocalizer<SharedResource> _localizer;

    public SampleController(IStringLocalizer<SharedResource> localizer)
    {
        _localizer = localizer;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        // Retrieve a localized string using a key defined in your resource file
        var message = _localizer["Hello"];
        Console.WriteLine("message: " +message);
        return Ok(new { Message = message });
    }
}