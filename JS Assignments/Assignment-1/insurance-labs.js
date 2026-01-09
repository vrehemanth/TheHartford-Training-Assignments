// Insurance Labs JS Assignment

//Lab 1: Insurance Company Information
console.log("Lab 1: Insurance Company Information");

//Company name (String)
let companyName="The Harford India Insurance";
//Number of active policies (Number)
let activePolicies=125000;
//Whether health insurance is offered (Boolean)
let healthInsurance=true;

//Print values to console
console.log("Company Name:",companyName);
console.log("Active Policies:",activePolicies);
console.log("Health Insurance Offered:",healthInsurance);


//Lab 2: Monthly Premium Calculation
console.log("Lab 2: Monthly Premium Calculation");  

//Base premium amount (Number)
let basePremium=6000;
//Including 18% tax
let gst=0.18*6000;
//Total premium including tax
let totalPremium=basePremium+gst; 

//Print total premium to console
console.log("Total Monthly Premium (including tax):",totalPremium);


//Lab 3: Policy Eligibility Check
console.log("Lab 3: Policy Eligibility Check");

//Customer age (Number)
let customerAge=22;
console.log("Customer Age:",customerAge);
//Check if customer is eligible for a policy (age >= 18)
if(customerAge>=18){
    console.log(true);
}else{
    console.log(false);
}


//Lab 4: Policy Status Message
console.log("Lab 4: Policy Status Message");

//Policy ID (String)
let policyId = "POL12345";
//Customer name (String)
let customerName = "Rahul Sharma";
//Policy status (String)
let status = "active";

//Construct message using template literals
let message=`Policy ${policyId} for customer ${customerName} is currently ${status}`;
//Print message to console
console.log(message);


//Lab 5: Discount on Premium
console.log("Lab 5: Discount on Premium");

//Premium amount (Number)
let premiumAmount=12000;
//Discount percentage (Number)
let discountPercentage=15;
//Calculate discount amount
let discountAmount=(discountPercentage/100)*premiumAmount;
//Calculate final premium after discount
let finalPremium=premiumAmount-discountAmount;

//Print final premium to console
console.log("Final Premium after discount:",finalPremium);


//Lab 6: Fixed Coverage Value
console.log("Lab 6: Fixed Coverage Value");

//Coverage amount (Number) - fixed value
const coverageAmount=500000;

//Print coverage amount to console
console.log("Coverage Amount:",coverageAmount);


//Lab 7: Yearly Premium Calculator
console.log("Lab 7: Yearly Premium Calculator");

//Arrow Function to calculate yearly premium
const calculateYearlyPremium=(monthlyPremium)=>monthlyPremium*12;
//Usage
let monthlyPremium=4000;
let yearlyPremium=calculateYearlyPremium(monthlyPremium);

//Print yearly premium to console
console.log("Yearly Premium for monthly premium of",monthlyPremium,":",yearlyPremium);


//Lab 8: Policy Validation
console.log("Lab 8: Policy Validation");

//Policy active status (Boolean)
let isActivePolicy=true;
//Premium payment status (Boolean)
let isPremiumPaid=true;

//Check if policy is valid
if(isActivePolicy && isPremiumPaid){
    console.log("Policy is valid");
}else{
    console.log("Policy is not valid");
}


//Lab 9:Claim Approval Check
console.log("Lab 9: Claim Approval Check");

//Claim amount (Number)
let claimAmount=450000; 
//Maximum coverage amount (Number)
let maxCoverageAmount=500000;   
//Check if claim can be approved
let messageClaim=claimAmount<=maxCoverageAmount?`${claimAmount} is within ${maxCoverageAmount}`:
`${claimAmount} exceeds ${maxCoverageAmount}`;

//Print message to console
console.log(messageClaim);


//Lab 10: Claim Bonus Calculator
console.log("Lab 10: Claim Bonus Calculator");

//Arrow Function to calculate claim bonus percentage
const calculateClaimBonus=(hasPreviousClaim)=>hasPreviousClaim ? 0:5;

//Usage
//Previous claims (Boolean)
let hasPreviousClaim=false;
//Calculate claim bonus percentage
let bonus=calculateClaimBonus(hasPreviousClaim);
console.log("Claim Bonus Percentage:",bonus);             