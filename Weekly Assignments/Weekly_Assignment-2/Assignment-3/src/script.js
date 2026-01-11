const customers = [
 { id: 1, name: "Ravi", age: 32, policy: "Health", premium: 4800, active: true },
 { id: 2, name: "Anita", age: 51, policy: "Life", premium: 12000, active: true },
 { id: 3, name: "Kiran", age: 28, policy: "Vehicle", premium: 3500, active: false },
 { id: 4, name: "Meena", age: 45, policy: "Health", premium: 6000, active: true },
 { id: 5, name: "Suresh", age: 60, policy: "Life", premium: 18000, active: false }
]; 

// Bug 1: Loop Output Issue
/* for (let i = 0; i <= customers.length; i++) {
  console.log(customers[i].name);
}*/

// Fixed Code
console.log("Bug 1: Loop Output Issue");

for (let i = 0; i < customers.length; i++) {
 console.log(customers[i].name);
}


// Bug 2: filter() Not Working 
/* const activeCustomers = customers.filter((c) => {
        c.active === true;
}); */

// Fixed Code
console.log("Bug 2: filter() Not Working");

const activeCustomers = customers.filter((c) =>{
    return c.active === true});
console.log(activeCustomers);


// Bug 3: Premium Increase Logic Broken 
/* const updatedPremiums = customers.map((c) => {
 if (c.age >= 50) {
 c.premium = c.premium * 1.1;
 }
} */

// Fixed Code
console.log("Bug 3: Premium Increase Logic Broken");

const updatedPremiums = customers.map((c) => {
  if (c.age >= 50) {
    return { ...c, premium: c.premium * 1.1 }; 
  }
  return c;
});

console.log("Updated Premiums:", updatedPremiums);



// Bug 4: Wrong Total Premium Calculation
/* const totalPremium = customers.reduce((total, c) => {
 total + c.premium;
}, 0); */

// Fixed Code
console.log("Bug 4: Wrong Total Premium Calculation");

const totalPremium = customers.reduce((total, c) => {
    return total + c.premium;
}, 0);
console.log("Total Premium: " + totalPremium);


// Bug 5: Template Literal Not Printing
/*console.log("Customer ${customers[0].name} has policy
${customers[0].policy}"); */

// Fixed Code
console.log("Bug 5: Template Literal Not Printing");

console.log(`Customer ${customers[0].name} has policy${customers[0].policy}`); 


// Bug 6: Policy Count Incorrect
/*const policyCount = customers.reduce((count, c) => {
    count.policy = (count.policy || 0) + 1;
    return count;
}, {});*/

// Fixed Code
console.log("Bug 6: Policy Count Incorrect");

const policyCount = customers.reduce((count, c) => {
    count[c.policy] = (count[c.policy] || 0) + 1;
    return count;
}, {});
console.log("Policy Count: " + JSON.stringify(policyCount));


// /Bug 7: Risk Level Always Undefined
/*const customersWithRisk = customers.map((c) => {
 let riskLevel;
 if (c.age < 35) riskLevel = "Low";
 if (c.age <= 50) riskLevel = "Medium";
 else riskLevel = "High";
 return { ...c, riskLevel };
}); */ 


// Fixed Code
console.log("Bug 7: Risk Level Always Undefined");

const customersWithRisk = customers.map((c) => {
    let riskLevel;
    if (c.age < 35) riskLevel = "Low";
    else if (c.age <= 50) riskLevel = "Medium";
    else riskLevel = "High";
    return { ...c, riskLevel };
}); 
console.log("Customers with Risk Level: " + JSON.stringify(customersWithRisk));


//Bug 8: Active vs Inactive Count Wrong
/*let active = 0,
 inactive = 0;
for (const c in customers) {
 if (c.active) active++;
 else inactive++;
} */

// Fixed Code
console.log("Bug 8: Active vs Inactive Count Wrong");

let active = 0,inactive = 0;
for (const c of customers) {
    if (c.active) active++;
    else inactive++;
} 
console.log("Active Customers: " + active + ", Inactive Customers: " + inactive);


// Bug 9: Arrow Function Syntax Error
/* const getLifeCustomers = () =>
 customers.filter((c) => c.policy === "Life").map((c) =>
c.name); */

// Fixed Code
console.log("Bug 9: Arrow Function Syntax Error");

const getLifeCustomers = () => {
  return customers
    .filter(c => c.policy === "Life")
    .map(c => c.name);
};
console.log("Life Policy Customers: " + getLifeCustomers());

//Bug 10: Sorting Mutates Original Array
/* const sortedCustomers = customers.sort((a, b) => b.premium -
a.premium); */ 
console.log("Bug 10: Sorting Mutates Original Array");

const sortedCustomers = [...customers].sort((a, b) => b.premium - a.premium);
console.log("Sorted Customers by Premium: " + JSON.stringify(sortedCustomers));

