using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<ExpenseDto>> GetExpensesAsync()
    {
        var expenses = await _context.Expenses 
        .AsNoTracking().ToListAsync();

        return expenses.Select(expense => new ExpenseDto
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Category = expense.Category,
            Description = expense.Description,
            ExpenseDate = expense.ExpenseDate
            
        } 
        );
        
    }

    public async Task<ExpenseDto?> GetExpenseById(Guid id)
    {
        var expense = await _context.Expenses .AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        if(expense == null)
        {
            return null;
        }
        return new ExpenseDto
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Category = expense.Category,
            Description = expense.Description,
            ExpenseDate = expense.ExpenseDate
            
        };
    }

    public async Task<ExpenseDto?> UpdateExpense(Guid id, UpdateExpenseDto request)
    {
        var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if(expense == null)
        {
            return null;
        }

        expense.Amount = request.Amount;
        expense.Category = request.Category;
        expense.Description = request.Description;

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

    public async Task<bool> DeleteExpense(Guid id)
    {
        var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if(expense == null)
        {
            return false;
        }
        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        return true;
    }
}