using PokeApi.DDD;
using Microsoft.Extensions.Logging;

namespace PokeApi.GraphQL
{
    public partial class GraphQlQueries
    {

       

   

        public class Query
        {
           

            public async Task<PokeMon> GetPokeMon(string pokemonName,bool translationFlag=false)
            {
                 
                var readInstancePokeMon = new ReadPokeMon(false,new UrlData());
              return await readInstancePokeMon.GetPokeMonAsync(pokemonName, translationFlag);
            }
        }
    }
}
