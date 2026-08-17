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

}