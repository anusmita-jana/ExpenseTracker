import type { Expense } from "../types/Expense";

const API_URL = "http://localhost:5234/api/expense";

export async function getExpenses(): Promise<Expense[]> {
  const response = await fetch(API_URL);

  if (!response.ok) {
    throw new Error("Failed to fetch expenses");
  }

  return response.json();
}