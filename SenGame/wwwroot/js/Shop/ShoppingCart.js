let btn_buy = document.querySelector(".Continue-Shopping")

$(document).ready(function () {
    $('main').addClass("ShoppingCart d-md-flex f-md-flex position-relative")
    $('main').removeClass("container-fluid")
    $('.DelAllItem').click(function () {
        $('.Spopping-Select').html(' ')
        $('.Shpopping-Price').text('')
    })
    for (let i = 0; i < 4; i++) {
        ShoppingTemplate()
    }
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
    let pic = ["https://cdn.cloudflare.steamstatic.com/steam/apps/597180/capsule_184x69_tchinese.jpg?t=1654230486", "https://cdn.cloudflare.steamstatic.com/steam/apps/597180/capsule_184x69_tchinese.jpg?t=1654230486"]
    let Recommend_Box = document.querySelector('.Shopping-Recommend')
    pic.forEach((item) => {
        let boxClone = Shopping_Recommend.content.cloneNode(true)
        boxClone.querySelector('img').src = item
        Recommend_Box.append(boxClone)
    })
}

