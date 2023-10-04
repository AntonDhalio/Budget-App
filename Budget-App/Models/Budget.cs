using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_App.Models
{
    public class Budget
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool IsShared { get; set; }
        public string Type { get; set; }
        public string IconName { get; set; }
        [Indexed]
        public int SectionId { get; set; }
        
    }
}
