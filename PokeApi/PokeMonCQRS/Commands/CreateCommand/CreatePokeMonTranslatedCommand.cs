using MediatR;
using PokeApi.DDD;

namespace PokeApi.PokeMonCQRS.Commands
{
    public record CreatePokeMonTranslatedCommand(List<string> pokemonList) : IRequest<List<PokeMon>>;
}

