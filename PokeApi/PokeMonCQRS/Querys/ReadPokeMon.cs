namespace PokeApi;

public partial class ReadPokeMon
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