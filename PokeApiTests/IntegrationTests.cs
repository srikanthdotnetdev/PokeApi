using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Moq;
using PokeApi;
using PokeApi.DDD;
using PokeApi.Repository;
using Xunit;

namespace PokeApiTests
{
    public class IntegrationTests
    {
        private string _pokemonName = "pikachu";

        [Fact]
        [Trait("Category", "IntegrationTest")]
        public async Task? Is_ReadPokeMon_GetsValid_PokeMon()
        {
            var readRequest = new FakeReadPokeMon(true, new UrlData());
           
            var translatedPokeMon = await readRequest.GetPokeMonAsync(_pokemonName, false);
            Assert.Equal(_pokemonName, translatedPokeMon.Name);

        }
        [Fact]
        [Trait("Category", "IntegrationTest")]
        public async Task? Is_ReadPokeMon_GetsValid_TranslatedPokeMon()
        {
            var readRequest = new FakeReadPokeMon(true, new UrlData());

            var translatedPokeMon = await readRequest.GetPokeMonAsync(_pokemonName, true);
            Assert.Equal(_pokemonName, translatedPokeMon.Name);

        }

        [Fact]
        [Trait("Category", "IntegrationTest")]
        public void Can_ReadPokeMon_Deletes_PokeMon()
        {
            using var repo = new RepositoryAccessService(new MockDbContext(false));
            Assert.True(repo.PokeMonRepository.DeleteAllPokeMons());


        }
        [Fact]
        [Trait("Category", "IntegrationTest")]
        public void Can_ReadPokeMon_Deletes_TranslatedPokeMon()
        {
            using var repo = new RepositoryAccessService(new MockDbContext(true));
            Assert.True(repo.PokeMonRepository.DeleteAllPokeMons());


        }

    }
}
