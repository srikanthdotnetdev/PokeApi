using System.Reflection;
using Moq;
using PokeApi;
using PokeApi.DDD;
using Xunit;

namespace PokeApiTests
{
    public class PokeApiTUnitTests
    {
        [Fact]
        public void Is_PokeApi_Returns_Valid_PokeMon()
        {
            
            //Arrange
            var pokemonMock = Mock.Of<PokeMon>();
            Assert.Null(pokemonMock.Name);
            Assert.Null(pokemonMock.Description);
            Assert.Null(pokemonMock.Habitat);
            Assert.False(pokemonMock.IsLegendary);

            //Act
             pokemonMock = Mock.Of<PokeMon>(p =>
                 p.Name == "SomeName" && 
                 p.Description == "SomeDescription" &&
                 p.Habitat == "SomeHabitat" &&
                 p.IsLegendary == true
                 );

            //Assert
            Assert.Equal("SomeName", pokemonMock.Name);
            Assert.Equal("SomeDescription", pokemonMock.Description);
            Assert.Equal("SomeHabitat", pokemonMock.Habitat);
            Assert.True(pokemonMock.IsLegendary);

        }
    }
}