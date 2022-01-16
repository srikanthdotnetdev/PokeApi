using LiteDB;

namespace PokeApi.Repository
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
        String Collection { get; }
        String TranslatedCollection { get; }
        bool TranslationFlag { get; set; }
        String ConnectionString { get; }
    }
}