//忍術
var gamebutton = document.querySelector(".drop-button");
var ul = document.querySelector(".drop");
var gamebutton = document.querySelector('.button');
var gamebutton2 = document.querySelector('.zxc');
var gamedetail = document.querySelector(".gamedetail");
var getgamecard = document.getElementById("getgamecard")


$(document).ready(function () {
    getgamedetail(res)
});

function buttoneffect(button) {
    var duration = 0.3,
        delay = 0.08;
    TweenMax.to(button, duration, { scaleY: 1.6, ease: Expo.easeOut });
    TweenMax.to(button, duration, { scaleX: 1.2, scaleY: 1, ease: Back.easeOut, easeParams: [3], delay: delay });
    TweenMax.to(button, duration * 1.25, { scaleX: 1, scaleY: 1, ease: Back.easeOut, easeParams: [6], delay: delay * 3 });
}



//gamebutton.addEventListener('click', function () {
//    buttoneffect(gamebutton)
//    window.open("https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe")
//});
//gamebutton2.addEventListener('click', function () {
//    buttoneffect(gamebutton2)

//});


//獲取當前點擊到的遊戲資料
$(function () {
    $(".mygame-list-detail>li").click((e) => {
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
//function getcard() {
//    let clonecard = document.getElementById("getgamecard").content.cloneNode(true);
//    clonecard.(".game-img>img") =
//}

function getgamedetail(res) {
    
    let clonecard = document.getElementById("getgamecard").content.cloneNode(true);
    clonecard.(".game-img>img").src = res.getGameDetails.mediaUrl;
    clonecard.(".game-details>img").src = res.getGameDetails.mediaUrl;
    
    

    
    
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


