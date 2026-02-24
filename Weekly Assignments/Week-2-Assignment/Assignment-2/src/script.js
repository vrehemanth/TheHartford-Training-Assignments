const plans=[
  { type: "Health", base: 3000, cover: "₹5L - ₹50L" },
  { type: "Life", base: 5000, cover: "₹10L - ₹1Cr" },
  { type: "Vehicle", base: 2000, cover: "₹1L - ₹20L" }
];

let customers=[];

const planDiv=document.getElementById("plans");
const nameInput=document.getElementById("nameInput");
const ageInput=document.getElementById("ageInput");
const policyType=document.getElementById("policyType");
const coverage=document.getElementById("coverage");
const coverageValue=document.getElementById("coverageValue");
const premiumPreview=document.getElementById("premiumPreview");
const error=document.getElementById("error");
const tableBody=document.getElementById("tableBody");
const filter=document.getElementById("filter");
const search=document.getElementById("search");
const totalCustomers=document.getElementById("totalCustomers");
const totalPolicies=document.getElementById("totalPolicies");

// Render Plans
plans.forEach(p=>{
  planDiv.innerHTML+=`
    <div class="bg-white p-6 rounded-xl shadow">
      <h4 class="text-xl font-bold">${p.type}</h4>
      <p>Base Premium: ₹${p.base}</p>
      <p>Coverage: ${p.cover}</p>
      <a href="#formSection"
        class="inline-block mt-4 bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
        onclick="selectPlan('${p.type}')">
        Enroll Now
       </a>
    </div>
  `;
});

// Coverage Slider
coverage.oninput = () => {
  coverageValue.innerText = coverage.value;
  updatePremiumPreview();
};

// Premium Logic
function calculatePremium(age, type, coverage) {
  let base=type==="Health" ? 3000 : type === "Life" ? 5000 : 2000;
  let premium = base + coverage * 500;
  if (age > 45) premium *= 1.2;
  return Math.round(premium);
}

function updatePremiumPreview() {
  if(!ageInput.value || !policyType.value) return;
  premiumPreview.innerText="Estimated Premium: ₹" +
    calculatePremium(ageInput.value, policyType.value, coverage.value);
}

// Form Submit
document.getElementById("customerForm").addEventListener("submit", e => {
  e.preventDefault();
  if (!nameInput.value || !ageInput.value || !policyType.value) {
    error.innerText = "Please fill all fields";
    return;
  }
  error.innerText = "";

  const premium = calculatePremium(ageInput.value, policyType.value, coverage.value);

  customers.push({
    name: nameInput.value,
    age: ageInput.value,
    type: policyType.value,
    cover: coverage.value,
    premium
  });

  renderTable();
  e.target.reset();
});

function selectPlan(type){
  document.getElementById("policyType").value = type;
  updatePremiumPreview();
}


// Render Table
function renderTable() {
  let data = customers;

  if (filter.value !== "All") {
    data = data.filter(c => c.type === filter.value);
  }

  if (search.value) {
    data = data.filter(c =>
      c.name.toLowerCase().includes(search.value.toLowerCase())
    );
  }

  tableBody.innerHTML = data.map(c => `
    <tr>
      <td>${c.name}</td>
      <td>${c.age}</td>
      <td>${c.type}</td>
      <td>${c.cover} L</td>
      <td>₹${c.premium}</td>
    </tr>
  `).join("");

  totalCustomers.innerText = customers.length;
  totalPolicies.innerText = customers.length;
}

filter.onchange = renderTable;
search.oninput = renderTable;
