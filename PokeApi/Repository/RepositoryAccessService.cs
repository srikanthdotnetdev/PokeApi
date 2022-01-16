using LiteDB;

namespace PokeApi.Repository
{
    public class RepositoryAccessService : IDisposable
    {
        private readonly string? _connStr;
        private ILiteDatabase? _db;
        private bool _disposed;
        private readonly string? _pokeMonTranslationCollection;
        private readonly bool _translationFlag;
        private readonly string? _pokeMonCollection;
        private IPokeMonRepository? _pokeMonRepository; 
	
          //  ... add more repositories we need

        public RepositoryAccessService(ILiteDbContext liteDbConnection)
        {
            if (liteDbConnection == null)
                 throw new ArgumentNullException("missing connection string");

            _db = liteDbConnection.Database;
            _connStr=liteDbConnection.ConnectionString;
            _pokeMonCollection = liteDbConnection.Collection;
            _pokeMonTranslationCollection = liteDbConnection.TranslatedCollection;
            _translationFlag = liteDbConnection.TranslationFlag;
        }

        private ILiteDatabase DB
        {
            get
            {
               return _db ??= new LiteDatabase(_connStr);

               
            }
        }

        public IPokeMonRepository PokeMonRepository
        {
            
            get { return _pokeMonRepository ??= new PokeMonRepository(DB, _translationFlag ? _pokeMonTranslationCollection : _pokeMonCollection); }
        }

        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                        _db.Dispose();
                }
                _disposed = true;
            }
        }

        ~RepositoryAccessService()
        {
            Dispose(false);
        }
    }
}
