namespace PokeApi.DDD
{
    public class PokeMon
    {
        /// <summary>
        /// Name as Primary Key
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Pokemon Description taken from flavorText
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Pokemon Habitat
        /// </summary>
        public string? Habitat { get; set; }
        /// <summary>
        /// Pokemon boolean value of legendary 
        /// </summary>
        public bool IsLegendary { get; set; } = false;
        /// <summary>
        /// Pokemon boolean value of legendary 
        /// </summary>
        
    }
    
}