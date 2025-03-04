
addEventListener("load", () => {
    
  
    
    drawShoppgBag();
}
)


const drawTemplate = (product) =>{

    let temp = document.getElementById("temp-row");
    let cloneProduct = temp.content.cloneNode(true)

    let url =`./pictures/${product.imgPath}.png`;


    cloneProduct.querySelector(".image").style.backgroundImage=`url(${url})`



    cloneProduct.querySelector(".itemName").textContent = product.productName
    cloneProduct.querySelector(".itemNumber").textContent = product.price




  
    cloneProduct.querySelector(".expandoHeight").addEventListener('click', () => { deleteProductFromCart(product) })
    document.querySelector("tbody").appendChild(cloneProduct)




}

const deleteProductFromCart = (product) => {
    let products = sessionStorage.getItem("shopingBag")
    products = JSON.parse(products)
    let i = 0;
    for (; i < products.length; i++) {

        if (products[i].ProductId == product.ProductId) 
            break;
        
    }
    products.splice(i, 1)
    sessionStorage.setItem("shopingBag",JSON.stringify( products))

    window.location.href ="ShoppingBag.html"
    drawShoppgBag();
}





let price = 0;

const drawShoppgBag =async() => {
    let products = sessionStorage.getItem("shopingBag")
    products = JSON.parse(products)
    
    let itemCount = 0;

    for (let i = 0; i < products.length; i++) {
        drawTemplate(products[i]);
        price += products[i].price;
        itemCount += 1;

    }
    document.getElementById("itemCount").innerHTML = itemCount;
    document.getElementById("totalAmount").innerHTML = price;



}



const detials = () => {
    let UserId = JSON.parse(sessionStorage.getItem("id"))
    let orderItems1 = JSON.parse(sessionStorage.getItem("shopingBag"))
    const OrderItems = []
    orderItems1.map(t => {
        let object = { productId: t.productId, Quentity: 1 }

        OrderItems.push(object)
    })

    let OrderSum = price;
  
   
    return ({
         OrderSum, UserId, OrderItems,
    })
}



const placeOrder = async () => {
    if (price != 0) {
        if (sessionStorage.getItem("id")) {
            let alldetials = detials()
            console.log(alldetials) 
            const orderss = await fetch('api/Orders', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },

                body: JSON.stringify(alldetials)

            });
            ordderJson = await orderss.json();
            if (orderss.ok) {
                alert("ההזמנה נוספה בהצלחה")

                sessionStorage.setItem("basket", JSON.stringify([]))
                window.location.href = "Products.html"

            }
        }
        else {

            alert("אינך רשום")
            window.location.href = "home.html"
        }


    }
    else {
        alert("הסל ריק")
        window.location.href = "Products.html";
    }

}


    
