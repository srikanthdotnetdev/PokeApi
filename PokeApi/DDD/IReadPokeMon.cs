namespace PokeApi.DDD;

public interface IReadPokeMon
{
    public Task<PokeMon> GetPokeMonAsync(string pokemonName, bool translationFlag);
}