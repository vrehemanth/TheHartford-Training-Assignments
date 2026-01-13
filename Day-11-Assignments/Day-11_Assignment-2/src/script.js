//1) Event Bubbling
//BUBBLING (event goes from child → parent)
document.getElementById("paymentSection1").addEventListener("click", () => {
    console.log("Payment Section clicked (Parent)");
});

document.getElementById("payBtn1").addEventListener("click", () => {
    console.log("Pay Premium button clicked (Child)");
});

//2) Event Capturing
//Capturing runs from Parent → Child
document.getElementById("paymentSection2").addEventListener("click",() => 
    console.log("Validating user (Parent)"),true
);

document.getElementById("payBtn2").addEventListener("click",() => 
    console.log("Showing policy details (Child)"),true
);

//3) stopPropagation
document.getElementById("policyCard").addEventListener("click", () => {
    console.log("Navigating to policy details");
});

document.getElementById("deleteBtn").addEventListener("click", (event) => {
    event.stopPropagation();
    console.log("Policy deleted");
});
//stopPropagation stops event flow

//4) Intermediate (Reinforce bubbling, capturing, and stopPropagaƟon together)
const claimRow = document.querySelector(".claimRow");
const approveBtn = document.querySelector(".approveBtn");

claimRow.addEventListener("click", () => {
    console.log("Opening Claim Details");
});

approveBtn.addEventListener("click", (event) => {
    event.stopPropagation();
    console.log("Claim Approved");
});

//Without stopPropagation()
/*
• When you click Approve Claim:
• The click happens on the button
• The event bubbles up to the parent .claimRow
• So both events run
*/


// With stopPropagation()
/*
• When you click Approve Claim:
• Button event runs
• event.stopPropagation() blocks the event
• Parent .claimRow never receives the click
*/