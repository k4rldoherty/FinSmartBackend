namespace FinSmartBackend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool IsIncome { get; set; }

        // Navigation Properties 
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expenditure> Expenditures { get; set; }
        public ICollection<BudgetPlan> BudgetPlans { get; set; }
    }
}
