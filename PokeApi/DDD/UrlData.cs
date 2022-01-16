namespace PokeApi.DDD;

public class UrlData : IUrlData
{
    public string ShakespearUrl { get; }
    public string YodaUrl { get; }

    public UrlData()
    {
        ShakespearUrl = "https://api.funtranslations.com/translate/shakespeare.json";
        YodaUrl = "https://api.funtranslations.com/translate/yoda.json";

    }
}