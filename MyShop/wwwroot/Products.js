 addEventListener("load", () => {
    let product = []
    let category =  []
    sessionStorage.setItem("category", JSON.stringify(category))
    sessionStorage.setItem("shopingBag", JSON.stringify(product))
    document.querySelector("#ItemsCountText").textContent = product.length
    tmp()
    console.log("1")
  

}
)
const tmp = async () => {
    await drawCategory()
    await filterProducts()
}

const getData = async () => {
    let search =
    {
        desc: document.querySelector("#nameSearch").value,
        minPrice: parseInt(document.querySelector("#minPrice").value),
        maxPrice: parseInt(document.querySelector("#maxPrice").value),
        categoryIds: sessionStorage.getItem("category")

       
     
    }
    return search;
}


const filterProducts = async () => {
    //int ? minPrice, int ? maxPrice, int ? [] categoryIds, string ? desc
    let { desc, minPrice, maxPrice, categoryIds } = await getData();
    categoryIds = JSON.parse(categoryIds);
    let url = `api/Products/`

    if (desc || maxPrice || minPrice || categoryIds.length != 0) {
        url += '?'
        if (minPrice)
            url += `&minPrice=${minPrice}`
        if (maxPrice)
            url += `&maxPrice=${maxPrice}`



        if (categoryIds.length != 0) {
            for (let i = 0; i < categoryIds.length; i++)
                url += `&categoryIds=${categoryIds[i]}`
        }
        if (desc)
            url += `&desc=${desc}`
    }
    try {
        const responsePost = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                minPrice: minPrice,
                maxPrice: maxPrice,

                categoryIds: categoryIds,
                /* nameSearch: nameSearch,*/
                desc: desc,
            }
        });
        if (responsePost.status == 204)
            alert("not found products")
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status:${response.status}`)
        }
        const dataPost = await responsePost.json();
        console.log(dataPost);
        document.getElementById("counter").textContent = dataPost.length
        console.log(document.getElementById("counter").textContent);
        drawProducts(dataPost);
    }
    catch (error) {

        alert("יש לכם שגיאה בפלטור")
    }

}

    const drawCategory = async () => {
        category = await getAllCategory()
        for (let i = 0; i < category.length; i++) {
            let tmp = document.getElementById("temp-category");
            let cloneCategory = tmp.content.cloneNode(true)
            cloneCategory.querySelector("input").id = i
            cloneCategory.querySelector("input").addEventListener('change', () => { filterCategory(category[i], i) })
            cloneCategory.querySelector("label").textContent = category[i].categoryName

            document.getElementById("categoryList").appendChild(cloneCategory)
        }
    }
const drawProducts = async (products) => {

    document.getElementById("PoductList").innerHTML = ""
    for (let i = 0; i < products.length; i++) {
        drawTemplate(products[i])
    }
}

//const addToCart = (product) => {

//    let products = sessionStorage.getItem("shopingBag")
//    products = JSON.parse(products)
//    products.push(product)
//    sessionStorage.setItem("shopingBag", JSON.stringify(products))
//    document.querySelector("#ItemsCountText").textContent = parseInt(document.querySelector("#ItemsCountText").textContent) + 1;


//}

const addToCart = (product) => {
    if (sessionStorage.getItem("id") == null) {
        alert("על מנת ליצור סל קניות עליך להירשם במערכת")
    }

    else {
        let products = sessionStorage.getItem("shopingBag")
        products = JSON.parse(products)
        products.push(product)
        sessionStorage.setItem("shopingBag", JSON.stringify(products))
        document.querySelector("#ItemsCountText").textContent = parseInt(document.querySelector("#ItemsCountText").textContent) + 1
    }
}

const drawTemplate = (product) => {

        let temp = document.getElementById("temp-card");
        let cloneProduct = temp.content.cloneNode(true)

    cloneProduct.querySelector("img").src = "./pictures/" + product.imgPath+".jpg" ;
    
    
   
    cloneProduct.querySelector("h1").textContent = product.productName
    cloneProduct.querySelector(".price").textContent = product.price
       



    cloneProduct.querySelector(".description").innerText = product.decripition;
        cloneProduct.querySelector(".bag").addEventListener('click', () => { addToCart(product) })
        document.getElementById("PoductList").appendChild(cloneProduct)






    }
    const getAllCategory = async () => {
        try {
            const responsePost = await fetch('api/Categories', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },

            });
            if (responsePost.status == 204)
                alert("not found categories")
            if (!responsePost.ok) {
                throw new Error(`HTTP error! status:${response.status}`)
            }
            const dataPost = await responsePost.json();
            console.log(dataPost);
            return (dataPost);

        }
        catch (error) {

            alert("יש לכם שגיאה בקבלת הקטגוריות")
        }
    }

const filterCategory =async (category, index) => {
   

    const input = document.getElementById(index)

       


        if (input.checked) {
            let categories = sessionStorage.getItem("category")
            categories = JSON.parse(categories)
            
            categories.push(category.categoryId)
            sessionStorage.setItem("category", JSON.stringify(categories))
        }
        else {
            let categories = sessionStorage.getItem("category")
            categories = JSON.parse(categories)
            let i = 0;
            for (; i < categories.length; i++) {
                if (categories[i] == category.categoryId)
                    break;
            }
            
            categories.splice(i, 1);
            sessionStorage.setItem("category", JSON.stringify(categories))
        }
       await filterProducts()
    }
const moveToLogin = () => {

    window.location.href = "home.html"

}
const moveToUpdate = () => {
    window.location.href = "updateUser.html"
}

const MoveToLogOut = () => {
    sessionStorage.removeItem("id");
    /*sessionStorage.setItem("id", null)*/
    /* window.location.href = "Products.html"*/
    
    sessionStorage.setItem("shopingBag", JSON.stringify([]))
}

