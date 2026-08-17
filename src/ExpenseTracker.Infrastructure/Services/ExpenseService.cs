using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Data;

namespace ExpenseTracker.Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _context;

    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ExpenseDto> CreateExpenseAsync(CreateExpenseDto request)
    {
        var expense = new Expense
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Category = request.Category,
            Description = request.Description,
            ExpenseDate = DateTime.UtcNow
        };
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
        return new ExpenseDto
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Category = expense.Category,
            Description = expense.Description,
            ExpenseDate = expense.ExpenseDate
            
        };
    }
}