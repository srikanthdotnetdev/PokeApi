using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokeApi.DDD;
using PokeApi.PokeMonCQRS.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeApi.Controllers.V1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TranslatedPokeMonController : ControllerBase
    {
        private readonly ILogger<TranslatedPokeMonController> _logger;
        private readonly IMediator _mediator;

        public TranslatedPokeMonController(ILogger<TranslatedPokeMonController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        
        [HttpGet(Name = "GetTranslatedPokeMon")]

        public async Task<ActionResult<PokeMon>> GetPokMon(string pokemonName)
        {
            var pokeMon = await _mediator.Send(new ReadTranslatedPokeMonRestQueries(pokemonName));
            if (pokeMon.Habitat.Equals("DoesNotExist") || pokeMon.Habitat.Equals("CheckFailed"))
            {
                return Ok("Requested Pokemon Does not exist in the Database");
            }
            return Ok(pokeMon);

        }

        [HttpDelete(Name = "ClearTranslatedLocalData")]

        public async Task<ActionResult<string>> ClearTranslatedLocalData()
        {
            return Ok(await _mediator.Send(new DeletePokeMonTranslatedCommand()));

        }


    }
}
