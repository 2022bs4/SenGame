

$(document).ready(function () {
    $('main').addClass("CommodityDetials close-section")
    $('main').removeClass("container-fluid")
    ProductSystemtoggle()

    //CloneGame()
    GameSlideshow()
    RecommendTemplate()
})


function ProductSystemtoggle() {
    $('.btn-Mac').click(function () {
        $('.Window').addClass('System_Transform')
        $('.Mac').removeClass('System_Transform')
    })
    $('.btn-Window').click(function () {
        $('.Window').removeClass('System_Transform')
        $('.Mac').addClass('System_Transform')
    })
}



// 以下為幻燈片動態
function GameSlideshow() {
    fetch("/Shop/ProductSwipper/", {method:'post'})
        .then(response => response.json())
        .then(result => {
            setSliders(result)
            InitializeSwiper()
        })
    let mainphoto, thumbs
    function setSliders(namesArray) {
  
        mainphoto = $("#mainphoto");
        thumbs = $("#thumbs")
        namesArray.forEach((item, index) => {
            let slideDiv = $("<div></div>")
            slideDiv.addClass("swiper-slide")
            let img = $("<img>");
            img.attr("src", `${item.mediaUrl}`)

            img.attr("class", 'w-100 ')
            slideDiv.append(img);
            let $clon1 = slideDiv.clone();
            let $clon2 = slideDiv.clone();
            mainphoto.append($clon1);
            thumbs.append($clon2);
        })
    }
    function InitializeSwiper() {
        var swiper = new Swiper(".mySwiper2", {
            spaceBetween: 4,
            slidesPerView: 4,
            freeMode: true,
            watchSlidesProgress: true,
            autoHeight: true,
        });
        var swiper2 = new Swiper(".mySwiper1", {
            spaceBetween: 10,
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
            thumbs: {
                swiper: swiper,
            },
            autoHeight: true,
        })
    }
}

//詳細圖文介紹區之動態產生
//function CloneGame() {
//    let GameDatails = document.querySelector('.Game-Datails')
//    let GameClone = GamePictureText.content.cloneNode(true)
//    GameClone.querySelector('img').src = ""
//    GameClone.querySelector('h4').innerText = ''
//    GameClone.querySelector('p').innerHTML = ' '
//    GameDatails.append(GameClone);
//}

//推薦Template
function RecommendTemplate() {
    const ProductRecommend = "/Shop/ProductRecommend"
    let box = document.querySelector('.Recommend')
    fetch(ProductRecommend, { method: 'post' })
        .then(response => response.json())
        .then(result => {
            result.forEach(item => {
                let boxClone = Shopping_Recommend.content.cloneNode(true)
                boxClone.querySelector('img').src = `${item.mediaUrl}`
                boxClone.querySelector('img').alt = `${item.gameName}`
                boxClone.querySelector('a').href =`/Shop/ProductDetails/${item.gameId}`
                boxClone.querySelector('.Recommend-Price').innerHTML= `${item.gameName} <br/> 售價: NT$${item.gamePrice}`
                box.append(boxClone)
            })
        })

        
        

}
//廣告清除
function adClear() {
    $('.Video-Clear').click(function () {
        $('.Video-Area').hide()
    })
}





