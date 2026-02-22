namespace Hartford.Insurance.Api.Models
{
    public class PolicyApplication : BaseEntity
    {
        public int AgentId { get; set; }
        public Agent? Agent { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public string PolicyName { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
    }
}
