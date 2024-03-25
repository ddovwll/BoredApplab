namespace BoredApp.Presenters;

public interface IMainPagePresenter
{
    Task GetActivityAsync();
    Task LikeAsync();
    Task CreateFavoritePageAsync();
}