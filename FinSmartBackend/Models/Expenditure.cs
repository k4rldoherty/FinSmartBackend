namespace FinSmartBackend.Models
{
    public class Expenditure
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // Navigation Properties 
        public Category Category { get; set; }
    }
}
