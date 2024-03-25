using BoredApp.DAL.APIs;
using Newtonsoft.Json;
using SQLite;

namespace BoredApp.DAL.Models;

public abstract class ActivityModelAbstract
{
    public string Activity { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Participants { get; set; }
    public double Price { get; set; }
    public string? Link { get; set; }
    [PrimaryKey]
    public int Key { get; set; }
    public double Accessibility { get; set; }
    public int Completed { get; set; }
    
    public abstract Task DeleteActivityAsync();
    public abstract Task CompleteActivityAsync();
    public abstract Task LikeActivityAsync();
    
    public static async Task<List<ActivityModel>> GetModelsAsync()
    {
        IActivityDbContext dataBase = ActivityDbContext.GetInstance();
        return await dataBase.GetItemsAsync();
    }
    
    public static async Task<ActivityModel> GetActivityAsync()
    {
        IBoredApi boredApi = BoredApi.Init();
        var response = await boredApi.GetResponseMessageAsync();
        if (!response.IsSuccessStatusCode)
            return new ActivityModel();
        var data = await response.Content.ReadAsStringAsync();
        var model =  JsonConvert.DeserializeObject<ActivityModel>(data)!;
        IYaTranslateApi yaTranslateApi =YaTranslateApi.Init();
        model.Activity = await yaTranslateApi.TranslateAsync(model.Activity);
        model.Type = await yaTranslateApi.TranslateAsync(model.Type);
        return model;
    }
}