using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace ExpensesInfo.Models
{

    public class Expense
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Value { get; set; }

        [Required,MinLength(3)]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; } = DateTime.Today;

        [Display(Name = "Expense Type")]
        [Required]
        public int ExpenseTypeId { get; set; }

        public ExpenseTypes? ExpenseType { get; set; }
    }
    
}
