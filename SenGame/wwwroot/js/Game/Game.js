


$(document).ready(function () {
    $('main').addClass("Game")
})
GameTemplate()
//swipper
var swiper = new Swiper(".mySwiper", {
    effect: "coverflow",
    grabCursor: true,
    centeredSlides: true,
    slidesPerView: "auto",
    coverflowEffect: {
        rotate: 30,
        stretch: 0,
        depth: 100,
        modifier: 1.5,
        slideShadows: true,
    },
    pagination: {
        el: ".swiper-pagination",
    },
});


function GameTemplate() {
    let GameListArea = document.querySelector('.Game-List-Area')
    let GameList = document.querySelector('.Game-List')
    let GameData = document.querySelector('.Game-Data')
    for (let i = 0; i < 6; i++) {
        TemplateGameList()
        TemplateGameData()
    }
    function TemplateGameList() {
        let ListClone = Template_List.content.cloneNode(true)
        GameList.append(ListClone);
    }
    function TemplateGameData() {
        let DataClone = Template_Data.content.cloneNode(true)
        GameData.append(DataClone)
    }
}

