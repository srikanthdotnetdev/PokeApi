using Newtonsoft.Json;
using PokeApi.Repository;
using PokeApiNet;
using RestSharp;

namespace PokeApi.DDD;

public partial class ReadPokeMon : IReadPokeMon
{
    
    private PokeMon? builtPokeMon;
  
     
    private readonly string _shakespeareUrl;
    private readonly string _yodaUrl;

    public ReadPokeMon(bool translationFlag, IUrlData Data )
    {

      _shakespeareUrl=  Data.ShakespeareUrl;
      _yodaUrl = Data.YodaUrl;

    }
    public async Task<PokeMon> GetPokeMonAsync(string pokemonName,bool translationFlag)
    {
        void TranslatePokeMonFromWebApi(PokeMon pokemonFromWebApi, out string url, out Task<RestResponse> response)
        {
           
            if (pokemonFromWebApi.IsLegendary || pokemonFromWebApi.Habitat.Equals("cave"))
            {
                url = _yodaUrl;
            }
            else
            {
                url = _shakespeareUrl;
            }

            response = GetFunTranslation(url, pokemonFromWebApi.Description);
            if (response.Result != null)
            {
                var DeserializedResult = JsonConvert.DeserializeObject<SerializedMessage>(response.Result.Content);
                pokemonFromWebApi.Description = DeserializedResult.contents.translated;
            }
        }


        async Task<PokeMon> BuiltPokeMonAsync()
        {
            try
            {
                var checkResult = await CheckForPokemonExistenceInWebApiAsync(pokemonName);
                if (checkResult)
                {
                    return builtPokeMon;
                }
                else
                {
                    return new PokeMon { Name = pokemonName, Description = "CheckFailed", Habitat = "CheckFailed" };
                }
            }
            catch (Exception ex)
            {
                return new PokeMon { Name = pokemonName, Description = ex.Message, Habitat = "DoesNotExist" };
            }
        }

        #region  LogicForCheckingExistingDataInstance
        using var repo = new RepositoryAccessService(new DbContext(translationFlag));
        
        var instancePokeMon = repo.PokeMonRepository.GetByPokeMonName(pokemonName);
        #endregion
        
        #region FetchigDataFromApi

        if (instancePokeMon != null)
        {
            return instancePokeMon;
        }
        else
        {
            var pokemonFromWebApi =await BuiltPokeMonAsync();
            #region WriteToDatabaseIfNotExist

            if (pokemonFromWebApi.Habitat.Equals("DoesNotExist") || pokemonFromWebApi.Habitat.Equals("CheckFailed"))
            {
                return pokemonFromWebApi;
            }

            if (translationFlag)
            {
                TranslatePokeMonFromWebApi(pokemonFromWebApi, out var url, out var response);


                return repo.PokeMonRepository.Create(pokemonFromWebApi);
            }
            
            else
            {
                return repo.PokeMonRepository.Create(pokemonFromWebApi);
            }

            #endregion
        }
        #endregion
    }


    public async Task<RestResponse> GetFunTranslation(string url,string queryParam)
    {
        var client = new RestClient();
        var request = new RestRequest(url, Method.Post);
        request.AddParameter("text",queryParam);
        //client.

        return await client.ExecuteAsync(request);

         

    }


    private async Task<bool> CheckForPokemonExistenceInWebApiAsync(string pokemonName)
    {
        // instantiate client
        var pokeClient = new PokeApiClient();

        // get a resource by name
        var requestedPokemon = await pokeClient.GetResourceAsync<Pokemon>(pokemonName);
        if (requestedPokemon == null) throw new ArgumentNullException(nameof(requestedPokemon));
        if (await pokeClient.GetResourceAsync(requestedPokemon.Species) is { } species)
        {
            var descriptions = species.FlavorTextEntries.FirstOrDefault();
            var description = "";

            var habitat = species.Habitat?.Name ?? "NotFound";
            description = descriptions?.FlavorText ?? "NotFound";

            builtPokeMon = new PokeMon
            {
                Name = requestedPokemon.Name,
                Description = description,

                Habitat = habitat,
                IsLegendary = species.IsLegendary

            };
            return true;
        }
        else return false;


    }

    
    
}