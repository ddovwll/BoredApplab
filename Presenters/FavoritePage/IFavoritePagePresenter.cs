using BoredApp.DAL.Models;
using BoredApp.Views;

namespace BoredApp.Presenters;

public interface IFavoritePagePresenter
{
    Task GetModelsAsync();
    Task GetModelsAsync(string type);
    Task CreateFAPageAsync(object model);
}