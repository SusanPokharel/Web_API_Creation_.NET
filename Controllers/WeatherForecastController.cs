// using Microsoft.AspNetCore.Mvc;
//
// namespace Web_API_Creation.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class WeatherForecastController : ControllerBase
// {
//     private static readonly string[] Summaries = new[]
//     {
//         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//     };
//
//     private readonly ILogger<WeatherForecastController> _logger;
//
//     public WeatherForecastController(ILogger<WeatherForecastController> logger)
//     {
//         _logger = logger;
//     }
//
//     [HttpGet(Name = "GetWeatherForecast")]
//     public IEnumerable<WeatherForecast> Get()
//     {
//         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//         {
//             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             TemperatureC = Random.Shared.Next(-20, 55),
//             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//         })
//         .ToArray();
//     }
// }




using Microsoft.AspNetCore.Mvc;

namespace Web_API_Creation.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<string> stringData = new List<string>(); 
        
    [HttpGet("name")]
    public List<string> GetData()
    {
        return stringData;
    }
    
    [HttpPut("name")]
    public string PutData(string name, string newname)
    {
        if (stringData.Contains(name))
        {
            stringData.Remove(name);
            stringData.Add(newname);
        }
        return $"{name} renamed to" + $" {newname} successfully";
    }
    
    [HttpPost("name")]
    public string PostData(string name)
    {
        if (stringData.Contains(name))
        {
            stringData.Add(name); 
            return $"{name} added successfully";
        }
        return "Duplicate name" + $" {name} not added";
    }
    
    [HttpDelete("name")]
    public string DeleteData(string name)
    {
        stringData.Remove(name);
        return $"{name} added successfully " ;
    }
}