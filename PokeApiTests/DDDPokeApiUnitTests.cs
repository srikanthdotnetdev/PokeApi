using System.Reflection;
using System.Threading.Tasks;
using Moq;
using PokeApi;
using PokeApi.DDD;
using Xunit;

namespace PokeApiTests
{
    public class DDDPokeApiUnitTests
    {
        [Fact]
        [Trait("Category", "Unit")]
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
        [Fact]
        [Trait("Category", "Unit")]
        public async Task Is_ReadPokeMon_Returns_PokeMon()
        {
            
            IReadPokeMon readInstance = new MockReadPokeMon();
             
            var instancePokeMon= await readInstance.GetPokeMonAsync("Pikachu",false);
            Assert.Equal("DummyName",instancePokeMon.Name);
            Assert.Equal("DummyDescription", instancePokeMon.Description);
            Assert.Equal("DummyHabitat", instancePokeMon.Habitat);
            Assert.False(instancePokeMon.IsLegendary);

        }


        


    }
}