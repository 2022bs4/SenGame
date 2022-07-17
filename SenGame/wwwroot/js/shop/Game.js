$(document).ready(function () {
    Tag()


    $('main').addClass("Game")

    TopSwipper()
    ProductList()


})
let i = 0
let j = 0;
let newIdArray = []

async function Tag() {
    let box = document.querySelector('.Game-Type')
    const url = '/api/Shop/IndexTag'
    let request = await fetch(url)
    let response = await request.json()
    console.log(response)
    debugger
    response.forEach(item => {
        TagList(item)
    }

    async function TagList(item)
        let cloneBox = Tag_Template.content.cloneNode(true)
        let ul = c
    }


}


//swipper(官網)
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
    //swipper template封裝方法
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

//Product List
async function ProductList() {
    let GameList = document.querySelector('.Game-List')
    const url = '/api/Shop/IndexList'
    let request = await fetch(url)
    let response = await request.json(); 
    response.forEach((item) => {
        ListData(item)
    });

    let newId = await GetNewIdArray()
    
    function ListData(item) {
        let cloneBox = Template_List.content.cloneNode(true);
        let box = cloneBox.querySelector('.Template-List');
        cloneBox.querySelector('input').value = item.gameId;
        box.setAttribute("id", `a${j}`)
        j++

        cloneBox.querySelector('img').src = item.gameIndexPicture;
        cloneBox.querySelector('img').alt = item.gameName;
        cloneBox.querySelector('h2').innerText = item.gameName;
        cloneBox.querySelector('p').innerText = `售價: NT$ ${item.gamePrice}`
        box.addEventListener('click', function () {
            window.location.href = `/Shop/ProductDetails/${item.gameId}`
        })
        GameList.append(cloneBox)
    }

    function GetNewIdArray() {
        var All_GameList = document.querySelectorAll('.Template-List')
        All_GameList.forEach(item => {
            var id = item.querySelector('input').value
            newIdArray.push(id)
        })
    }

    ItemDetails()
    async function ItemDetails() {
        let newItemDetailsSort = []
        let GameData = document.querySelector('.Game-Data')
        const url = '/api/Shop/IndexListDetails'

        for (let k = 0; k < newIdArray.length; k++)
        {
            let request = new Request(url, {
                method: "Post",
                headers: { 'Content-Type': 'application/json', },
                body: JSON.stringify({
                    GameId: `${newIdArray[k]}`,
                })
            });
            let action = await fetch(request);
            let response = await action.json();
            newItemDetailsSort.push(response)
        }

        newItemDetailsSort.forEach(item => { Details(item)})
        function Details(e) {
            let cloneBox = Template_Data.content.cloneNode(true)
            let box = cloneBox.querySelector('.Template-Data');
            box.setAttribute('id', `b${i}`)
            i++
            cloneBox.querySelector('h2').innerText = e.gameName
            let ul = cloneBox.querySelector('ul')
            let tag = e.typeData
            let pic = e.gameUrl
            tag.forEach(item => {
                let li = document.createElement('li')
                li.innerHTML = `<a href="#" class="m-1">${item.typleName}<a/>`
                ul.append(li)
            })
            pic.forEach(item => {
                let div = document.createElement('div')
                div.innerHTML = `<img src="${item.url}"alt="${e.gameName}" class="w-100 py-3">`
                box.append(div)
            })
            GameData.append(cloneBox)
        }
    }

    setTimeout(function () {
        Hover()
    }, 3000)

    function Hover() {
        for (let i = 0; i < 5; i++) {
            let a = document.getElementById(`a${i}`)
            let b = document.getElementById(`b${i}`)
            a.addEventListener('mouseover', function () {
                b.classList.remove('d-none')
            })
            a.addEventListener('mouseout', function () {
                b.classList.add('d-none')
            })
        }
    }
}
