using MediatR;
using PokeApi.DDD;
using PokeApi.Repository;

namespace PokeApi
{
    public class ReadPokeApiRestHandlers:IRequestHandler<ReadPokeMonRestQueries,PokeMon>
    {
        public ReadPokeApiRestHandlers()
        {
            
        }
        public async Task<PokeMon> Handle(ReadPokeMonRestQueries request, CancellationToken cancellationToken)
        {
            
             
           var readRequest = new ReadPokeMon(false,new UrlData());
           return await readRequest.GetPokeMonAsync(request.PokeMonName,false);

             
            
        }
    }
}
