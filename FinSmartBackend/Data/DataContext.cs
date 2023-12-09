using FinSmartBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinSmartBackend.Data
{
    public class DataContext : IdentityDbContext // For User Authentication.
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<BudgetPlan> BudgetPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Income>()
                .Property(i => i.Amount)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Expenditure>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(10,2)");
        }
    }
}
