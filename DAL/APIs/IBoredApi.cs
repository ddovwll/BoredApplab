namespace BoredApp.DAL.APIs;

public interface IBoredApi
{
    Task<HttpResponseMessage> GetResponseMessageAsync();
}