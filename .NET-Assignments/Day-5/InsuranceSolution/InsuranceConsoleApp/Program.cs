using System;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;
using InsuranceLibrary.Models;
using InsuranceLibrary.Services;
namespace InsuranceConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PolicyService policies = new PolicyService();
            int option;
            do
            {
                Console.WriteLine("\n--- Insurance Policy System ---");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Search Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. Deactivate Policy");
                Console.WriteLine("-1. Exit");
                Console.Write("Enter Choice: ");
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1: AddPolicy(policies); break;
                    case 2: GetAllPolicies(policies); break;
                    case 3: SearchByPolicyId(policies); break;
                    case 4: UpdatePolicy(policies); break;
                    case 5: DeletePolicy(policies); break;
                    case 6: DeactivatePolicy(policies); break;
                    case -1: Console.WriteLine("Exiting the Program..."); break;
                    default: Console.WriteLine("Enter a Valid option"); break;
                }
            } while (option != -1);
        }
        
        //Add Policy
        static void AddPolicy(PolicyService policies)
        {
            InsurancePolicy policy = new InsurancePolicy();

            Console.Write("Policy Id: ");
            int.TryParse(Console.ReadLine(),out int id);
            if (policies.PolicyExists(id))
            {
                Console.WriteLine("Policy ID already exists.");
                return;
            }
            policy.PolicyId = id;

            Console.Write("Policy Holder Name: ");
            policy.PolicyHolderName = Console.ReadLine();

            Console.WriteLine("Policy Type:");
            Console.WriteLine("1. Health");
            Console.WriteLine("2. Life");
            Console.WriteLine("3. Vehicle");
            int typeChoice;
            do
            {
                Console.Write("Enter choice: ");
            }while (!int.TryParse(Console.ReadLine(), out typeChoice));

            switch (typeChoice)
            {
                case 1: policy.PolicyType = PolicyTypes.Health; break;
                case 2: policy.PolicyType = PolicyTypes.Life; break;
                case 3: policy.PolicyType = PolicyTypes.Vehicle; break;
                default: Console.WriteLine("Invalid choice. Defaulting to Health."); policy.PolicyType = PolicyTypes.Health; break;
            }

            Console.Write("Premium Amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            policy.PremiumAmount = amount;

            Console.Write("Policy Term: ");
            int.TryParse(Console.ReadLine(),out int term);
            policy.PremiumAmount = term;

            Console.Write("IsActive: ");
            bool.TryParse(Console.ReadLine(),out bool isActive);
            policy.IsActive = isActive;

            policies.AddPolicy(policy);
            Console.WriteLine("Policy Added Successfully! ");
        }

        //View All Policies
        static void GetAllPolicies(PolicyService policies)
        {
            List<InsurancePolicy> policy = policies.GetAllPolicies();
            if (policy.Count == 0)
            {
                Console.WriteLine("No policies available.");
                return;
            }

            Console.WriteLine(new string('-', 76));
            Console.WriteLine(
                $"| {"ID",-3} | {"Holder Name",-18} | {"Type",-8} | {"Premium",-11} | {"Term (Years)",-12} | {"Active",-6} |");
            Console.WriteLine(new string('-', 76));

            foreach (var p in policy)
            {
                Console.WriteLine(
                    $"| {p.PolicyId,-3} | {p.PolicyHolderName,-18} | {p.PolicyType,-8} | {p.PremiumAmount,-11:F2} | {p.PolicyTerm,-12} | {(p.IsActive ? "Yes" : "No"),-6} |");
            }

            Console.WriteLine(new string('-', 76));
            return;
        }
        //Search Policy
        static void SearchByPolicyId(PolicyService policies)
        {
            Console.Write("Enter Policy ID to search: ");
            int.TryParse(Console.ReadLine(), out int id);

            InsurancePolicy policy = policies.GetPolicyById(id);

            if (policy == null)
            {
                Console.WriteLine("Policy not found.");
                return;
            }
            Console.WriteLine(new string('-', 76));
            Console.WriteLine($"| {"ID",-3} | {"Holder Name",-18} | {"Type",-8} | {"Premium",-11} | {"Term (Years)",-12} | {"Active",-6} |");
            Console.WriteLine(new string('-', 76));

            Console.WriteLine($"| {policy.PolicyId,-3} | {policy.PolicyHolderName,-18} | {policy.PolicyType,-8} | {policy.PremiumAmount,-11:F2} | {policy.PolicyTerm,-12} | {(policy.IsActive ? "Yes" : "No"),-6} |");

            Console.WriteLine(new string('-', 76));
        }
        static void UpdatePolicy(PolicyService policies)
        {
            Console.Write("Enter Policy ID to update: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.Write("Enter New Premium Amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal newPremium);

            Console.Write("Enter New Policy Term (years): ");
            int.TryParse(Console.ReadLine(), out int newTerm);

            bool updated = policies.UpdatePolicy(id, newPremium, newTerm);

            if (updated)
            {
                Console.WriteLine("Policy updated successfully!");
            }
            else
            {
                Console.WriteLine("Policy not found. Update failed.");
            }
        }
        static void DeletePolicy(PolicyService policies)
        {
            Console.Write("Enter Policy ID to delete: ");
            int.TryParse(Console.ReadLine(), out int id);

            bool deleted = policies.DeletePolicy(id);

            if (deleted)
            {
                Console.WriteLine("Policy deleted successfully!");
            }
            else
            {
                Console.WriteLine("Policy not found. Deletion failed.");
            }
        }
        static void DeactivatePolicy(PolicyService policies)
        {
            Console.Write("Enter Policy ID to deactivate: ");
            int.TryParse(Console.ReadLine(), out int id);

            if (policies.DeactivatePolicies(id))
                Console.WriteLine("Policy deactivated successfully");
            else
                Console.WriteLine("Policy not found or already inactive");
        }

    }
}
