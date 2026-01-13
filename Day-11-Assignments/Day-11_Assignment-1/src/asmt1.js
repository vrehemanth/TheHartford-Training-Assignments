// Task 1 – Select by ID
// Change the dashboard title text to “Customer Insurance Overview”

const title = document.getElementById("pageTitle");
title.innerHTML = "Customer Insurance Overview";


// Task 2 – Select by Tag Name
/* 
• Select all <li> elements and:
• Add a border
• Log the total number of customers 
*/
const listItems = document.getElementsByTagName("li");

for (let i = 0; i < listItems.length; i++) {
    listItems[i].style.border = "1px solid black";
}
console.log("Total number of customers: " + listItems.length);


// Task 3 – Select by Class Name
/* 
• Select all .policy elements and:
• Add highlight class
• Change text color to blue 
*/
const policies = document.getElementsByClassName("policy");

for (let i = 0; i < policies.length; i++) {
    policies[i].classList.add("highlight");
    policies[i].style.color = "blue";
}


// Task 4 – Select using CSS Selectors
/* 
• Select the first customer only
• Select all customers
• Mark the last customer as active 
*/
const firstCustomer = document.querySelector(".customer");
const allCustomers = document.querySelectorAll(".customer");
const lastCustomer = allCustomers[allCustomers.length - 1];
lastCustomer.classList.add("active");


// Task 5 – HTML Object Collections
/* 
• Using document collections:
• Count number of forms
• Get number of images
• Change text of all links to “More Info” 
*/
console.log("Number of forms: " + document.forms.length);
console.log("Number of images: " + document.images.length);

const links = document.links;
for (let i = 0; i < links.length; i++) {
    links[i].innerHTML = "More Info";
}


// Task 6 – Add a new customer dynamically and observe
/*
• Which selecƟons update automaƟcally?
• Which don’t?
*/
const customerList = document.getElementById("customerList");

const newCustomer = document.createElement("li");
newCustomer.className = "customer";
newCustomer.innerHTML = "Sita – Health";

customerList.appendChild(newCustomer);


// Task 7 – Attribute-Based Selection
/* 
• Select only input fields whose type is "text"
• Add yellow background
• Add placeholder text: "Enter Full Name" 
*/
const textInputs = document.querySelectorAll('input[type="text"]');

for (let i = 0; i < textInputs.length; i++) {
    textInputs[i].style.backgroundColor = "yellow";
    textInputs[i].setAttribute("placeholder", "Enter Full Name");
}


// Task 8 – Multiple Class Selection
/* 
• Select all elements that have both customer and active classes
• Change text color to dark green
• Add "(Priority Customer)" 
*/
const priorityCustomers = document.querySelectorAll(".customer.active");

for (let i = 0; i < priorityCustomers.length; i++) {
    priorityCustomers[i].style.color = "darkgreen";
    priorityCustomers[i].innerHTML += " (Priority Customer)";
}


// Task 9 – Descendant vs Child Selector
/* 
• Select all <li> elements inside #customerList using a descendant selector
• Select only direct child <li> using a child selector
• Log the difference in console. 
*/

let descendantItems = document.querySelectorAll("#customerList li");
let childItems = document.querySelectorAll("#customerList > li");

console.log("Descendant Selector Items: ", descendantItems);
console.log("Child Selector Items: ", childItems);


// Task 10 – Even / Odd Selection
/* 
• Using querySelectorAll():
    • Highlight even customers in light gray
    • Highlight odd customers in light blue
*/

const evenCustomers = document.querySelectorAll("#customerList li:nth-child(even)");
const oddCustomers = document.querySelectorAll("#customerList li:nth-child(odd)");

for (let i = 0; i < evenCustomers.length; i++) {
    evenCustomers[i].style.backgroundColor = "lightgray";
}
for (let i = 0; i < oddCustomers.length; i++) {
    oddCustomers[i].style.backgroundColor = "lightblue";
}


// Task 11 – Form Elements Collection
/* 
• Using HTML form object model:
    • Access the enquiry form
    • Log all input field names
    • Disable the submit button 
*/
const enquiryForm = document.forms["enquiryForm"];
const formElements = enquiryForm.elements;

for (let i = 0; i < formElements.length; i++) {
    console.log("Input field name: " + formElements[i].name);
}
enquiryForm.elements["submit"].disabled = true;


// Task 12 – NodeList vs HTMLCollection
/* 
• Select policies using:
    • getElementsByClassName
    • querySelectorAll
• Dynamically add a new policy
• Observe which collecƟon updates automatically
*/
const policyByClass = document.getElementsByClassName("policy");
const policyByQuery = document.querySelectorAll(".policy");

const newPolicy = document.createElement("p");
newPolicy.className = "policy";
newPolicy.innerHTML = "Travel Insurance";

const lastPolicy = policyByClass[policyByClass.length - 1];
lastPolicy.after(newPolicy);

//Observation: getElementsByClassName updates automatically, querySelectorAll does not.

// Task 13 – Text Content Filtering
/* 
• Select all customers and:
    • Highlight customers whose policy includes "Life"
    • Hide customers whose policy includes "Vehicle"
*/
const allCustomerItems = document.querySelectorAll(".customer");

for (let i = 0; i < allCustomerItems.length; i++) {
    const customerText = allCustomerItems[i].textContent;

    if (customerText.includes("Life")) {
        allCustomerItems[i].classList.add("highlight");
    }

    if (customerText.includes("Vehicle")) {
        allCustomerItems[i].style.display = "none";
    }
}


// Task 14 – Closest & Parent Traversal
/* 
• When clicking any customer <li>:
    • Find the nearest <ul>
    • Add a border to it
*/
const customerItems = document.querySelectorAll(".customer");

customerItems.forEach(item => {
    item.addEventListener("click", function () {
        const nearestUl = item.closest("ul");
        nearestUl.style.border = "2px solid red";
    });
});


// Task 15 – Complex Selector Challenge
/* 
• All policy <p> elements except the first one and:
    • Change font style to italic
    • Prefix text with "✔ " 
*/
const policyParagraphs = document.querySelectorAll(".policy:not(:first-child)");

for (let i = 0; i < policyParagraphs.length; i++) {
    policyParagraphs[i].style.fontStyle = "italic";
    policyParagraphs[i].innerHTML = "✔ " + policyParagraphs[i].innerHTML;
}
