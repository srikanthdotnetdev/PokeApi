using MediatR;
using PokeApi.DDD;
using PokeApi.GraphQL;
using PokeApi.Repository;

namespace PokeApi.PokeMonCQRS.Commands
{
    public class CreatePokeMonTranslatedHandler:IRequestHandler<CreatePokeMonTranslatedCommand, List<PokeMon>>
    {
        public async Task<List<PokeMon>> Handle(CreatePokeMonTranslatedCommand request, CancellationToken cancellationToken)
        {
            var readInstance = new ReadPokeMon(true, new UrlData());
            return await readInstance.GetListOfPokemons(request.pokemonList, true);
        }

        
    }
}
