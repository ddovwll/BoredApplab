using BoredApp.DAL.Models;
using BoredApp.Presenters;

namespace BoredApp.Views;

public partial class FavoritePage : ContentPage, IFavoritePage
{
    private readonly IFavoritePagePresenter presenter;
    public FavoritePage()
    {
        InitializeComponent();
        presenter = new FavoritePagePresenter(this);
    }
    
    public void ShowFavoriteAsync(List<ActivityModel> models)
    {
        ListView listView = new ListView { ItemsSource = models };
        listView.ItemTemplate = new DataTemplate(()=>
            {
                var viewCell = new ViewCell();
                var label = new Label();
                label.SetBinding(Label.TextProperty, "Activity");
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += async (s, e) =>
                {
                    await presenter.CreateFAPageAsync(label.BindingContext);
                };
                label.GestureRecognizers.Add(tapGestureRecognizer);
                viewCell.View = label;
                return viewCell;
            }
        );
        StackLayout.Children.Add(listView);
    }

    public async Task CreateFAPageAsync(IFavoriteActivityPage FApage)
        => await Navigation.PushModalAsync((FavoriteActivityPage)FApage);

    private void Search_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        StackLayout.Children.RemoveAt(2);
        presenter.GetModelsAsync(Search.Text);
    }

    private async void FavoritePage_OnAppearing(object? sender, EventArgs e)
    {
        StackLayout.Children.RemoveAt(2);
        await presenter.GetModelsAsync();
    }
}