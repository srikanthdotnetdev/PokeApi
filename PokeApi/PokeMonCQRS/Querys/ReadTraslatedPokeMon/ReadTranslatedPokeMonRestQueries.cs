using MediatR;
using PokeApi.DDD;

namespace PokeApi
{
    public record ReadTranslatedPokeMonRestQueries(string PokeMonName) : IRequest<PokeMon>;

}
