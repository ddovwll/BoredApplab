using BoredApp.DAL.Models;

namespace BoredApp.Views;

public interface IFavoritePage
{
    void ShowFavoriteAsync(List<ActivityModel> models);
    Task CreateFAPageAsync(IFavoriteActivityPage FApage);
}