namespace ExpenseTracker.Core.DTOs;

public class CreateExpenseDTO
{
    public decimal Amount { get; set; }

    public required string Category { get; set; }

    public string? Description { get; set; }
}
