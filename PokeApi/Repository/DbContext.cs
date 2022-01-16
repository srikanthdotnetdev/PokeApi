using LiteDB;

namespace PokeApi.Repository
{
    public class DbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public   string Collection => "PokeMons";
        public string TranslatedCollection => "PokeMonsTranslated";
        public bool TranslationFlag { get;  set; }
        public   string ConnectionString => "Data/Pokemon.db";

        public DbContext(bool translationFlag)
        {
            TranslationFlag = translationFlag;

            Database = new LiteDatabase("Data/Pokemon.db");
        }
    }
}
