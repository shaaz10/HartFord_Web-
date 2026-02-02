const products = [
    { id: 1, name: "Laptop", price: 50000, category: "electronics" },
    { id: 2, name: "Headphones", price: 2000, category: "electronics" },
    { id: 3, name: "JavaScript Book", price: 800, category: "books" },
    { id: 4, name: "Notebook", price: 200, category: "books" }
  ];

  let cart = [];

  /* DOM */
  const productList = document.getElementById("productList");
  const cartItems = document.getElementById("cartItems");
  const cartCount = document.getElementById("cartCount");
  const total = document.getElementById("total");
  const search = document.getElementById("search");
  const category = document.getElementById("category");
  const sort = document.getElementById("sort");

  /* RENDER PRODUCTS */
  function renderProducts() {
    productList.innerHTML = "";

    let list = products
      .filter(p =>
        p.name.toLowerCase().includes(search.value.toLowerCase()) &&
        (category.value === "all" || p.category === category.value)
      );

    if (sort.value === "low") list.sort((a,b) => a.price - b.price);
    if (sort.value === "high") list.sort((a,b) => b.price - a.price);

    list.forEach(p => {
      const div = document.createElement("div");
      div.className = "product";
      div.dataset.id = p.id;

      div.innerHTML = `
        <div>
          <strong>${p.name}</strong><br>
          ₹${p.price}
        </div>
        <button>Add to Cart</button>
      `;

      productList.appendChild(div);
    });
  }

  /* ADD TO CART (EVENT DELEGATION) */
  productList.addEventListener("click", e => {
    if (e.target.tagName !== "BUTTON") return;

    const id = Number(e.target.closest(".product").dataset.id);
    const item = cart.find(i => i.id === id);

    if (item) item.qty++;
    else {
      const product = products.find(p => p.id === id);
      cart.push({ ...product, qty: 1 });
    }

    renderCart();
  });

  /* CART EVENTS */
  cartItems.addEventListener("click", e => {
    const row = e.target.closest(".cart-item");
    if (!row) return;

    const id = Number(row.dataset.id);
    const item = cart.find(i => i.id === id);

    if (e.target.classList.contains("inc")) item.qty++;
    if (e.target.classList.contains("dec")) item.qty--;
    if (e.target.classList.contains("remove")) {
      cart = cart.filter(i => i.id !== id);
    }

    cart = cart.filter(i => i.qty > 0);
    renderCart();
  });

  /* RENDER CART */
  function renderCart() {
    if (cart.length === 0) {
      cartItems.innerHTML = "<div class='empty'>Cart is empty</div>";
      cartCount.textContent = 0;
      total.textContent = 0;
      return;
    }

    cartItems.innerHTML = "";
    let sum = 0;

    cart.forEach(i => {
      sum += i.price * i.qty;

      const div = document.createElement("div");
      div.className = "cart-item";
      div.dataset.id = i.id;

      div.innerHTML = `
        <span>${i.name} x ${i.qty}</span>
        <div>
          <button class="inc">+</button>
          <button class="dec">-</button>
          <button class="remove">✖</button>
        </div>
      `;

      cartItems.appendChild(div);
    });

    cartCount.textContent = cart.reduce((s,i)=>s+i.qty,0);
    total.textContent = sum;
  }

  /* FILTER EVENTS */
  search.addEventListener("keyup", renderProducts);
  category.addEventListener("change", renderProducts);
  sort.addEventListener("change", renderProducts);

  /* INIT */
  renderProducts();