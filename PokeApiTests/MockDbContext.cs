using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using PokeApi.Repository;

namespace PokeApiTests
{
    public class MockDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public string Collection => "PokeMons";
        public string TranslatedCollection => "PokeMonsTranslated";
        public bool TranslationFlag { get; set; }
        public string ConnectionString => "Pokemon.db";

        public MockDbContext(bool translationFlag)
        {
            TranslationFlag = translationFlag;

            Database = new LiteDatabase("Pokemon.db");
        }
    }
}
