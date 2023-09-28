using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App.Models
{
    public class Section
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string SectionName { get; set; }
      
    }
}
