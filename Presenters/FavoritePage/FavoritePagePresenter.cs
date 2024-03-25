using BoredApp.DAL.Models;
using BoredApp.Views;

namespace BoredApp.Presenters;

public class FavoritePagePresenter : IFavoritePagePresenter
{
    private readonly IFavoritePage favoritePage;

    public FavoritePagePresenter(IFavoritePage favoritePage)
    {
        this.favoritePage = favoritePage;
    }
    
    public async Task GetModelsAsync()
    {
        var models = await ActivityModelAbstract.GetModelsAsync();
        favoritePage.ShowFavoriteAsync(models.OrderBy(m=>m.Completed).ToList());
    }

    public async Task GetModelsAsync(string type)
    {
        var models = await ActivityModelAbstract.GetModelsAsync();
        if (type == "" || type == null)
        {
            favoritePage.ShowFavoriteAsync(models.OrderBy(m=>m.Completed).ToList());
            return;
        }
        favoritePage.ShowFavoriteAsync(models.Where(m => m.Type.StartsWith(type)).ToList());
    }

    public async Task CreateFAPageAsync(object model)
    {
        var favoriteActivityPage = new FavoriteActivityPage((ActivityModelAbstract)model);
        await favoritePage.CreateFAPageAsync(favoriteActivityPage);
    }
}