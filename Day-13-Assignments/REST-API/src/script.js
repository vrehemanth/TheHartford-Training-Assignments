const API_URL = "https://696721febbe157c088b0f5d1.mockapi.io/policies";

// Get Next ID
async function getNextId(){
    const res = await fetch(API_URL);
    const data = await res.json();
    const next = data.length ? Math.max(...data.map(p => Number(p.id))) + 1 : 1;
    document.getElementById("displayId").innerText = next;
    return next;
}

// Load Policies
async function getPolicies(){
    const res = await fetch(API_URL);
    const data = await res.json();

    let html = "";
    data.forEach(p=>{
        html += `
        <div class="card">
            <div class="status ${p.active?"active":"inactive"}">${p.active?"Active":"Inactive"}</div>
            <span><b>ID:</b> ${p.id}</span>
            <span><b>Name:</b> ${p.customerName}</span>
            <span><b>Policy:</b> ${p.policyType}</span>
            <span><b>Premium:</b> ₹${p.premiumAmount}</span>
            <span><b>Coverage:</b> ₹${p.coverageAmount}</span>
            <span><b>Duration:</b> ${p.Duration} Years</span>

            <div class="card-actions">
                <button class="card-update" onclick="openModal('${p.id}')">Update</button>
                <button class="card-delete" onclick="deletePolicy('${p.id}')">Delete</button>
            </div>
        </div>
        `;
    });

    document.getElementById("policies").innerHTML = html;
    getNextId();
}

// POST
async function addPolicy(){
    if(!customerName.value || !premiumAmount.value || !Duration.value || !startDate.value){
        alert("Fill all fields");
        return;
    }

    const id = await getNextId();
    const premium = Number(premiumAmount.value);
    const duration = Number(Duration.value);

    await fetch(API_URL,{
        method:"POST",
        headers:{ "Content-Type":"application/json" },
        body:JSON.stringify({
            id:String(id),
            customerName: customerName.value,
            policyNumber:"HLTH-IND-"+id,
            policyType:policyType.value,
            premiumAmount:premium,
            coverageAmount: premium * duration * 5,
            Duration: duration,
            startDate: startDate.value,
            active: active.value === "true"
        })
    });

    customerName.value="";
    premiumAmount.value="";
    Duration.value="";
    startDate.value="";
    active.value="true";

    getPolicies();
}

// DELETE
async function deletePolicy(id){
    if(confirm("Delete this policy?")){
        await fetch(`${API_URL}/${id}`,{method:"DELETE"});
        getPolicies();
    }
}

// OPEN MODAL
async function openModal(id){
    const res = await fetch(`${API_URL}/${id}`);
    const p = await res.json();

    document.getElementById("editId").value = p.id;
    document.getElementById("editCustomer").value = p.customerName;
    document.getElementById("editPolicyType").value = p.policyType;
    document.getElementById("editPremium").value = p.premiumAmount;
    document.getElementById("editDuration").value = p.Duration;
    document.getElementById("editDate").value = p.startDate;
    document.getElementById("editActive").value = p.active ? "true":"false";

    document.getElementById("editModal").style.display="flex";
}

// CLOSE
function closeModal(){
    document.getElementById("editModal").style.display="none";
}

// SAVE UPDATE
async function saveUpdate(){
    const id = document.getElementById("editId").value;
    const premium = Number(document.getElementById("editPremium").value);
    const duration = Number(document.getElementById("editDuration").value);

    await fetch(`${API_URL}/${id}`,{
        method:"PUT",
        headers:{ "Content-Type":"application/json" },
        body:JSON.stringify({
            customerName: document.getElementById("editCustomer").value,
            policyNumber:"HLTH-IND-"+id,
            policyType: document.getElementById("editPolicyType").value,
            premiumAmount: premium,
            coverageAmount: premium * duration * 50,
            Duration: duration,
            startDate: document.getElementById("editDate").value,
            active: document.getElementById("editActive").value==="true"
        })
    });

    closeModal();
    getPolicies();
}

// Load on start
getPolicies();
