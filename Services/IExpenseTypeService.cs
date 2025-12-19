using ExpensesInfo.Models;

namespace ExpensesInfo.Services
{
    public interface IExpenseTypeService
    {
        Task<List<ExpenseTypes>> GetAllAsync();
        Task<ExpenseTypes?> GetByIdAsync(int id);
        Task CreateAsync(ExpenseTypes expenseType);
        Task UpdateAsync(ExpenseTypes expenseType);
        Task DeleteAsync(int id);
    }
}
