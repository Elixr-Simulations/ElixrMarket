const deleteProduct = (id) => {
    // get cart
    let currentCart = JSON.parse(localStorage.getItem('cart'));

    console.log(currentCart['products']);

    // filter product from list
    let filteredProducts = currentCart['products'].filter(p => { return p.id !== id });

    // update localstorage with filtered list
    localStorage.setItem('cart', JSON.stringify({ products: filteredProducts }));
    console.log(document.getElementById(id));
    document.getElementById('item-list').removeChild(document.getElementById(id));
    document.getElementById('subtotal').innerText = 'Subtotal: $' + calculateTotal(filteredProducts);

    if (filteredProducts.length === 0) {
        notifyEmptyCart();
    }
}