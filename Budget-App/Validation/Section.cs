using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_App.Validation
{
    public class Section
    {
        [Required(ErrorMessage = "Name can not be empty. Please add a section name")]
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
