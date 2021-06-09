const getCheckoutItems = () => {
    let cart = JSON.parse(localStorage.getItem('cart'));
    let idString = '';
    for (var i = 0; i < cart["products"].length; i++) {
        idString += cart["products"][i].id;
    }

    return idString;
}

document.getElementById('checkout-items').value = getCheckoutItems();