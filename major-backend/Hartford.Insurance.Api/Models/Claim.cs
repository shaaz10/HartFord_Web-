namespace Hartford.Insurance.Api.Models
{
    public class Claim : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int PolicyId { get; set; }
        public Policy? Policy { get; set; }

        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime DateFiled { get; set; } = DateTime.UtcNow;
    }
}
