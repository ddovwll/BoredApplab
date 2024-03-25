using BoredApp.Presenters;
namespace BoredApp.Views;

public partial class MainPage : ContentPage, IMainPage
{
    private readonly IMainPagePresenter presenter;
    
    public MainPage()
    {
        InitializeComponent();
        presenter = new MainPagePresenter(this);
    }  

    private async void ImageButton_OnClicked(object sender, EventArgs e) 
        => await presenter.LikeAsync();
    
    private async void GenerateButton_OnClicked(object sender, EventArgs e)
        => await presenter.GetActivityAsync();
    
    private async void FavoritesButton_OnClicked(object sender, EventArgs e) 
        => await presenter.CreateFavoritePageAsync();
    
    public void ShowActivity(string activity) => Activity.Text = activity;
    
    public void ShowType(string type) => Type.Text = type;

    public void ShowParticipants(double participants) => Participants.Value = participants;

    public void ShowPrice(double price) => Price.Value = price;

    public void ShowLink(string? link) => Link.Text = link;

    public void ShowAccessibility(double accessibility) => Accessibility.Value = accessibility;

    public async Task ShowFavoritePageAsync(IFavoritePage favoritePage)
        => await Navigation.PushModalAsync((FavoritePage)favoritePage);
}