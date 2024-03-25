using BoredApp.DAL.Models;
using BoredApp.Presenters;

namespace BoredApp.Views;

public partial class FavoriteActivityPage : ContentPage, IFavoriteActivityPage
{
    private readonly IFavoriteActivityPresenter presenter;
    
    public FavoriteActivityPage(ActivityModelAbstract model)
    {
        InitializeComponent();
        presenter = new FavoriteActivityPresenter(this, model);
    }

    private async void DeleteButton_OnClicked(object? sender, EventArgs e) 
        => await presenter.DeleteActivityAsync();

    private async void CompleteButton_OnClicked(object? sender, EventArgs e)
    {
        var completed = await presenter.CompleteActivityAsync();
        Completed.Text = completed.ToString();
    }

    private void FavoriteActivity_OnAppearing(object? sender, EventArgs e)
    {
        var model = presenter.ShowActivity();
        Activity.Text = model.Activity;
        Type.Text = model.Type;
        Participants.Value = model.Participants;
        Price.Value = model.Price;
        Link.Text = model.Link;
        Accessibility.Value = model.Accessibility;
        Completed.Text = model.Completed.ToString();
    }

    public async Task PopPageAsync() => await Navigation.PopModalAsync();
}