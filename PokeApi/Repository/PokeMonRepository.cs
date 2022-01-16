using LiteDB;
using PokeApi.DDD;

namespace PokeApi.Repository
{
    public class PokeMonRepository : BaseRepository<PokeMon>, IPokeMonRepository
    {
        public PokeMonRepository(ILiteDatabase db,string collectionName)
            : base(db, collectionName)
        { }

        public override PokeMon Create(PokeMon entity)
        {
            Collection.Insert(entity);

            Collection.EnsureIndex(x => x.Name);

            return Collection.Find(o => o.Name == entity.Name)?.FirstOrDefault();
        }

      

        public PokeMon GetByPokeMonName(string name)
        {
            return Collection.Find(o => o.Name == name)?.FirstOrDefault();
        }

        public bool DeleteAllPokeMons()
        {
            Collection.DeleteMany("1=1");
            
            if (Collection.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //TODO... add more functions about PokeMon
    }
}
