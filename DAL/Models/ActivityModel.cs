namespace BoredApp.DAL.Models;

public class ActivityModel : ActivityModelAbstract
{
    private readonly IActivityDbContext dataBase = ActivityDbContext.GetInstance();

    public override async Task LikeActivityAsync()
        => await dataBase.SaveItemAsync(this);

    public override async Task DeleteActivityAsync()
        => await dataBase.DeleteItemAsync(this);

    public override async Task CompleteActivityAsync()
        => await dataBase.SaveItemAsync(this);
}