using MediatR;
using Microsoft.AspNetCore.Mvc;
using PokeApi.DDD;
using PokeApi.PokeMonCQRS.Commands;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PokeMonController : ControllerBase
    {
        private readonly ILogger<PokeMonController> _logger;
        private readonly IMediator _mediator;

        public PokeMonController(ILogger<PokeMonController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetPokeMon")]
       
        public async Task<ActionResult<PokeMon>> GetPokMon(string pokemonName)
        {
            var pokeMon = await _mediator.Send(new ReadPokeMonRestQueries(pokemonName));
            if (pokeMon.Habitat.Equals("DoesNotExist")|| pokeMon.Habitat.Equals("CheckFailed"))
            {
                return Ok("Requested Pokemon Does not exist in the Database");
            }
            return Ok(pokeMon);

        }
        
        [HttpDelete(Name = "ClearLocalStore")]
       
        public async Task<ActionResult<string>> ClearLocalData()
        {
            return Ok(await _mediator.Send(new DeletePokeMonCommand()));

        }
       
        [HttpPost(Name = "CreatePokeMon")]
        
        public async Task<PokeMon> CreatePokeMon([FromBodyAttribute]PokeMon PokeMonModel)
        {
            return await _mediator.Send(new CreatePokeMonCommand(PokeMonModel));

        }
         
    }
}