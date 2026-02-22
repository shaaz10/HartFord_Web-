namespace Hartford.Insurance.Api.Models
{
    public class Policy : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? AgentId { get; set; }
        public Agent? Agent { get; set; }

        public string PolicyName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Premium { get; set; }
        public string Status { get; set; } = "Active";
    }
}
