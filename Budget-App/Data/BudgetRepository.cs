using Budget_App.Models;
using SQLite;

namespace Budget_App.Data
{
    public class BudgetRepository
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null) {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyDatabase.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Budget>();
            await db.CreateTableAsync<Section>();
        }
        public static async Task AddBudgetItem(string name, int amount, bool isShared, int id)
        {
            await Init();
            var item = new Budget
            {
                Name = name,
                Amount = amount,
                IsShared = isShared,
                SectionId = id
            };

            await db.InsertAsync(item);
        }
        public static async Task RemoveBudgetItem(int id)
        {
            await Init();
            await db.DeleteAsync<Budget>(id);
        }
        public static async Task<IEnumerable<Budget>> GetBudgetItems()
        {
            await Init();
            var budget = await db.Table<Budget>().ToListAsync();
            return budget;
        }
        public static async Task AddSection(string sectionName)
        {
            await Init();
            var item = new Section
            {
                SectionName = sectionName,
            };

            await db.InsertAsync(item);
        }
        public static async Task RemoveSection(int id)
        {
            await Init();
            await db.DeleteAsync<Section>(id);
        }
        public static async Task<IEnumerable<Section>> GetAllSections()
        {
            await Init();
            var sections = await db.Table<Section>().ToListAsync();
            return sections;
        }
    }
}
