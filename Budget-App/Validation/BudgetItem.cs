using System.ComponentModel.DataAnnotations;


namespace Budget_App.Validation
{
    public class BudgetItem
    {
        [Required(ErrorMessage = "Name can not be empty. Please add an item name")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please choose an amount larger than 0.")]
        public int Amount { get; set; }
        [Required]
        public bool IsShared { get; set; }
        [Range(0, 100, ErrorMessage = "Please choose a percentage between 0 and 100.")]
        public int SharedPercentage { get; set; }
        [Required]
        public string Type { get; set; }
        [Required(ErrorMessage ="Please choose an icon.")]
        public string IconClass { get; set; }
    }
}
