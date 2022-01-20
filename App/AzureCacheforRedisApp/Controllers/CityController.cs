using AzureCacheforRedisApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureCacheforRedisApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _cityService.GetCitiesAsync());
    }
}
