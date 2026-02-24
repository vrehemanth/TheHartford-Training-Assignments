const API_URL = "https://jsonplaceholder.typicode.com/users";
let accounts = [];

// Task 9: Persist Data using localStorage
async function init() {
  if (localStorage.getItem("accounts")) {
    accounts = JSON.parse(localStorage.getItem("accounts"));
    render();
    populateBranches();
  } else {
    await fetchAccounts();
  }
}

// Task-1: Fetch Accounts
async function fetchAccounts() {
  const container = document.getElementById("accounts");

  // Task 6: Error Handling & Loading Indicator
  try {
    container.innerHTML = `<div class="loader">Loading accounts...</div>`;
    const res = await fetch(API_URL);
    if (!res.ok) throw new Error("API Error");
    const data = await res.json();

    accounts = data.map(u => ({
      id: u.id,
      name: u.name,
      email: u.email,
      branch: u.address.city,
      balance: randomBalance(),
      transactions: []
    }));

    save();
    render();
    populateBranches();

  } catch (err) {
    container.innerHTML = `<div class="loader">Failed to load data</div>`;
  }
}

const randomBalance = () => Math.floor(Math.random() * 40000) + 10000;
const save = () => localStorage.setItem("accounts", JSON.stringify(accounts));

function render() {
  const container = document.getElementById("accounts");
  container.innerHTML = "";

  accounts.forEach(acc => {
    container.innerHTML += `
      <div class="account ${acc.balance < 5000 ? 'low-balance' : ''}">
        <h3>${acc.name}</h3>
        <small>${acc.email}</small><br>
        <small>Branch: ${acc.branch}</small>
        <div class="balance">₹${acc.balance}</div>
        <div class="actions">
          <button onclick="deposit(${acc.id})">Deposit</button>
          <button onclick="withdraw(${acc.id})">Withdraw</button>
          <button onclick="showHistory(${acc.id})">History</button>
          <button onclick="deleteAccount(${acc.id})">Delete</button>
        </div>
      </div>
    `;
  });

  calculateTotal();
}


//Task-2: Search and Filter
/* SEARCH */
document.getElementById("search").addEventListener("input", e => {
  const q = e.target.value.toLowerCase();
  document.querySelectorAll(".account").forEach(card => {
    card.style.display = card.innerText.toLowerCase().includes(q) ? "" : "none";
  });
});

/* FILTER */
function populateBranches() {
  const select = document.getElementById("branchFilter");
  select.innerHTML = `<option value="">All Branches</option>`;
  [...new Set(accounts.map(a => a.branch))]
    .forEach(b => select.innerHTML += `<option>${b}</option>`);
}

document.getElementById("branchFilter").addEventListener("change", e => {
  const val = e.target.value;
  document.querySelectorAll(".account").forEach(card => {
    card.style.display = card.innerHTML.includes(val) || val === "" ? "" : "none";
  });
});


// Task 3: Deposit & Withdrawal OperaƟons
function deposit(id) {
  const amt = +prompt("Deposit amount");
  if (amt > 0) updateBalance(id, amt, "Deposit");
}

function withdraw(id) {
  const amt = +prompt("Withdrawal amount");
  const acc = accounts.find(a => a.id === id);
  if (amt > acc.balance) return alert("Insufficient balance");

  updateBalance(id, -amt, "Withdraw");

  // Task 8: Minimum Balance Rule + Penalty
  if (acc.balance < 5000) {
    acc.balance -= 200;
    acc.transactions.push({ type: "Penalty", amount: 200, time: new Date() });
    alert("Minimum balance violated. ₹200 penalty applied.");
  }
}

function updateBalance(id, amt, type) {
  const acc = accounts.find(a => a.id === id);
  acc.balance += amt;
  acc.transactions.push({ type, amount: Math.abs(amt), time: new Date() });
  save();
  render();
}

// Task 4: Create New Bank Account (POST)
function createAccount() {
  const name = document.getElementById("name").value;
  const email = document.getElementById("email").value;
  const branch = document.getElementById("branch").value;
  if (!name || !email || !branch) return alert("Fill all fields");

  accounts.push({
    id: Date.now(),
    name,
    email,
    branch,
    balance: 10000,
    transactions: []
  });

  save();
  render();
  populateBranches();
}

// Task 5: Delete Bank Account (DELETE)
function deleteAccount(id) {
  if (!confirm("Delete account?")) return;
  accounts = accounts.filter(a => a.id !== id);
  save();
  render();
}

// Task 7: TransacƟon History per Account
function showHistory(id) {
  const acc = accounts.find(a => a.id === id);
  const modal = document.getElementById("historyModal");
  const box = document.getElementById("modalHistory");

  box.innerHTML = acc.transactions.length === 0
    ? "<p>No transactions found.</p>"
    : acc.transactions.map(t =>
        `<div class="transaction">
          <strong>${t.type}</strong> ₹${t.amount}<br>
          <small>${new Date(t.time).toLocaleString()}</small>
        </div>`
      ).join("");

  modal.classList.remove("hidden");
}

function closeHistory() {
  document.getElementById("historyModal").classList.add("hidden");
}

window.onclick = e => {
  const modal = document.getElementById("historyModal");
  if (e.target === modal) closeHistory();
};


// Task 10: Sort and Total 
function sortByBalance() {
  accounts.sort((a,b) => b.balance - a.balance);
  render();
}

function calculateTotal() {
  const total = accounts.reduce((sum,a) => sum + a.balance, 0);
  document.getElementById("totalBalance").innerText =
    `Total Bank Balance: ₹${total}`;
}

init();
