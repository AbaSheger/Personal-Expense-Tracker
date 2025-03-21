using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using MathNet.Numerics.LinearRegression; // Added for AI-related libraries

namespace PersonalExpenseTracker
{
    public class ExpenseManager
    {
        private List<Expense> expenses;

        public ExpenseManager()
        {
            expenses = new List<Expense>();
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public void UpdateExpense(Expense updatedExpense)
        {
            var existingExpense = expenses.FirstOrDefault(e => e.Date == updatedExpense.Date && e.Description == updatedExpense.Description);
            if (existingExpense != null)
            {
                existingExpense.Amount = updatedExpense.Amount;
                existingExpense.Category = updatedExpense.Category;
                existingExpense.Date = updatedExpense.Date;
                existingExpense.Description = updatedExpense.Description;
            }
        }

        public void RemoveExpense(Expense expense)
        {
            expenses.Remove(expense);
        }

        public List<Expense> GetExpenses()
        {
            return expenses;
        }

        public List<Expense> GetExpensesByCategory(CategoryEnum category)
        {
            return expenses.Where(e => e.Category == category).ToList();
        }

        public decimal GetTotalExpenses()
        {
            return expenses.Sum(e => e.Amount);
        }

        public decimal GetTotalExpensesByCategory(CategoryEnum category)
        {
            return expenses.Where(e => e.Category == category).Sum(e => e.Amount);
        }

        public Dictionary<CategoryEnum, decimal> GetExpenseSummaryByCategory()
        {
            return expenses.GroupBy(e => e.Category)
                           .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));
        }

        public Dictionary<DateTime, decimal> GetExpenseSummaryByDate()
        {
            return expenses.GroupBy(e => e.Date.Date)
                           .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));
        }

        public void SaveExpensesToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(expenses);
            File.WriteAllText(filePath, json);
        }

        public void LoadExpensesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                expenses = JsonSerializer.Deserialize<List<Expense>>(json);
            }
        }

        public List<decimal> PredictFutureExpenses(int months)
        {
            var expenseSummaryByDate = GetExpenseSummaryByDate();
            var dates = expenseSummaryByDate.Keys.Select(date => (double)date.ToOADate()).ToArray();
            var amounts = expenseSummaryByDate.Values.Select(amount => (double)amount).ToArray();

            var model = SimpleRegression.Fit(dates, amounts);

            var futureExpenses = new List<decimal>();
            for (int i = 1; i <= months; i++)
            {
                var futureDate = DateTime.Now.AddMonths(i).ToOADate();
                var predictedAmount = model.Predict(futureDate);
                futureExpenses.Add((decimal)predictedAmount);
            }

            return futureExpenses;
        }
    }
}
