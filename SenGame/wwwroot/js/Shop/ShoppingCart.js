////const { error } = require("jquery");

$(document).ready(function () {
    $('main').addClass("ShoppingCart d-md-flex f-md-flex position-relative")
    $('main').removeClass("container-fluid")
    setTimeout(function () { RecommendTemplate() }, 1500);
    CheckFucntion();
    DeleteAllItem()
})

//刪除所有遊戲
function DeleteAllItem() {
    let btn_DelAllItem = document.querySelector('.DelAllItem')
    btn_DelAllItem.addEventListener('click', function () {
        const url = `/api/Shop/DeleteAll`
        fetch(url, {
            method: "POST"
        })
            .then(response => {
                alert('已移除所有遊戲');
                window.location.reload();
            })
            .catch(error => {
                alert(`Error : ${error}`)
            })
    })
}


//鏈結結帳畫面
function CheckFucntion() {
    let checkBuy = document.querySelector('.checkout')
    let gameId = document.querySelectorAll('.GameID')
    let gameIdArray = []
    for (let i = 0; i < gameId.length; i++) {
        gameIdArray.push(gameId[i].value)
    }
    checkBuy.addEventListener('click', function () {
        CheckBuyFetch()
    });
    async function CheckBuyFetch() {
        const url = '/api/Shop/AddOrderDetails'
        let request = new Request(url, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                SelectId: `${gameIdArray}`,
            })
        })
        let action = await fetch(request);
        let data = await action.text();
        alert(data);
        Return();
    }
    async function Return() {
        window.location.href = '/Shop/CheckBuy';
    }

}


//推薦Template
function RecommendTemplate() {
    const ProductRecommend = "/api/Shop/ProductRecommend"
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

