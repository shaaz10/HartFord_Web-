namespace Hartford.Insurance.Api.Models
{
    public class PolicyRecommendation : BaseEntity
    {
        public int RequestId { get; set; }
        public InsuranceRequest? Request { get; set; }

        public string PolicyName { get; set; } = string.Empty;
        public decimal Premium { get; set; }
        public string Coverage { get; set; } = string.Empty;
    }
}
