////const { error } = require("jquery");

let btn_buy = document.querySelector(".Continue-Shopping")

$(document).ready(function () {
    $('main').addClass("ShoppingCart d-md-flex f-md-flex position-relative")
    $('main').removeClass("container-fluid")
    RecommendTemplate();
})

let btn_DelAllItem = document.querySelector('.DelAllItem')
btn_DelAllItem.addEventListener('click', function () {
    const url = `/Shop/DeleteAll`
    fetch(url, {
        method:"POST"
    })
        .then(response => {
            alert('已移除所有遊戲');
            window.location.reload();
        })
        .catch(error => {
            alert(`Error : ${error}`)
        })
})

let checkBuy = document.querySelector('.checkout')


    
    
checkBuy.addEventListener('click', function () {
    let gameId = document.querySelectorAll('.GameID')
    let gameIdArray = []
    for (let i = 0; i < gameId.length; i++) {
        gameIdArray.push(gameId[i].value)
    }
    const url = '/Shop/AddOrderDetails'
    fetch(url, {
        method: "POST",
        headers:{
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            SelectId : `${gameIdArray}`,
        })
    })
        .then(response => {
            alert("OK")
        })
        .catch(erro => {
            alert(erro)
        })
    
});







//推薦Template
function RecommendTemplate() {
    const ProductRecommend = "/Shop/ProductRecommend"
    let box = document.querySelector('.Recommend')
    var GameDatails = document.querySelector(".Main-Content")
    let screenWidth = screen.width;
    fetch(ProductRecommend,)
        .then(response => response.json())
        .then(result => {
            if (GameDatails.getBoundingClientRect().height < 500) {
                result = result.slice(0, 1);
            }
            else if (GameDatails.getBoundingClientRect().height < 1200) {
                result = result.slice(0, 2);
            }
            else if (GameDatails.getBoundingClientRect().height < 1400) {
                result = result.slice(0, 3);
            }
            else {
                result = result;
            }
            if (screenWidth < 768) {
                result = result.slice(0, 2);
            }
            result.forEach(item => {
                let boxClone = Shopping_Recommend.content.cloneNode(true)
                boxClone.querySelector('img').src = `${item.productUrl}`
                boxClone.querySelector('img').alt = `${item.productName}`
                boxClone.querySelector('a').href = `/Shop/ProductDetails/${item.gameId}`
                boxClone.querySelector('.Recommend-Price').innerHTML = `${item.productName} <br/> 售價: NT$${item.productPrice}`
                box.append(boxClone)
            })
        })
}

