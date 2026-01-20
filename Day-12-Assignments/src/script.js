let policies = [];

//Task 1: Fetch Insurance Policies (Fetch + Async/Await)
/* 
 Fetch policy data from a mock API (simulate API using local data)
 Handle API errors using try/catch 
*/
async function fetchPolicies(){
    try{
        const response = await fetch("policies.json");

        if(!response.ok){
            throw "Network Error";
        }

        policies = await response.json();
        displayPolicies(policies)
    }
    catch(err){
        console.error("API Error:", err);
    }
}

//Task 2: Display Policies (Objects & Arrays)
/* 
 Render policies dynamically on UI
 Show: Policy Name, Type, Premium, DuraƟon, Status
*/
function displayPolicies(data){
    const div = document.getElementById("policies");
    div.innerHTML = "";

    data.forEach(p => {
        div.innerHTML += policyCard(p);
    });
}

function displayFilteredPolicies(data){
    const div = document.getElementById("filteredPolicies");
    div.innerHTML = "";

    data.forEach(p => {
        div.innerHTML += policyCard(p);
    });
}

function displayDiscountedPolicies(data){
    const div = document.getElementById("discountedPolicies");
    div.innerHTML = "";

    data.forEach(p => {
        div.innerHTML += policyCard(p);
    });
}

function policyCard(p){
    return `
        <div class="card">
            <h3>${p.name}</h3>
            <p>Type: ${p.type}</p>
            <p>Premium: ₹${p.premium}</p>
            <p>Duration: ${p.duration} years</p>
            <p>Status: ${p.status}</p>
        </div>
    `;
}

//Task 3: Filter Policies (filter)
/*
 Filter policies:
    o Health
    o Life
    o Vehicle
*/
function filterPolicies(type){
    const result = policies.filter(p => p.type === type);
    displayFilteredPolicies(result);
}
//Task 4: Calculate Total Premium (reduce)
/*
 Calculate total premium of AcƟve policies
*/
function totalPremium(){
    try{
        const total=policies
                    .filter(p=>p.status==="Active")
                    .reduce((sum,p)=>sum+p.premium,0);
        
        document.getElementById("result").innerHTML="Total Active Premium: ₹"+total;
    }catch{
        document.getElementById("result").innerHTML="Error in calculating Premium";
    }
}

//Task 5: Premium Discount Logic (map)
/* 
 Apply 10% discount to policies above ₹10,000
*/
function applyDiscount(){
    try{
        const discount=policies.map(p=>{
            if(p.premium>10000){
                return {
                    ...p,
                    premium: 0.9*p.premium
                };
            }
            return p;
        }
    );
    displayDiscountedPolicies(discount)
    }catch{
        document.getElementById("result").innerHTML="Error in calculating Discount Premium";
    }
}

//Task 6: Policy Approval Simulation (Callback + setTimeout)
/* 
 Simulate policy approval after 2 seconds
 Use callback pattern 
*/
function requestApproval(){
    const id = parseInt(document.getElementById("policyId").value);

    if(!id){
        alert("Please enter a valid Policy ID");
        return;
    }

    approvePolicy(id, function(error, message){
        if (error) {
            alert(error);
        } else {
            alert(message);
        }
    });
}

function approvePolicy(policyId, callback) {
    setTimeout(() => {
        const policy = policies.find(p => p.id === policyId);

        if (!policy) {
            callback("Invalid Policy ID", null);
        } 
        else {
            callback(null, "Policy Approved Successfully!");
        }
    }, 2000);  
}

//Task 7: Promise-based Policy Purchase
/*
 Convert callback logic to Promise
 Handle success & failure 
*/
function approvePolicyPromise(policyId){
    return new Promise((resolve, reject) => {
        approvePolicy(policyId, (error, message) => {
            if (error) {
                reject(error);
            } else {
                resolve(message);
            }
        });
    });
}
async function buyPolicy(){
    const id = parseInt(document.getElementById("policyId1").value);
    if (!id) {
        alert("Please enter a valid Policy ID");
        return;
    }

    try {
        const message = await approvePolicyPromise(id);
        alert(message);
    }
    catch (error) {
        alert(error);
    }
}

//Task 8: Error Handling
/*
 Invalid policy ID 
 API failure
 Premium calculaƟon error
*/

//Invalid PolicyID
function requestApproval(){
    const id = parseInt(document.getElementById("policyId").value);

    if(!id){
        alert("Please enter a valid Policy ID");
        return;
    }

    approvePolicy(id, function(error, message){
        if (error) {
            alert(error);
        } else {
            alert(message);
        }
    });
}

function approvePolicy(policyId, callback) {
    setTimeout(() => {
        const policy = policies.find(p => p.id === policyId);

        if (!policy) {
            callback("Invalid Policy ID", null);
        } 
        else {
            callback(null, "Policy Approved Successfully!");
        }
    }, 2000);  
}

//API failure
async function fetchPolicies(){
    try{
        const response = await fetch("policies.json");

        if(!response.ok)
            throw "API Failure";

        policies = await response.json();
        displayPolicies(policies)
    }
    catch{
        document.getElementById("result-1").innerHTML =
        "<span style='color:red'>❌ Failed to load policy data</span>";
    }
}

// Premium calculation error
function totalPremium(){
    try{
        const total = policies
            .filter(p => p.status === "Active")
            .reduce((sum,p)=> sum + p.premium, 0);

        document.getElementById("result").innerHTML =
            "Total Active Premium: ₹" + total;
    }
    catch{
        document.getElementById("result-2").innerHTML =
            "<span style='color:red'>❌ Premium calculation failed</span>";
    }
}

