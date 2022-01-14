using Microsoft.AspNetCore.Mvc;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokeMonController : ControllerBase
    {
        private static readonly string[] Summaries =
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<PokeMonController> _logger;

        public PokeMonController(ILogger<PokeMonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPokeMon")]
        public PokeMon Get()
        {
            return new PokeMon
            {
                Name = "PokeMonName",
                Description = "SomeDescription",
                Habitat = "SomeHabitat",
                IsLegendary = false

            };

        }
    }
}