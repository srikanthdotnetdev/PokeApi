using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeApi.DDD;

namespace PokeApiTests
{
    internal class MockReadPokeMon:IReadPokeMon
    {
        public async Task<PokeMon> GetPokeMonAsync(string pokemonName, bool translationFlag)
        {
            return await Task.FromResult<PokeMon>(((Func<PokeMon>)(() =>
            {
                
                return new PokeMon()
                {
                    Name = "DummyName",
                    Description = "DummyDescription",
                    Habitat = "DummyHabitat",
                    IsLegendary = false
                };

            }))());
            
        }
    }
}
