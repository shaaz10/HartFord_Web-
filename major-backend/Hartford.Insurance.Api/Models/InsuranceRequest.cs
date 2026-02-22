namespace Hartford.Insurance.Api.Models
{
    public class InsuranceRequest : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? AgentId { get; set; }
        public Agent? Agent { get; set; }

        public string Type { get; set; } = string.Empty; // Life, Health, Auto
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
