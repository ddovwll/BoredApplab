namespace BoredApp.DAL.APIs;

public interface IYaTranslateApi
{
    Task<string> TranslateAsync(string originalText);
}