import { useEffect, useState } from "react";
import type { Expense } from "../types/Expense";
import { getExpenses } from "../services/expenseService";
import ExpenseCard from "./ExpenseCard";

function ExpenseList() {
  const [expenses, setExpenses] = useState<Expense[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getExpenses()
      .then((data) => {
        setExpenses(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching expenses:", error);
        setError("Failed to load expenses.");
        setLoading(false);
      });
  }, []);

  return (
    <div>
      <h2>Expenses</h2>

      {loading ? (
        <p>Loading expenses...</p>
      ) : error ? (
        <p>{error}</p>
      ) : expenses.length === 0 ? (
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