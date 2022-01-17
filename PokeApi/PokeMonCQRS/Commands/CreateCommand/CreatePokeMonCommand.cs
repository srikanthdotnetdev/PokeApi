using MediatR;
using PokeApi.DDD;

namespace PokeApi.PokeMonCQRS.Commands
{
    public record CreatePokeMonCommand(List<string> pokemonList) : IRequest<List<PokeMon>>;
}

