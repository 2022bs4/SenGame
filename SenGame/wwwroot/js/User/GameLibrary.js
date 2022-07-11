//§Ô³N
var gamebutton = document.querySelector(".drop-button");
var ul = document.querySelector(".drop");
var gamebutton = document.querySelector('.button');
var gamebutton2 = document.querySelector('.zxc');


$(document).ready(function () {
    
});

function buttoneffect(button) {
    var duration = 0.3,
        delay = 0.08;
    TweenMax.to(button, duration, { scaleY: 1.6, ease: Expo.easeOut });
    TweenMax.to(button, duration, { scaleX: 1.2, scaleY: 1, ease: Back.easeOut, easeParams: [3], delay: delay });
    TweenMax.to(button, duration * 1.25, { scaleX: 1, scaleY: 1, ease: Back.easeOut, easeParams: [6], delay: delay * 3 });
}

gamebutton.addEventListener('click', function () {
    buttoneffect(gamebutton)
    window.open("https://cdn.cloudflare.steamstatic.com/client/installer/SteamSetup.exe")
});
gamebutton2.addEventListener('click', function () {
    buttoneffect(gamebutton2)

});



//function Swiper() {
    
//}
var swiper = new Swiper(".mySwiper", {
    slidesPerView: "auto",
    spaceBetween: 30,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    observer: true,
});



