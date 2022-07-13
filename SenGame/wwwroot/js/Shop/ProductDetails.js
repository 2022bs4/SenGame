let gameId;



$(document).ready(function () {
    gameId = document.getElementById('GameId');
    $('main').addClass("CommodityDetials close-section");
    $('main').removeClass("container-fluid");
    GameSwipper();
    MianDetails();
    ProductSystem();
    BtnFunction();
    //CloneGame()
})


//添加購物車、願望清單
function BtnFunction() {
    let btn_Add = document.querySelector('.AddItem');
    let btn_Wish = document.querySelector('.Wish');

    //加入購物車fetch post
    btn_Add.addEventListener('click', function () {
        AddCartFetch()    
    })

    async function AddCartFetch() {
        const url = '/api/Shop/AddShoppingCart';
        let request = new Request(url, {
            method: "POST",
            headers: new Headers({
                'Content-Type': 'application/json',
                //"Accept": "application/json",
            }),
            body: JSON.stringify({
                GameId: `${gameId.value}`,
                Success: "",
            })
        })
        let fetchAction = await fetch(request)
        let data = await fetchAction.json()
        var response = data.success;
        alert(response);
    }
    //btn_Wish.addEventListener('click', function () {
    //})

}


// 以下為幻燈片動態
function GameSwipper() {
    const swipper = `/api/Shop/ProductSwipper?id=${gameId.value}`;
    fetch(swipper, {method:"GET"})
        .then(response => response.json())
        .then(result => {
            setSliders(result);
            InitializeSwiper();
        })
    let mainphoto, thumbs
    function setSliders(namesArray) {
        mainphoto = $("#mainphoto");
        thumbs = $("#thumbs")
        namesArray.forEach((item, index) => {
            let slideDiv = $("<div></div>")
            slideDiv.addClass("swiper-slide")
            let img = $("<img>");
            img.attr("src", `${item.swipperUrl}`)
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
function MianDetails() {
    const url = `/api/Shop/ProductMain?id=${gameId.value}`
    fetch(url)
        .then(response => response.json())
        .then(result => {
            result.forEach((item) => {
                CloneGame(item)
            })
        })
        .then(end => {
            setTimeout(RecommendTemplate(), 3000);
        });

    function CloneGame(Array) {
        let GameDatails = document.querySelector('.Game-Datails')
        let GameClone = GamePictureText.content.cloneNode(true)
        GameClone.querySelector('p').innerHTML = Array.gameDetailsText
        GameDatails.append(GameClone);

    }
}

//系統區域
function ProductSystem() {
    const systemAction = `/api/Shop/ProductSystem?id=${gameId.value}`
    fetch(systemAction,)
        .then(response => response.json())
        .then(result => {
            result.forEach(item => {
                SystemTemplate(item);
            })
            ProductSystemtoggle();
        })
    function SystemTemplate(result) {
        if (result.systemType == 2)
        {
            $('.btn-Mac').removeClass('d-none')
        }
        else if (result.systemType == 1) {
            $('.btn-Mac').addClass('d-none')
        }
        let cnfigureBox = document.querySelector(".Cnfigure-Box");
        let systemTemplate = GameSystem.content.cloneNode(true);
        let systemBox = systemTemplate.querySelector('.System-box')
        if (result.systemType == 2) {
            systemBox.setAttribute("class", "System-box Mac System_Transform col-md-6 pl-md-5")
        }
        let systemSuggest = systemTemplate.querySelector('span')
        let li = systemTemplate.querySelectorAll('li');
        if (result.configue = 1) {
            systemSuggest.innerHTML = "最低配置";
        }
        else {
            systemSuggest.innerHTML = "建議配置";
        }
        li[0].innerHTML = `作業系統 : ${result.system}`
        li[1].innerHTML = `處理器 : ${result.systemCpu}`
        li[2].innerHTML = `記憶體 : ${result.systemRam}`
        li[3].innerHTML = `顯示卡 : ${result.systemGpu}`
        li[4].innerHTML = `儲存空間 : ${result.hddspace}`
        cnfigureBox .append(systemTemplate);
        return systemTemplate
    }
    function ProductSystemtoggle() {
        $('.btn-Mac').click(function () {
            $('.Windows').addClass('System_Transform')
            $('.Mac').removeClass('System_Transform')
        })
        $('.btn-Window').click(function () {
            $('.Windows').removeClass('System_Transform')
            $('.Mac').addClass('System_Transform')
        })
    }
}

//推薦Template
function RecommendTemplate() {
    const ProductRecommend = "/api/Shop/ProductRecommend"
    let box = document.querySelector('.Recommend')
    var GameDatails = document.querySelector(".Game-Datails")
    let screenWidth = screen.width;
    fetch(ProductRecommend,)
        .then(response => response.json())
        .then(result => {
            if (GameDatails.getBoundingClientRect().height < 500) {
                result = result.slice(0, 1);
            }
            else if (GameDatails.getBoundingClientRect().height < 1200) {
                result = result.slice(0, 2);
            }
            else if (GameDatails.getBoundingClientRect().height < 1400) {
                result = result.slice(0, 3);
            }
            else {
                result = result;
            }
            if (screenWidth < 768) {
                result = result.slice(0, 2);
            }
            result.forEach(item => {
                let boxClone = Shopping_Recommend.content.cloneNode(true)
                boxClone.querySelector('img').src = `${item.productUrl}`
                boxClone.querySelector('img').alt = `${item.productName}`
                boxClone.querySelector('a').href =`/Shop/ProductDetails/${item.gameId}`
                boxClone.querySelector('.Recommend-Price').innerHTML = `${item.productName} <br/> 售價: NT$${item.productPrice}`
                box.append(boxClone)
            })
        })
}

//廣告清除
function adClear() {
    $('.Video-Clear').click(function () {
        $('.Video-Area').hide()
    })
}





