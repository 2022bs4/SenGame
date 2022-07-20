//忍術全域變數
var gamebutton = document.querySelector(".drop-button");
var ul = document.querySelector(".drop");
var gamebutton = document.querySelector('.button');
var gamebutton2 = document.querySelector('.zxc');
var game = document.querySelector(".game-list-detail");
var getgamecard = document.getElementById("gamedetail");
var swiperwrapper = document.querySelector(".swiper-wrapper");
var swiper = document.getElementById("swiper");
//自訂義menu
var ul = document.getElementById("ul");


$(document).ready(function () {
    custommenu()
});

function custommenu() {
    var gamedtials = document.querySelectorAll(".mygame-list-detail")
    var gamename;
    gamedtials.forEach(item => {
        var p = item.querySelectorAll("p")
        p.forEach(x => {
            x.onmousedown = function (e) {
                if (e.which == 3) {
                    console.log(x.innerHTML);
                    gamename = x.innerHTML;


                }
            }
        })
    })
    document.getElementById("ul").onmousedown = function (h) {
        var myfavourite;

        console.log(h.target.innerHTML);

        switch (h.target.innerHTML) {
            case "加到我的最愛":
                myfavourite = true;
                break;

            default:
                myfavourite = false;
                break;
        }
        var mygamelibrary =
        {
            GameName: gamename,
            MyFavourite: myfavourite
        }
        fetch('/User/EditGameLibrary', {
            method: 'Post',
            headers: new Headers({
                'Content-Type': 'application/json :charset=UTF-8'
            }),
            body: JSON.stringify(mygamelibrary)
        })
        //.then((res) => res.json())
        //.then((res) => {
        //    console.log(res,"");
        //});

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



//點擊到打哪個遊戲加載傳送遊戲請求 
$(function () {
    $(".mygame-list-detail>li").click((e) => {
        var main = document.querySelector("main");
        main.style.height = "100%";
        
        game.innerHTML = "";
        swiperwrapper.innerHTML = "";
        console.log(e.target.innerHTML);
        var name = { GameName: e.target.innerHTML };
        //$.post('/User/GameDeatial', name, function (res) {
        //    console.log(res)
        //}, 'json') 

        fetch('/User/GameLibrary', {
            method: 'Post',
            headers: new Headers({
                'Content-Type': 'application/json :charset=UTF-8'
            }),
            body: JSON.stringify(name)
        })
            .then((res) => res.json())
            .then((res) => {
                console.log(res)
                getgamedetail(res)
               

            });
    })
})


function getcard(mediaUrl, gameIntroduction, developer,marker, releaseTime) {
    let clonecard = document.getElementById("getgamecard").content.cloneNode(true);
    //遊戲圖片 
    clonecard.querySelector(".game-img>img").src = mediaUrl;
   
   
    clonecard.querySelector(".gameIntroduction").innerHTML=gameIntroduction;

    //開發者
    clonecard.querySelector(".game-maker>.col-md-8>p").innerHTML = marker;
    //開發商
    clonecard.querySelector(".game-develpoer>.col-md-8>p").innerHTML=developer;
    //上架時間
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

//按鈕動畫
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




    
    
    



