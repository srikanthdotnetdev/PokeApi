using MediatR;
using PokeApi.DDD;

namespace PokeApi
{
    public record ReadPokeMonRestQueries(string PokeMonName) : IRequest<PokeMon>;

}
