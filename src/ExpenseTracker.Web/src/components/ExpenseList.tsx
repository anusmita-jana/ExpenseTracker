import { useEffect, useState } from "react";
import type { Expense } from "../types/Expense";
import { getExpenses } from "../services/expenseService";
import ExpenseCard from "./ExpenseCard";

function ExpenseList() {
  const [expenses, setExpenses] = useState<Expense[]>([]);

  useEffect(() => {
    getExpenses()
      .then((data) => setExpenses(data))
      .catch((error) =>
        console.error("Error fetching expenses:", error)
      );
  }, []);

  return (
    <div>
      <h2>Expenses</h2>

      {expenses.length === 0 ? (
        <p>No expenses found.</p>
      ) : (
        <ul>
          {expenses.map((expense) => (
            <ExpenseCard
              key={expense.id}
              expense={expense}
            />
          ))}
        </ul>
      )}
    </div>
  );
}

export default ExpenseList;