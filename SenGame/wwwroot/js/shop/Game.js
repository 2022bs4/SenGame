
$(document).ready(function () {
    $('main').addClass("Game")
    TopSwipper()
    //測試
    fetch('/api/Shop/IndexList')
})

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
//Index Swipper
async function TopSwipper(){
    const url = '/api/Shop/Index'
    let request = await fetch(url)
    let response = await request.json()
    let first = response.firstAreaProduct

    let second = response.secondAreaProduct
    first.forEach(item => {
        Template('.swiper-wrapper',"First_Swipper", `.swiper-slide`, item.gameUrl, item.gameName, item.gamePrice, item.gameId)
    })
    second.forEach(item => {
        Template('.carousel-inner',"Second_Swipper", `.carousel-item`, item.gameUrl, item.gameName, item.gamePrice, item.gameId)
    })
    let box = document.querySelectorAll('.carousel-item')
    box[0].classList.add('active')

    function Template(swipperBox,templateId, boxName, gameUrl, gameName, gamePrice, gameId,) {
        let SwipperBox = document.querySelector(`${swipperBox}`)
        let id = document.getElementById(`${templateId}`)
        let cloneBox = id.content.cloneNode(true)
        let box = cloneBox.querySelector(`${boxName}`)
        cloneBox.querySelector('img').src = `${gameUrl}`
        cloneBox.querySelector('img').alt = `${gameName}`
        cloneBox.querySelector('h2').innerText = `${gameName}`
        cloneBox.querySelector('p').innerText = `售價: NT$ ${gamePrice }`
        SwipperBox.append(cloneBox);
        box.addEventListener('click', function () {
            window.location.href = `/Shop/ProductDetails/${gameId}`
        })
    }
}










GameTemplate()



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

