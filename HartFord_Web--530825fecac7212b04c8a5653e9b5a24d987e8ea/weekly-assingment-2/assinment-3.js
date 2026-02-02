// Bug 1
for (let i = 0; i < customers.length; i++) {
  console.log(customers[i].name);
}

// Bug 2
const activeCustomers = customers.filter(c => c.active === true);

// Bug 3
const updatedPremiums = customers.map(c => {
  if (c.age >= 50) {
    return { ...c, premium: c.premium * 1.1 };
  }
  return c;
});

// Bug 4
const totalPremium = customers.reduce((total, c) => {
  return total + c.premium;
}, 0);

// Bug 5
console.log(`Customer ${customers[0].name} has policy ${customers[0].policy}`);

// Bug 6
const policyCount = customers.reduce((count, c) => {
  count[c.policy] = (count[c.policy] || 0) + 1;
  return count;
}, {});

// Bug 7
const customersWithRisk = customers.map(c => {
  let riskLevel;
  if (c.age < 35) riskLevel = "Low";
  else if (c.age <= 50) riskLevel = "Medium";
  else riskLevel = "High";
  return { ...c, riskLevel };
});

// Bug 8
let active = 0, inactive = 0;
for (const c of customers) {
  if (c.active) active++;
  else inactive++;
}

// Bug 9
const getLifeCustomers = () =>
  customers.filter(c => c.policy === "Life").map(c => c.name);

// Bug 10
const sortedCustomers = [...customers].sort((a, b) => b.premium - a.premium);
