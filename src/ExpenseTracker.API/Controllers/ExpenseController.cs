using ExpenseTracker.Core.DTOs;
using ExpenseTracker.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ExpenseTracker.API.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ExpenseController: ControllerBase
{
    private readonly IExpenseService _expenseService;
    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpPost]

    public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseDto request)
    {
       var expense = await _expenseService.CreateExpenseAsync(request);

       return CreatedAtAction(
        nameof(CreateExpense),
        new { id = expense.Id },
        expense);
    }

    [HttpGet]
    public async Task<IActionResult> GetExpenses()
    {
        var expenses = await _expenseService.GetExpensesAsync();
        return Ok(expenses);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetExpenseById(Guid id)
    {
        var expense = await _expenseService.GetExpenseById(id);
        if(expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }

    [HttpPut("{id:guid}")]

    public async Task<IActionResult> UpdateExpense(Guid id, UpdateExpenseDto request)
    {
        var expense = await _expenseService.UpdateExpense(id,request);
        if(expense == null)
        {
            return NotFound();
        }

        return Ok(expense);
    }

    [HttpDelete("{id:guid}")]

    public async Task<IActionResult> DeleteExpense(Guid id)
    {
        var deleted = await _expenseService.DeleteExpense(id);
        if(!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

}