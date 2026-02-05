using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceLibrary.Models
{
    //PolicyType
    public enum PolicyTypes
    {
        Health,Life,Vehicle
    }
    public class InsurancePolicy
    {
        //Define Properties
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyTypes PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public int PolicyTerm {  get; set; }
        public bool IsActive { get; set; }
        //override toString()
        public override string ToString()
        {
            return $"Id: {PolicyId}, Name: {PolicyHolderName}, " +
                   $"Type: {PolicyType}, Premium: {PremiumAmount}, " +
                   $"Term: {PolicyTerm} years, Active: {IsActive}";
        }
    }
}
