using ExpensesInfo.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
namespace ExpensesInfo.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly ExpensesInfoDbContext _context;
        public ExpenseTypeService(ExpensesInfoDbContext context) => _context =
       context;
        public async Task<List<ExpenseTypes>> GetAllAsync()
        {
            return await _context.ExpenseTypes.ToListAsync();
        }
        public async Task<ExpenseTypes?> GetByIdAsync(int id)
        {
            return await _context.ExpenseTypes.SingleOrDefaultAsync(t => t.Id
           == id);
        }
        public async Task CreateAsync(ExpenseTypes type)
        {
            _context.ExpenseTypes.Add(type);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ExpenseTypes type)
        {
            var existing = await _context.ExpenseTypes.SingleOrDefaultAsync(t
           => t.Id == type.Id);
            if (existing == null) return;
            existing.Name = type.Name;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var existing = await _context.ExpenseTypes.SingleOrDefaultAsync(t
           => t.Id == id);
            if (existing == null) return;
            _context.ExpenseTypes.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExpenseTypes>> GetAllTypesAsync()
        {
            return await _context.ExpenseTypes.ToListAsync();
        }

        public async Task<decimal> GetTotalAsync(int? typeId)
        {
            var query = _context.Expenses.AsQueryable();
            if (typeId.HasValue)
            {
                query = query.Where(e => e.ExpenseTypeId == typeId.Value);
            }
            var list = await query.ToListAsync();
            return list.Sum(e=>e.Value);
        }
    }
}