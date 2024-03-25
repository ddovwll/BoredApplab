using BoredApp.DAL.Models;
using SQLite;
using FileSystem = Microsoft.Maui.Storage.FileSystem;

namespace BoredApp.DAL;

public class ActivityDbContext : IActivityDbContext
{
    private static ActivityDbContext instance;
    private static readonly Object locker = new();

    private ActivityDbContext()
    {
        
    }

    public static ActivityDbContext GetInstance()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if(instance == null)
                    instance = new ActivityDbContext();
            }
        }
        return instance;
    }
    
    private const string DatabaseFilename = "BoredApp.db3";

    private const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache |
        
        SQLiteOpenFlags.FullMutex;

    private static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    
    
    private SQLiteAsyncConnection Database;

    private async Task Init()
    {
        if (Database is not null)
            return;
        Database = new SQLiteAsyncConnection(DatabasePath, Flags);
        var result = await Database.CreateTableAsync<ActivityModel>();
    }
    
    public async Task<List<ActivityModel>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<ActivityModel>().ToListAsync();
    }

    public async Task<ActivityModel> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<ActivityModel>().Where(i => i.Key == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(ActivityModel item)
    {
        await Init();
        if (await GetItemAsync(item.Key)!=null)
            return await Database.UpdateAsync(item);
        return await Database.InsertAsync(item);
    }

    public async Task<int> DeleteItemAsync(ActivityModel item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}