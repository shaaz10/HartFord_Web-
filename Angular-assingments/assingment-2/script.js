/***************************************
 TASK 1 – Select by ID
***************************************/
const title = document.getElementById("pageTitle");
title.textContent = "Customer Insurance Overview";


/***************************************
 TASK 2 – Select by Tag Name
***************************************/
const liItems = document.getElementsByTagName("li");

for (let li of liItems) {
  li.style.border = "1px solid #ccc";
}

console.log("Total customers:", liItems.length);


/***************************************
 TASK 3 – Select by Class Name
***************************************/
const policies = document.getElementsByClassName("policy");

for (let p of policies) {
  p.classList.add("highlight");
  p.style.color = "blue";
}


/***************************************
 TASK 4 – Select using CSS Selectors
***************************************/
const firstCustomer = document.querySelector("#customerList li");
const lastCustomer = document.querySelector("#customerList li:last-child");

if (firstCustomer) {
  firstCustomer.style.backgroundColor = "#fde68a";
}
if (lastCustomer) {
  lastCustomer.classList.add("active");
}


/***************************************
 TASK 5 – HTML Object Collections
***************************************/
console.log("Number of forms:", document.forms.length);
console.log("Number of images:", document.images.length);

for (let link of document.links) {
  link.textContent = "More Info";
}


/***************************************
 TASK 6 – Add New Customer Dynamically
***************************************/
const newCustomer = document.createElement("li");
newCustomer.textContent = "Suresh – Health";
newCustomer.className = "customer";
document.getElementById("customerList").appendChild(newCustomer);

/*
 Observation:
 - getElementsByTagName / getElementsByClassName → AUTO updates
 - querySelectorAll → DOES NOT auto update
*/


/***************************************
 TASK 7 – Attribute-Based Selection
***************************************/
const textInputs = document.querySelectorAll('input[type="text"]');

textInputs.forEach(input => {
  input.style.backgroundColor = "yellow";
  input.placeholder = "Enter Full Name";
});


/***************************************
 TASK 8 – Multiple Class Selection
***************************************/
const priorityCustomers = document.querySelectorAll(".customer.active");

priorityCustomers.forEach(c => {
  c.style.color = "darkgreen";
  c.textContent += " (Priority Customer)";
});


/***************************************
 TASK 9 – Descendant vs Child Selector
***************************************/
const descendantLis = document.querySelectorAll("#customerList li");
const childLis = document.querySelectorAll("#customerList > li");

console.log("Descendant <li> count:", descendantLis.length);
console.log("Direct child <li> count:", childLis.length);


/***************************************
 TASK 10 – Even / Odd Selection
***************************************/
const evenCustomers = document.querySelectorAll("#customerList li:nth-child(even)");
const oddCustomers = document.querySelectorAll("#customerList li:nth-child(odd)");

evenCustomers.forEach(li => li.style.backgroundColor = "#e5e7eb");
oddCustomers.forEach(li => li.style.backgroundColor = "#dbeafe");


/***************************************
 TASK 11 – Form Elements Collection
***************************************/
const enquiryForm = document.forms["enquiryForm"];

for (let element of enquiryForm.elements) {
  console.log("Form field:", element.name);
}

// Submit NOT disabled (interactive requirement)


/***************************************
 TASK 12 – NodeList vs HTMLCollection
***************************************/
const policyHTMLCollection = document.getElementsByClassName("policy");
const policyNodeList = document.querySelectorAll(".policy");

const newPolicy = document.createElement("p");
newPolicy.className = "policy";
newPolicy.textContent = "Travel Insurance";
document.body.appendChild(newPolicy);

/*
 Observation:
 - HTMLCollection updates automatically
 - NodeList does NOT update
*/


/***************************************
 TASK 13 – Text Content Filtering
***************************************/
const customers = document.querySelectorAll("#customerList li");

customers.forEach(c => {
  const text = c.textContent;

  if (text.includes("Life")) {
    c.style.backgroundColor = "#bbf7d0";
  }

  if (text.includes("Vehicle")) {
    c.style.display = "none";
  }
});


/***************************************
 TASK 14 – Closest & Parent Traversal
***************************************/
document.getElementById("customerList").addEventListener("click", e => {
  if (e.target.tagName === "LI") {
    const ul = e.target.closest("ul");
    ul.style.border = "2px solid red";
  }
});


/***************************************
 TASK 15 – Complex Selector Challenge
***************************************/
const policyExceptFirst = document.querySelectorAll(
  "p.policy:not(:first-child)"
);

policyExceptFirst.forEach(p => {
  p.style.fontStyle = "italic";
  p.textContent = "✔ " + p.textContent;
});


/***************************************
 EXTRA – INTERACTIVE SUBMIT & DISPLAY
***************************************/
const form = document.getElementById("enquiryForm");
const customerList = document.getElementById("customerList");

form.addEventListener("submit", function (e) {
  e.preventDefault();

  const name = form.elements["customerName"].value.trim();
  const email = form.elements["email"].value.trim();
  const policy = form.elements["policy"].value;

  if (!name || !email || !policy) {
    alert("Please fill all fields");
    return;
  }

  // Create new customer with SELECTED POLICY
  const li = document.createElement("li");
  li.className = "customer";
  li.textContent = `${name} – ${policy}`;

  // Active selection behavior
  li.addEventListener("click", () => {
    document
      .querySelectorAll("#customerList li")
      .forEach(c => c.classList.remove("active"));
    li.classList.add("active");
  });

  customerList.appendChild(li);
  form.reset();
});


/***************************************
 EXTRA – Policy click highlight
***************************************/
document.addEventListener("click", e => {
  if (e.target.classList.contains("policy")) {
    document
      .querySelectorAll(".policy")
      .forEach(p => p.classList.remove("highlight"));
    e.target.classList.add("highlight");
  }
});
