let btn_buy = document.querySelector(".Continue-Shopping")

$(document).ready(function () {
    $('main').addClass("ShoppingCart d-md-flex f-md-flex position-relative")
    $('main').removeClass("container-fluid")
    $('.DelAllItem').click(function () {
        $('.Spopping-Select').html(' ')
        $('.Shpopping-Price').text('')
    })
        //ShoppingTemplate()
    RecommendTemplate();
})




btn_buy.addEventListener('click', function () {
    document.getElementById("form").submit();
})

// 之後要動態產生
function ShoppingTemplate() {
    let Spopping_Select = document.querySelector('.Spopping-Select')
    let boxClone1 = Spopping_Select_Template.content.cloneNode(true)
    let item = boxClone1.querySelector('.Game-Shopping-Item')
    let boxImg = boxClone1.querySelector('img')
    let boxText = boxClone1.querySelector('.Game-Price')
    let btn = boxClone1.querySelector('button');
    btn.addEventListener('click', function () {
        Spopping_Select.removeChild(item)
    })
    boxText.classList.add('Game-Price')
    boxImg.classList.add("First_Template_img")
    Spopping_Select.append(boxClone1)
}
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

