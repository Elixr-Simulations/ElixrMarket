const notifyEmptyCart = () => {
    noProductText = document.createElement('SPAN');
    noProductText.innerText = "You have no items in your cart";
    noProductText.classList.add('mb-3');
    console.log('test')
    document.getElementById('item-list').appendChild(noProductText);
    //document.getElementById('cart-container').removeChild(document.getElementById('subtotal'));
}

const calculateTotal = (productList) => {
    let sum = 0;
    for (let i = 0; i < productList.length; i++) {
        sum += parseFloat(productList[i].price);
    }

    return sum;
}

const createProductHtml = (product, addRemoveButton) => {
    console.log(product);
    // create all elements for each product
    currentProductContainer = document.createElement('DIV');
    currentProductContainer.classList.add('product-container');
    currentProductContainer.id = product.id;

    currentProductInfo = document.createElement('DIV');
    currentProductInfo.classList.add('info-container');

    currentProductImgContainer = document.createElement('DIV');
    currentProductImgContainer.classList.add('img-container');

    currentProductImg = document.createElement('IMG');
    currentProductImg.src = "/product-media/" + product.id + "/img/main.jpg";

    currentProductName = document.createElement('DIV');
    currentProductName.classList.add('name-container');
    currentProductName.innerText = product.name;

    currentProductControls = document.createElement('DIV');
    currentProductControls.classList.add('controls-container');

    currentProductPrice = document.createElement('SPAN');
    currentProductPrice.innerText = '$' + product.price;

    let currentProductDeleteButton

    if (addRemoveButton) {
        currentProductDeleteButton = document.createElement('BUTTON');
        currentProductDeleteButton.onclick = (() => deleteProduct(product.id));
        currentProductDeleteButton.classList.add('delete-button');
        currentProductDeleteButton.classList.add('btn');
        currentProductDeleteButton.classList.add('btn-light');
        currentProductDeleteButton.innerText = 'Remove';
    }

    currentProductControls.appendChild(currentProductPrice);

    if (currentProductDeleteButton) {
        currentProductControls.appendChild(currentProductDeleteButton);
    }

    // combine elements to create product display
    currentProductInfo.appendChild(currentProductImg);
    currentProductInfo.appendChild(currentProductName);
    currentProductContainer.appendChild(currentProductInfo);
    currentProductContainer.appendChild(currentProductControls);

    return currentProductContainer;
}

// function to display cart
const displayCart = (addRemoveButton) => {
    // get cart
    let currentCart = JSON.parse(localStorage.getItem('cart'));
    let cartDisplay = document.getElementById('item-list');

    if (currentCart['products'].length == 0) {
        notifyEmptyCart();
        return;
    }

    // for each product in cart, generate html element and add to product list    
    for (let i = 0; i < currentCart['products'].length; i++) {
        // generate html for each product
        cartDisplay.appendChild(createProductHtml(currentCart['products'][i], addRemoveButton));
    }

    // create subtotal text
    subtotalText = document.createElement('H5');
    subtotalText.id = 'subtotal';
    subtotalText.innerText = 'Subtotal: $' + calculateTotal(currentCart['products']);
    subtotalText.align = 'right';
    subtotalText.classList.add('mt-3');
    document.getElementById('cart-container').appendChild(subtotalText);
}