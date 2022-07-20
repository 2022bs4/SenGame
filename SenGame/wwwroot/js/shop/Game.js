$(document).ready(function () {
    $('main').addClass("Game")
    Tag()
    TopSwipper()

    PresetList()
    NewReleaese()
})


async function Tag() {
    let box = document.querySelector('.Game-Type')
    const url = '/api/Shop/IndexTag'
    let request = await fetch(url)
    let response = await request.json()
    
    response.forEach(item => {
        TagList(item)
    })

    function TagList(item) {
        let cloneBox = Tag_Template.content.cloneNode(true)
        cloneBox.querySelector('.Parent-Category-Name').innerText = item.parentCategory
        let Subcategory = cloneBox.querySelector('.Subcategory')
        for (let i = 0; i < item.gameTyple.length; i++)
        {
            let a = document.createElement('a')
            a.innerHTML = `<a class="px-2" href="#">${item.gameTyple[i].typleName}</a>`
            Subcategory.append(a)
        }
        box.append(cloneBox)
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
//預設Index Swipper 
async function TopSwipper(){
    const url = '/api/Shop/Index'
    let request = await fetch(url)
    let response = await request.json()
    IndexTemplate(response) 
}

async function NewReleaese() {
    let Filter_Prodeuct = document.querySelectorAll('.Filter-Prodeuct')
    Filter_Prodeuct.forEach(item => {
        item.addEventListener('click', function () {
            SwipperFetch(item.innerText)
            ListFetch(item.innerText)
        })
    })    

    async function SwipperFetch(UserRequest) {
        const url = `/api/Shop/PostIndex`
        let request = new Request(url, {
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                UserRequest : `${UserRequest}`
            })
        })
        let action = await fetch(request);
        let response = await action.json();
        clearSwipper()
        IndexTemplate(response) 
    }


    //下層清單。還在嘗試
    async function ListFetch(UserRequest) {
        const url = '/api/Shop/PostIndexListCard'
        let request = new Request(url, {
            method: "POST",
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                UserRequest: `${UserRequest}`
            })
        })
        let action = await fetch(request)
        let response = await action.json();
        ClearList()
        ProductList(response)
    }

}
//Swipper Node清除清空
function clearSwipper() {
    let first = document.querySelector('.swiper-wrapper')
    let second = document.querySelector('.carousel-inner')
    first.innerHTML= ''
    second.innerHTML = ''
}
//swipper template封裝方法
function IndexTemplate(response) {
    let first = response.firstAreaProduct
    let second = response.secondAreaProduct
    first.forEach(item => {
        Template('.swiper-wrapper', "First_Swipper", `.swiper-slide`, item.gameUrl, item.gameName, item.gamePrice, item.gameId)
    })
    second.forEach(item => {
        Template('.carousel-inner', "Second_Swipper", `.carousel-item`, item.gameUrl, item.gameName, item.gamePrice, item.gameId)
    })
    let box = document.querySelectorAll('.carousel-item')
    box[0].classList.add('active')
    function Template(swipperBox, templateId, boxName, gameUrl, gameName, gamePrice, gameId,) {
        let SwipperBox = document.querySelector(`${swipperBox}`)
        let id = document.getElementById(`${templateId}`)
        let cloneBox = id.content.cloneNode(true)
        let box = cloneBox.querySelector(`${boxName}`)
        cloneBox.querySelector('img').src = `${gameUrl}`
        cloneBox.querySelector('img').alt = `${gameName}`
        cloneBox.querySelector('h2').innerText = `${gameName}`
        cloneBox.querySelector('p').innerText = `售價: NT$ ${gamePrice}`
        SwipperBox.append(cloneBox);
        box.addEventListener('click', function () {
            window.location.href = `/Shop/ProductDetails/${gameId}`
        })
    }
}

async function PresetList() {
    const url = '/api/Shop/IndexList'
    let request = await fetch(url)
    let response = await request.json();
    ProductList(response)
}

function ClearList() {
    let box = document.querySelector('.Game-List')
    box.innerHTML = ""
}

// 控制Id 以及 Get產品順序，以便用來指定post
let i = 0
let j = 0;
let newIdArray = []
//Product List
async function ProductList(url) {
    let GameList = document.querySelector('.Game-List')

    url.forEach((item) => {
        ListData(item)
    });
    let newId = await GetNewIdArray()

    //單一牌卡
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

    //抓取牌卡Id儲存
    function GetNewIdArray() {
        var All_GameList = document.querySelectorAll('.Template-List')
        All_GameList.forEach(item => {
            var id = item.querySelector('input').value
            newIdArray.push(id)
        })
    }

    //下方多圖片和標籤
    ItemDetails()
    async function ItemDetails() {
        let newItemDetailsSort = []
        //指定Id依序請求
        for (let k = 0; k < newIdArray.length; k++)
        {
            const url = '/api/Shop/IndexListDetails'
            let request = new Request(url, {
                method: "Post",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    GameId: `${newIdArray[k]}`
                })
            });
            let action = await fetch(request);
            let response = await action.json();
            //依序push，以便template使用
            newItemDetailsSort.push(response)
        }

        newItemDetailsSort.forEach(item => {
            Details(item)
        })
        //下方多圖片和標籤 Template
        function Details(e) {
            let cloneBox = Template_Data.content.cloneNode(true)
            let box = cloneBox.querySelector('.Template-Data');
            let Listbox = document.querySelectorAll('.Template-List')
            box.setAttribute('id', `b${i}`)
            box.style.top=`-${i*200}px`
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
            Listbox[i].append(cloneBox)
            i++
        }
        //歸零id 以及 post gameId順序
        i = 0;
        j = 0;
        newIdArray = [];
        await Hover()
    }
    //牌卡觸碰效果
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


