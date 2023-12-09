namespace FinSmartBackend.Models
{
    public class BudgetPlan
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public int PlannedAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation Properties 
        public Category Category { get; set; }
    }
}
