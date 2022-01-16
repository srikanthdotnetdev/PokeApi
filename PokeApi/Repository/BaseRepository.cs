using LiteDB;

namespace PokeApi.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        public ILiteDatabase DB { get; }
        public ILiteCollection<T> Collection { get; }

        protected BaseRepository(ILiteDatabase db,string collectionName)
        {
            DB = db;
            Collection = db.GetCollection<T>(collectionName);
        }

        public virtual T Create(T entity)
        {
            var newId = Collection.Insert(entity);
            return Collection.FindById(newId.AsInt32);
        }

        public virtual IEnumerable<T> All()
        {
            return Collection.FindAll();
        }

        public virtual T FindById(string id)
        {
            return Collection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            Collection.Upsert(entity);
        }

        public virtual bool Delete(string id)
        {
            return Collection.Delete(id);
        }
    }
}
