using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnaDatabase.Service.Models;
using DnaDatabase.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DnaDatabase.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Wet"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMutationService _mutationService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMutationService mutationService)
        {
            _logger = logger;
            _mutationService = mutationService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("all")]
        public IAsyncEnumerable<MutationDto> GetMutations()
        {
            var mutations = _mutationService.GetAllMutations();
            return mutations;
        }
    }
}
