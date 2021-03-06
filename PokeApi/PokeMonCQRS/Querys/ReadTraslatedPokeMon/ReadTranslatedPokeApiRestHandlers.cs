using MediatR;
using PokeApi.DDD;
using PokeApi.GraphQL;
using PokeApi.Repository;

namespace PokeApi
{
    public class ReadTranslatedPokeApiRestHandlers:IRequestHandler<ReadTranslatedPokeMonRestQueries,PokeMon>
    {
        public ReadTranslatedPokeApiRestHandlers()
        {
            
        }
        public async Task<PokeMon> Handle(ReadTranslatedPokeMonRestQueries request, CancellationToken cancellationToken)
        {
            
             
           var readRequest = new ReadPokeMon(true,new UrlData());
           return await readRequest.GetPokeMonAsync(request.PokeMonName,true);
          

        }
    }
}
