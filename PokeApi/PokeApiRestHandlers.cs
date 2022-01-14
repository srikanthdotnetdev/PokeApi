using MediatR;

namespace PokeApi
{
    public class PokeApiRestHandlers:IRequestHandler<PokeMonRestQueries,PokeMon>
    {
        public PokeApiRestHandlers()
        {
            
        }
        public Task<PokeMon> Handle(PokeMonRestQueries request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PokeMon
            {
                Name = "PokeMonName",
                Description = "SomeDescription",
                Habitat = "SomeHabitat",
                IsLegendary = false
            });
        }
    }
}
