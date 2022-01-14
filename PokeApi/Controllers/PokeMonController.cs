using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<PokeMon> Get()
        {
            return await _mediator.Send(new PokeMonRestQueries());

        }
    }
}