namespace PokeApi.DDD;

public class UrlData : IUrlData
{
    public string ShakespeareUrl { get; }
    public string YodaUrl { get; }

    public UrlData()
    {
        ShakespeareUrl = "https://api.funtranslations.com/translate/shakespeare.json";
        YodaUrl = "https://api.funtranslations.com/translate/yoda.json";

    }
}