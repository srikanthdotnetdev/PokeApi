using PokeApi.DDD;

namespace PokeApi.Repository;

public interface IPokeMonRepository : IBaseRepository<PokeMon>
{
        
    PokeMon GetByPokeMonName(string name);
    bool DeleteAllPokeMons();

}