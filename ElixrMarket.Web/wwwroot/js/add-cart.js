// add empty products object to cart if cart is null
const initializeCart = () => {
    if (!localStorage.getItem('cart')) {
        localStorage.setItem('cart', JSON.stringify({ products: [] }));
    }
}

const addToCart = (productId) => {
    // get cart
    let currentCart = JSON.parse(localStorage.getItem('cart'));

    // get matching product from cart
    let existingProduct = currentCart['products'].find(p => p.id == productId);

    // if product isn't in cart
    if (existingProduct == undefined) {
        currentCart['products'].push({
            id: document.getElementById(productId + '-id').value,
            price: document.getElementById(productId + '-price').value,
            name: document.getElementById(productId + '-name').value,
        });
        console.log(currentCart);
    }
    // otherwise notify user that it's already in their cart
    else {
        Snackbar.show({ pos: 'bottom-center', text: 'This item is already in your cart.' })
        return;
    }

    // update cart in local storage
    localStorage.setItem('cart', JSON.stringify(currentCart));

    let productName = document.getElementById(productId + '-name').value;

    Snackbar.show({ pos: 'bottom-center', text: productName + ' is added.' })
}