using System.Collections.Generic;
using InsuranceLibrary.Models;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private List<InsurancePolicy> policies = new List<InsurancePolicy>();

        public void AddPolicy(InsurancePolicy policy)
        {
            policies.Add(policy);
        }

        public List<InsurancePolicy> GetAllPolicies()
        {
            return policies;
        }

        public InsurancePolicy GetPolicyById(int id)
        {
            foreach (var policy in policies)
            {
                if (policy.PolicyId == id)
                    return policy;
            }
            return null;
        }

        public bool UpdatePolicy(int id, decimal newPremium, int newTerm)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy == null) return false;

            policy.PremiumAmount = newPremium;
            policy.PolicyTerm = newTerm;
            return true;
        }

        public bool DeletePolicy(int id)
        {
            InsurancePolicy policy = GetPolicyById(id);
            if (policy == null) return false;

            policies.Remove(policy);
            return true;
        }
    }
}
