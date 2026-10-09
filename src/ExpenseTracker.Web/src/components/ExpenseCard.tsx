import type { Expense } from "../types/Expense";

interface ExpenseCardProps {
  expense: Expense;
}

function ExpenseCard({ expense }: ExpenseCardProps) {
  return (
    <li>
      <h3>{expense.category}</h3>

      <p>Amount: £{expense.amount.toFixed(2)}</p>

      <p>
        Description: {expense.description || "No description"}
      </p>

      <p>Date: {expense.expenseDate}</p>
    </li>
  );
}

export default ExpenseCard;