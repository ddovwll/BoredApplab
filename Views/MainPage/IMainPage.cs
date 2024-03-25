namespace BoredApp.Views;

public interface IMainPage
{
    void ShowActivity(string activity);
    void ShowType(string type);
    void ShowParticipants(double participants);
    void ShowPrice(double price);
    void ShowLink(string? link);
    void ShowAccessibility(double accessibility);
    Task ShowFavoritePageAsync(IFavoritePage favoritePage);
}