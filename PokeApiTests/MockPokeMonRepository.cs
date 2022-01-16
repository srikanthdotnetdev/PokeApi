using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using PokeApi.DDD;
using PokeApi.Repository;

namespace PokeApiTests
{
    public class MockPokeMonRepository : BaseRepository<PokeMon>, IPokeMonRepository
    {
        public MockPokeMonRepository(ILiteDatabase db,string collectionName)
            : base(db,collectionName)
        { }

        public override PokeMon Create(PokeMon entity)
        {
            return new PokeMon
            {
                Name = "PokeMon",
                Description = "123",
                IsLegendary = true
            };
        }

        public PokeMon GetByPokeMonName(string name)
        {
            return new PokeMon
            {
                Name = name,
                Description = "123",
                IsLegendary = true
            };
        }

        public bool DeleteAllPokeMons()
        {
            throw new NotImplementedException();
        }
    }
}
