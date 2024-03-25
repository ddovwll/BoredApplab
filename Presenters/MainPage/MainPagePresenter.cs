using BoredApp.DAL.Models;
using BoredApp.Views;

namespace BoredApp.Presenters;

public class MainPagePresenter : IMainPagePresenter
{
    private readonly IMainPage mainPage;
    private ActivityModelAbstract? activityModel;

    public MainPagePresenter(IMainPage mainPage)
    {
        this.mainPage = mainPage;
    }

    public async Task GetActivityAsync()
    {
        activityModel = await ActivityModelAbstract.GetActivityAsync();
        mainPage.ShowActivity(activityModel.Activity);
        mainPage.ShowAccessibility(activityModel.Accessibility);
        mainPage.ShowType(activityModel.Type);
        mainPage.ShowLink(activityModel.Link);
        mainPage.ShowParticipants(activityModel.Participants);
        mainPage.ShowPrice(activityModel.Price);
    }

    public async Task LikeAsync()
    {
        if (activityModel != null)
            await activityModel.LikeActivityAsync();
    }

    public async Task CreateFavoritePageAsync()
    {
        var favoritePage = new FavoritePage();
        await mainPage.ShowFavoritePageAsync(favoritePage);
    }
}