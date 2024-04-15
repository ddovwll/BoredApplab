using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoredApp.DAL.APIs;

public class YaTranslateApi : IYaTranslateApi
{
    private static YaTranslateApi? instance;

    private static object locker = new();

    private YaTranslateApi()
    {
        
    }

    public static YaTranslateApi Init()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if(instance == null)
                {
                    instance = new YaTranslateApi();
                    instance.AddHeaders();
                }
            }
        }

        return instance;
    }

    private readonly HttpClient client = new();

    private void AddHeaders()
    {
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("Authorization", $"Api-Key");
    }
    
    public async Task<string> TranslateAsync(string originalText)
    {
        string url = "https://translate.api.cloud.yandex.net/translate/v2/translate";
        
        var body = new
        {
            targetLanguageCode = "ru",
            texts = originalText,
        };

        string jsonBody = JsonConvert.SerializeObject(body);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync(url, content);
        
        dynamic responseContent = await response.Content.ReadAsStringAsync();

        var translated = "";
        
        JObject json;
        json = JObject.Parse(responseContent);
        foreach (var val in json["translations"])
        {
            translated += val["text"];
        }

        return translated;
    }
}
