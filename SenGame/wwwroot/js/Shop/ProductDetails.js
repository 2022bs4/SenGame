

$(document).ready(function () {
    $('main').addClass("CommodityDetials close-section")
    $('main').removeClass("container-fluid")

    //CloneGame()
    GameSlideshow()
    RecommendTemplate()
/*    SysClone("Min-Cnfigure", "最低配備 :")*/
    //SysClone("Suggest-Configure", "建議配置 :")
})



////圖文簡介
//function GameSmapleIntroduce() {
//    $('h2').text('Crusader KingIII')
//    $(".Game-Introduce").find('img').attr("src", "")
//    $(".Game-Introduce").find('p').text('')
//}
////金錢加載
//function BtnFunction() {
//    let GamePrice = `<p class="m-0 pl-0">售價: NT $${9527}</p>`;
//    $('.Game-Price').append(GamePrice)
//}

// 以下為幻燈片動態
function GameSlideshow() {
    fetch("/Shop/ProductSwipper", {method:'post'})
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

/* 配置*/
//function SysClone(configure, configureText) {
//    let Min_Cnfigure = document.querySelector(`.${configure}`)
//    let MinClone = GameSystem.content.cloneNode(true)
//    let System_box = MinClone.querySelector('.System-box')
//    MinClone.querySelector('span').innerText = configureText
//    MinClone.querySelector('.bit').innerText = '需要 64 位元的處理器及作業系統'
//    MinClone.querySelector('.Stytem').innerText = "Windows® 8.1 64 bit / Windows® 10 Home 64 bit"
//    MinClone.querySelector('.Processor').innerText = "Intel® Core™ i3-2120 / AMD® FX 6350"
//    MinClone.querySelector('.Memory').innerText = " 6 GB 記憶體"
//    MinClone.querySelector('.GraphicsCard').innerText = ' Nvidia® GeForce™ GTX 660 (2GB) / AMD® Radeon™ HD 7870 (2GB) / Intel® Iris Pro™ 580 / Intel® Iris® Plus G7 / AMD® Radeon™ Vega 11'
//    MinClone.querySelector('.Storage').innerText = " 8 GB 可用空間"
//    Min_Cnfigure.append(MinClone)
//    System_box.classList.add("Template-box")
//    return MinClone
//}

//推薦Template
function RecommendTemplate() {
    let box = document.querySelector('.Recommend')
    for (let i = 0; i < 2; i++) {
        let boxClone = Shopping_Recommend.content.cloneNode(true)
        box.append(boxClone)
    }
}
//廣告清除
function adClear() {
    $('.Video-Clear').click(function () {
        $('.Video-Area').hide()
    })
}





