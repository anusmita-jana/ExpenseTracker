using System.ComponentModel.DataAnnotations;
namespace ExpenseTracker.Core.DTOs;


public class CreateExpenseDto
{
    
    [Required]
    [Range(0.01, double.MaxValue , ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }
    [Required]
    [StringLength(50)]
    public required string Category { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

}
