namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public int PolicyTerm { get; set; }
        public bool IsActive { get; set; }

        public InsurancePolicy(int policyId, string holderName, string policyType,
                               decimal premiumAmount, int policyTerm)
        {
            PolicyId = policyId;
            PolicyHolderName = holderName;
            PolicyType = policyType;
            PremiumAmount = premiumAmount;
            PolicyTerm = policyTerm;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"{PolicyId}\t{PolicyHolderName}\t{PolicyType}\t{PremiumAmount}\t{PolicyTerm}\t{IsActive}";
        }
    }
}
