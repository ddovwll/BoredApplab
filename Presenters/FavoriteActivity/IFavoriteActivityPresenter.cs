using BoredApp.DAL.Models;

namespace BoredApp.Presenters;

public interface IFavoriteActivityPresenter
{
    Task DeleteActivityAsync();
    Task<int> CompleteActivityAsync();
    ActivityModelAbstract ShowActivity();
}