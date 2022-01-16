using MediatR;
using PokeApi.DDD;

namespace PokeApi.PokeMonCQRS.Commands
{
    public class CreatePokeMonHandler:IRequestHandler<CreatePokeMonCommand, PokeMon>
    {
        public Task<PokeMon> Handle(CreatePokeMonCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PokeMon
            {
                
                Name = request.PokeMonModel.Name,
                Description = request.PokeMonModel.Description,
                Habitat = request.PokeMonModel.Habitat,
                IsLegendary = request.PokeMonModel.IsLegendary
            });
        }
    }
}
