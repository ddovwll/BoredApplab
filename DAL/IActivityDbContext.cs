using BoredApp.DAL.Models;

namespace BoredApp.DAL;

public interface IActivityDbContext
{
    Task<List<ActivityModel>> GetItemsAsync();
    Task<ActivityModel> GetItemAsync(int id);
    Task<int> SaveItemAsync(ActivityModel item);
    Task<int> DeleteItemAsync(ActivityModel item);
}