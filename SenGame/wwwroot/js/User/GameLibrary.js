//忍術
var gamebutton = document.querySelector(".drop-button");
var ul = document.querySelector(".drop");
var gamebutton = document.querySelector('.button');
var gamebutton2 = document.querySelector('.zxc');
var game = document.querySelector(".game");
var getgamecard = document.getElementById("gamedetail")


$(document).ready(function () {
    
});








//獲取當前點擊到的遊戲資料
$(function () {
    $(".mygame-list-detail>li").click((e) => {
        //先清空節點裡的子元素
        //game.innerHTML = "";
        console.log(e.target.innerHTML);
        var name = { GameName: e.target.innerHTML };
        //$.post('/User/GameDeatial', name, function (res) {
        //    console.log(res)
        //}, 'json') 

        fetch('/User/_GameDetailPartial', {
            method: 'Post',
            headers: new Headers({
                'Content-Type':'application/json :charset=UTF-8'
            }),
            body: JSON.stringify(name)
        })
            .then((res) => res.json())
            .then((res) => {
                console.log(res)
                getgamedetail(res)
                //抓到集合帶進去參數
                //用template方式append進去節點
                
            });

    })

   
})


    
    
    

function getcard(mediaUrl, gameIntroduction, developer, releaseTime) {
    let clonecard = document.getElementById("getgamecard").content.cloneNode(true);
    //遊戲主要圖片
    clonecard.querySelector(".game-img>img").src = mediaUrl;
    //遊戲右邊小圖&遊戲簡介
    clonecard.querySelector(".game-details>img").src = mediaUrl;

    clonecard.querySelector(".gameIntroduction").innerHTML=gameIntroduction;
    //開發商
    clonecard.querySelector(".game-develpoer>.col-md-8>p").innerHTML=developer;
    //開發人員
    //clonecard.querySelector("game-maker>col-8") =
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
function getgamedetail(res) {

    res.getGameDetails.forEach(item => {
        gamedetail.append(getcard(item.mediaUrl,  item.gameIntroduction,item.developer,item.releaseTime))
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
    observer: true,
});


