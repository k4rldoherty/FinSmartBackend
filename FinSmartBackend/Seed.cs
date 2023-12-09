using FinSmartBackend.Data; // Adjust the namespace based on your project structure
using FinSmartBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

public class SeedData
{
    public void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DataContext(
            serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
        {
            // Check if there is existing data
            if (context.Categories.Any() || context.Incomes.Any() || context.Expenditures.Any() || context.BudgetPlans.Any())
            {
                return; // Database has already been seeded
            }

            // Add test user
            var userId = "1d689bdb-1b8a-4c4b-8061-cc64658e72bd";

            // Seed Categories
            var categories = new List<Category>
            {
                new Category { UserId = userId, Name = "Salary", IsIncome = true },
                new Category { UserId = userId, Name = "Rent", IsIncome = false },
                new Category { UserId = userId, Name = "Groceries", IsIncome = false }
                // Add more categories as needed
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // Seed Incomes
            var incomes = new List<Income>
            {
                new Income { UserId = userId, Description = "Monthly Salary", Amount = 5000, Date = DateTime.Now, Category = categories[0] },
                new Income { UserId = userId, Description = "Bonus", Amount = 1000, Date = DateTime.Now, Category = categories[0] }
                // Add more incomes as needed
            };
            context.Incomes.AddRange(incomes);
            context.SaveChanges();

            // Seed Expenditures
            var expenditures = new List<Expenditure>
            {
                new Expenditure { UserId = userId, Description = "Rent Payment", Amount = 1200, Date = DateTime.Now, Category = categories[1] },
                new Expenditure { UserId = userId, Description = "Grocery Shopping", Amount = 200, Date = DateTime.Now, Category = categories[2] }
                // Add more expenditures as needed
            };
            context.Expenditures.AddRange(expenditures);
            context.SaveChanges();

            // Seed BudgetPlans
            var budgetPlans = new List<BudgetPlan>
            {
                new BudgetPlan { UserId = userId, CategoryId = 1, PlannedAmount = 4500, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) },
                new BudgetPlan { UserId = userId, CategoryId = 2, PlannedAmount = 1000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(3) }
                // Add more budget plans as needed
            };
            context.BudgetPlans.AddRange(budgetPlans);
            context.SaveChanges();
        }
    }
}
