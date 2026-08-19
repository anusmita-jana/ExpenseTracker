using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Core.Interfaces;
public interface IExpenseService
{
  Task<ExpenseDto> CreateExpenseAsync(CreateExpenseDto request);

  Task<IEnumerable<ExpenseDto>> GetExpensesAsync();
  Task<ExpenseDto?> GetExpenseById(Guid id) ;  
  Task<ExpenseDto?> UpdateExpense(Guid id,UpdateExpenseDto request);
}