namespace BoredApp.DAL.APIs;

public class BoredApi : IBoredApi
{
    private static BoredApi? instance;

    private static Object locker = new();

    private BoredApi()
    {
        
    }

    public static BoredApi Init()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if(instance == null)
                    instance = new BoredApi();
            }
        }

        return instance;
    }
    
    private readonly HttpClient client = new();

    public async Task<HttpResponseMessage> GetResponseMessageAsync()
        => await client.GetAsync("https://www.boredapi.com/api/activity/");
}