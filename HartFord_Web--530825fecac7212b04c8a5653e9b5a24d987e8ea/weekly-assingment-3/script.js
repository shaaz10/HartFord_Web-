let API="https://jsonplaceholder.typicode.com/users";
let accounts=[]


//load accounts
async function loadAccounts() {
  const loader = document.getElementById("loader");
  loader.style.display = "block";

  try {
    const localData = localStorage.getItem("bankAccounts");
    if(localData){
      accounts = JSON.parse(localData);
    } else {
      const res = await fetch(API);
      const data = await res.json();
      console.log(data);

      accounts = data.map(user => ({
        id: user.id,
        name: user.name,
        email: user.email,
        branch: user.address.city,
        balance: randomBalance(),
        history: []
      }));
      saveData();
    }
    populateBranchFilter();
    displayAccounts(accounts);
    updateTotalBalance();
  }
  catch(err){
    alert("Failed to load data");
  }
  finally{
    loader.style.display = "none";
  }
}



//function for random balance
function randomBalance(){
    return Math.floor(Math.random()*40000)+10000;
}

//save the data
function saveData(){
    localStorage.setItem("accounts",JSON.stringify(accounts));
}

//display accounts
function displayAccounts(data){
    let tbody=document.getElementById("accountsBody");
    tbody.innerHTML="";

    data.forEach(acc=>{
        let row=document.createElement("tr");

        if(acc.balance<5000) row.classList.add("low-balance");
        row.innerHTML=`
        <td>${acc.id}</td>
        <td>${acc.name}</td>
        <td>${acc.email}</td>
        <td>${acc.branch}</td>
        <td>₹${acc.balance}</td>
        <td>
        <button onclick="deposit(${acc.id})" class="actionBtn deposit">Deposit</button>
        <button onclick="withdraw(${acc.id})" class="actionBtn withdraw">Withdraw</button>
        <button onclick="viewHistory(${acc.id})" class="actionBtn history">View History</button>
        <button onclick="deleteAccount(${acc.id})" class="actionBtn delete">Delete</button>
        </td>
        `;
        tbody.appendChild(row);
    })
}


// Deposit
function deposit(id){
  const amount = +prompt("Enter deposit amount:");
  if(!amount) return;

  const acc = accounts.find(a => a.id === id);
  acc.balance += amount;
  acc.history.push({type:"Deposit", amount, time:new Date().toLocaleString()});
  saveData();
  refreshUI();
}

// Withdraw
function withdraw(id){
  const amount = +prompt("Enter withdrawal amount:");
  if(!amount) return;

  const acc = accounts.find(a => a.id === id);

  if(acc.balance - amount < 0){
    alert("Insufficient Balance!");
    return;
  }

  acc.balance -= amount;
  acc.history.push({type:"Withdraw", amount, time:new Date().toLocaleString()});

  // Minimum balance rule
  if(acc.balance < 5000){
    acc.balance -= 200;
    alert("Minimum balance violated! ₹200 penalty applied");
  }

  saveData();
  refreshUI();
}

// View History
function viewHistory(id){
  const acc = accounts.find(a => a.id === id);
  let msg = "Transaction History:\n";
  acc.history.forEach(h => {
    msg += `${h.type} ₹${h.amount} on ${h.time}\n`;
  });
  alert(msg || "No Transactions");
}

// Delete Account
async function deleteAccount(id){
  if(!confirm("Delete this account?")) return;

  await fetch(API+"/"+id,{method:"DELETE"});
  accounts = accounts.filter(a => a.id !== id);
  saveData();
  refreshUI();
}

// Create Account
document.getElementById("accountForm").addEventListener("submit", async function(e){
  e.preventDefault();

const newAcc = {
  name: document.getElementById("name").value,
  email: document.getElementById("email").value,
  branch: document.getElementById("branch").value,
  balance: 10000,
  history: []
};


  const res = await fetch(API,{
    method:"POST",
    body: JSON.stringify(newAcc),
    headers: {"Content-type":"application/json"}
  });

  const data = await res.json();
  let nextId = accounts.length + 1;

  newAcc.id = nextId++;

  accounts.push(newAcc);
  saveData();
  refreshUI();
  this.reset();
});

// Search
document.getElementById("search").addEventListener("input", function(){
  const val = this.value.toLowerCase();
  const filtered = accounts.filter(a => a.name.toLowerCase().includes(val));
  displayAccounts(filtered);
});

// Filter Branch
function populateBranchFilter(){
  const branches = [...new Set(accounts.map(a=>a.branch))];
  const select = document.getElementById("branchFilter");
  branches.forEach(b=>{
    const op = document.createElement("option");
    op.value=b; op.textContent=b;
    select.appendChild(op);
  });
}

document.getElementById("branchFilter").addEventListener("change",function(){
  const val = this.value;
  const filtered = val ? accounts.filter(a=>a.branch===val) : accounts;
  displayAccounts(filtered);
});

// Sort
function sortByBalance(){
  accounts.sort((a,b)=>b.balance - a.balance);
  refreshUI();
}

// Total Balance
function updateTotalBalance(){
  const total = accounts.reduce((sum,a)=>sum+a.balance,0);
  document.getElementById("totalBalance").innerText = total;
}

function refreshUI(){
  displayAccounts(accounts);
  updateTotalBalance();
}

loadAccounts();