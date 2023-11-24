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
        public static async Task AddBudgetItem(string name, int amount, bool isShared, string type, int sharedPercentage,string iconName,int id)
        {
            await Init();
            var item = new Budget
            {
                Name = name,
                Amount = amount,
                IsShared = isShared,
                Type = type,
                SharedPercentage = sharedPercentage,
                IconName = iconName,
                SectionId = id,
                IsActive = true
            };

            await db.InsertAsync(item);
        }
        public static async Task UpdateBudgetItem(string name, int amount, bool isShared, string type, int sharedPercentage, string iconName, int id)
        {
            await Init();
            Budget existingBudgetItem = await db.GetAsync<Budget>(id);
            existingBudgetItem.Name = name;
            existingBudgetItem.Amount = amount;
            existingBudgetItem.IsShared = isShared;
            existingBudgetItem.Type = type;
            existingBudgetItem.SharedPercentage = sharedPercentage;
            existingBudgetItem.IconName = iconName;

            await db.UpdateAsync(existingBudgetItem);
        }
        public static async Task ToggleItemActivityStatus(int id)
        {
            await Init();
            Budget existingBudgetItem = await db.GetAsync<Budget>(id);
            
            existingBudgetItem.IsActive = !existingBudgetItem.IsActive;

            await db.UpdateAsync(existingBudgetItem);
        }
        public static async Task RemoveBudgetItem(int id)
        {
            await Init();
            await db.DeleteAsync<Budget>(id);
        }
        public static async Task<IEnumerable<Budget>> GetAllBudgetItems()
        {
            await Init();
            var budget = await db.Table<Budget>().ToListAsync();
            return budget;
        } 
        public static async Task<IEnumerable<Budget>> GetBudgetItemsBySection(int section)
        {
            await Init();
            var budget = await db.Table<Budget>().ToListAsync();
            var items = budget.Where(item => item.SectionId == section);
            return items;
        }

        public static async Task<IEnumerable<Budget>> GetIncomeBudgetItems()
        {
            await Init();
            var budget = await db.Table<Budget>().ToListAsync();
            var incomeItems = budget.Where(item => item.Type == "Income");
            return incomeItems;
        }
        public static async Task<IEnumerable<Budget>> GetExpenseBudgetItems()
        {
            await Init();
            var budget = await db.Table<Budget>().ToListAsync();
            var expenseItems = budget.Where(item => item.Type == "Expense");
            return expenseItems;
        }
        public static async Task AddSection(string sectionName, string colorCode)
        {
            await Init();
            var item = new Section
            {
                SectionName = sectionName,
                SectionColor = colorCode
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
