namespace ExpenseTracker.Core.Entities;
public class Expense
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public required string Category { get; set; }

    public string? Description { get; set; }

    public DateTime ExpenseDate { get; set; }
}