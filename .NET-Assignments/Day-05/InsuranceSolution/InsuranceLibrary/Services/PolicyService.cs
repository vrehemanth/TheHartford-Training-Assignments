using InsuranceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private const int MAX_POLICIES = 10;
        private List<InsurancePolicy> policies = new List<InsurancePolicy>(MAX_POLICIES);
        private int count = 0;

        public PolicyService()
        {
            SeedData();
        }

        private void SeedData()
        {
            AddPolicy(new InsurancePolicy
            {
                PolicyId = 101,
                PolicyHolderName = "Ravi",
                PolicyType = PolicyTypes.Health,
                PremiumAmount = 12000,
                PolicyTerm = 5,
                IsActive = true 
            });

            AddPolicy(new InsurancePolicy
            {
                PolicyId = 102,
                PolicyHolderName = "Anita",
                PolicyType = PolicyTypes.Life,
                PremiumAmount = 25000,
                PolicyTerm = 10,
                IsActive = true
            });
        }
        // create a collecton for in Memory Data
        public void AddPolicy(InsurancePolicy policy)
        {
            //Add
            policies.Add(policy);
        }
        public List<InsurancePolicy> GetAllPolicies()
        {
            //View All
            return policies;
        }
        public InsurancePolicy GetPolicyById(int id)
        {
            //Search by ID
            for (int i = 0; i < policies.Count; i++)
            {
                if (policies[i].PolicyId == id)
                {
                    return policies[i];
                }
            }
            return null;
        }
        public bool UpdatePolicy(int id, decimal newPremium, int newTerm)
        {
            //Edit
            for (int i = 0; i < policies.Count; i++)
            {
                if (policies[i].PolicyId == id)
                {
                    policies[i].PremiumAmount = newPremium;
                    policies[i].PolicyTerm = newTerm;
                    return true; 
                }
            }
            return false;
        }
        public bool DeletePolicy(int id)
        {
            //Delete
            for (int i = 0; i < policies.Count; i++)
            {
                if (policies[i].PolicyId == id)
                {
                    policies.RemoveAt(i);
                    return true;  
                }
            }
            return false;
        }
        public bool DeactivatePolicies(int id)
        {
            //Deactivate Policy
            InsurancePolicy policy = GetPolicyById(id);
            if (policy == null || !policy.IsActive)
                return false;
            policy.IsActive = false;
            return true;
        }
        public bool PolicyExists(int id)
        {
            //Unique IDs
            for (int i = 0; i < count; i++)
            {
                if (policies[i].PolicyId == id)
                    return true;
            }
            return false;
        }

    }
}
