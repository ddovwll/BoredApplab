using BoredApp.DAL.Models;
using BoredApp.Views;

namespace BoredApp.Presenters;

public class FavoriteActivityPresenter : IFavoriteActivityPresenter
{
    private readonly IFavoriteActivityPage view;
    private readonly ActivityModelAbstract model;

    public FavoriteActivityPresenter(IFavoriteActivityPage view, ActivityModelAbstract model)
    {
        this.model = model;
        this.view = view;
    }

    public async Task DeleteActivityAsync()
    {
        await model.DeleteActivityAsync();
        await view.PopPageAsync();
    }

    public async Task<int> CompleteActivityAsync()
    {
        model.Completed += 1;
        await model.CompleteActivityAsync();
        return model.Completed;
    }

    public ActivityModelAbstract ShowActivity() => model;
}