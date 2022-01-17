using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Moq;
using PokeApi;
using PokeApi.DDD;
using PokeApi.Repository;
using Xunit;

namespace RepositoryTests
{
    public class RepositoryTests
    {
        #region PokeRepositoryTests
        [Fact]
        [Trait("Category", "Repository_Unit")]
        public void Is_PokeRepository_Creates_Valid_PokeMon()
        {

            //Arrange
            var pokemonMock = Return_PokemonMock();
            var repo = new Mock<IPokeMonRepository>();
            repo.Setup(x => x.Create(pokemonMock)).Returns(pokemonMock);

            //Act
           var sut= repo.Object.Create(pokemonMock);

            //Assert
            Assert_Pokemon(sut);
        }

        [Fact]
        [Trait("Category", "Repository_Unit")]
        public void Is_PokeRepository_Deletes_All_PokeMon()
        {

            //Arrange
            var pokemonMock = Return_PokemonMock();
            var repo = new Mock<IPokeMonRepository>();
            repo.Setup(x => x.DeleteAllPokeMons()).Returns(true);

            //Act
            var sut = repo.Object.DeleteAllPokeMons();

            //Assert
            Assert.True(sut);
        }
        [Fact]
        [Trait("Category", "Repository_Unit")]
        public void Is_PokeRepository_GetByPokeMonName_Returns_Valid_PokeMon()
        {

            //Arrange
            var pokemonMock = Return_PokemonMock();
            var repo = new Mock<IPokeMonRepository>();
            repo.Setup(x => x.GetByPokeMonName("Pikachu")).Returns(Return_PokemonMock);

            //Act
            var sut = repo.Object.GetByPokeMonName("Pikachu");

            //Assert
            Assert_Pokemon(sut);
        }

        #endregion

        #region BaseRepositoryTests
        [Fact]
        [Trait("Category", "Repository_Unit")]
        public void Is_BaseRepository_Returns_All_PokeMon()
        {

            //Arrange
            var pokemonMock = Return_PokemonMock();
            var repo = new Mock<IBaseRepository<PokeMon>>();
            repo.Setup(x => x.All()).Returns(Return_List_Of_PokemonMocks());

            //Act
            var sut = repo.Object.All();

            //Assert
            Assert_Pokemon_List(sut);
        }

       
        [Fact]
        [Trait("Category", "Repository_Unit")]
        public void Is_BaseRepository_Has_Delete_PokeMon()
        {

            //Arrange
            var pokemonMock = Return_PokemonMock();
            var repo = new Mock<IBaseRepository<PokeMon>>();
            repo.Setup(x => x.Delete(pokemonMock.Name)).Returns(true);


            //Act
           var sut= repo.Object.Delete(pokemonMock.Name);

            //Assert
           Assert.True(sut);
        }
         



        #endregion






        #region mock_functions_for_repositorytests
        private void Assert_Pokemon_List(IEnumerable<PokeMon> sut)
        {
            foreach (var value in sut) Assert_Pokemon(value);
        }
        private static void Assert_Pokemon(PokeMon pokemonMock)
        {
            Assert.Equal("SomeName", pokemonMock.Name);
            Assert.Equal("SomeDescription", pokemonMock.Description);
            Assert.Equal("SomeHabitat", pokemonMock.Habitat);
            Assert.True(pokemonMock.IsLegendary);
        }

        private static PokeMon Return_PokemonMock()
        {
            var pokemonMock = Mock.Of<PokeMon>(p =>
                p.Name == "SomeName" &&
                p.Description == "SomeDescription" &&
                p.Habitat == "SomeHabitat" &&
                p.IsLegendary == true
            );
            return pokemonMock;
        }
        private static IEnumerable<PokeMon>  Return_List_Of_PokemonMocks()
        {
            return Enumerable.Range(1, 2).Select(value => Return_PokemonMock());
        }
        #endregion
    }
}