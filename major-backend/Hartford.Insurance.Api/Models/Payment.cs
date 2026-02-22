namespace Hartford.Insurance.Api.Models
{
    public class Payment : BaseEntity
    {
        public int PolicyId { get; set; }
        public Policy? Policy { get; set; }

        public decimal Amount { get; set; }
        public string Method { get; set; } = "Card";
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
