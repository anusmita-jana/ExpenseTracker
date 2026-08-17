using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Core.Interfaces;
public interface IExpenseService
{
  Task<ExpenseDto> CreateExpenseAsync(CreateExpenseDto request);
   
}