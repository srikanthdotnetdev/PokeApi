namespace PokeApi;

public partial class Query
{
    public PokeMon GetPokeMon() =>
        new PokeMon
        {
            Name = "PokeMonName",
            Description = "SomeDescription",
            Habitat = "SomeHabitat",
            IsLegendary = false
        };
}