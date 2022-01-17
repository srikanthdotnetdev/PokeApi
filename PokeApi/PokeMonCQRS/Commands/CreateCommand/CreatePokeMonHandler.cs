using MediatR;
using PokeApi.DDD;
using PokeApi.GraphQL;
using PokeApi.Repository;

namespace PokeApi.PokeMonCQRS.Commands
{
    public class CreatePokeMonHandler:IRequestHandler<CreatePokeMonCommand, List<PokeMon>>
    {
        public async Task<List<PokeMon>> Handle(CreatePokeMonCommand request, CancellationToken cancellationToken)
        {
            var readInstance = new ReadPokeMon(false, new UrlData());
            return await readInstance.GetListOfPokemons(request.pokemonList, false);
        }

       
    
    }
}
