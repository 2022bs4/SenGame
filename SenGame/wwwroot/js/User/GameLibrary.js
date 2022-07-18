//忍術
var gamebutton = document.querySelector(".drop-button");
var ul = document.querySelector(".drop");
var gamebutton = document.querySelector('.button');
var gamebutton2 = document.querySelector('.zxc');
var game = document.querySelector(".game-list-detail");
var getgamecard = document.getElementById("gamedetail");
var swiperwrapper = document.querySelector(".swiper-wrapper");
var swiper = document.getElementById("swiper");
//自定義右鍵菜單
var ul = document.getElementById("ul");


$(document).ready(function () {
    custommenu()
});
function custommenu() {
    document.querySelector(".mygame-list-detail").onmousedown = function (e) {

        document.getElementById("ul").onmousedown = function (h) {
            console.log(e.target.innerHTML);
            console.log(h.target.innerHTML)
            if (h.target.innerHTML == "加到我的最愛") {
                console.log("zxc");
            }
            else {
                console.log("asd")
            }

        }
    }
}

function myFunction(e) {
    e = e || window.event;
    e.preventDefault ? e.preventDefault() : (e.returnValue = false);
    var x = e.clientX;
    var y = e.clientY;

    ul.style.display = 'block';
    ul.style.top = y + 'px';
    ul.style.left = x + 'px';


}
document.onmousedown = function (e) {
    ul.style.display = "none"
}




//獲取當前點擊到的遊戲資料
//$(function () {
//    $(".mygame-list-detail>li").click((e) => {
//        //先清空節點裡的子元素
//        var main = document.querySelector("main");
//        main.style.height = "100%";
//        game.innerHTML = "";
//        swiperwrapper.innerHTML = "";
//        console.log(e.target.innerHTML);
//        var name = { GameName: e.target.innerHTML };
//        //$.post('/User/GameDeatial', name, function (res) {
//        //    console.log(res)
//        //}, 'json') 

//        fetch('/User/GameLibrary', {
//            method: 'Post',
//            headers: new Headers({
//                'Content-Type': 'application/json :charset=UTF-8'
//            }),
//            body: JSON.stringify(name)
//        })
//            .then((res) => res.json())
//            .then((res) => {
//                console.log(res)
//                getgamedetail(res)
//                //抓到集合帶進去參數
//                //用template方式append進去節點

//            });
//    })
//})


function getcard(mediaUrl, gameIntroduction, developer,marker, releaseTime) {
    let clonecard = document.getElementById("getgamecard").content.cloneNode(true);
    //遊戲主要圖片
    clonecard.querySelector(".game-img>img").src = mediaUrl;
    //遊戲右邊小圖&遊戲簡介
    //clonecard.querySelector(".game-details>img").src = mediaUrl;
    clonecard.querySelector(".gameIntroduction").innerHTML=gameIntroduction;

    //開發人員
    clonecard.querySelector(".game-maker>.col-md-8>p").innerHTML = marker;
    //開發商
    clonecard.querySelector(".game-develpoer>.col-md-8>p").innerHTML=developer;
    //發行日期
    clonecard.querySelector(".game-releaseTime>.col-md-8>p").innerHTML = releaseTime
    
    clonecard.querySelector("button").addEventListener('click', function () {
        buttoneffect(this)
        window.open("https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe")
    });
    clonecard.querySelector(".zxc").addEventListener('click', function () {
        buttoneffect(this)
    });


    return clonecard
}


function pic(mediaUrl) {
    let clonepic = document.getElementById("swiper").content.cloneNode(true);
    clonepic.querySelector(".swiper-slide>img").src = mediaUrl 
    return clonepic
}
function getgamedetail(res) {
  
    res.getGameDetails.forEach(item => {
        item.gameSwipers.forEach(img => {

            console.log(img.mediaUrl)
            swiperwrapper.append(pic(img.mediaUrl));

            
        })
        
        game.append(getcard(item.mediaUrl, item.gameIntroduction, item.developer, item.marker, item.releaseTime))
    })
    
    
            
}
//按鈕效果
function buttoneffect(button) {
    var duration = 0.3,
        delay = 0.08;
    TweenMax.to(button, duration, { scaleY: 1.6, ease: Expo.easeOut });
    TweenMax.to(button, duration, { scaleX: 1.2, scaleY: 1, ease: Back.easeOut, easeParams: [3], delay: delay });
    TweenMax.to(button, duration * 1.25, { scaleX: 1, scaleY: 1, ease: Back.easeOut, easeParams: [6], delay: delay * 3 });
}
    
    

//swiper加載
var swiper = new Swiper(".mySwiper", {
    slidesPerView: "auto",
    spaceBetween: 30,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    autoplay: { delay: 3000 },
    observer: true,
});




    
    
    



