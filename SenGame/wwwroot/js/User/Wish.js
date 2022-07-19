const draggable_list = document.getElementById('sortable');
const listItems = [];
const url = "/fetch.json";

//ID大小排序並且迭代的願望清單'S
const wishLists = (lists) => {
    lists.map(a => ({ value: a, sort: a.WishId }))
        .sort((a, b) => a.sort - b.sort)  //按資料庫大小排列
        .map(a => a.value)
        .forEach((item, index) => {
            console.log(item)
            const listItem = document.createElement('li');
            listItem.innerHTML = `
            <div id="movable" class="movable">
                <div>
                    <i class="fa-solid fa-sort"></i>
                    <div class="order">
                        <input class="order_input text-white" type="text" value="${index + 1}">
                    </div>
                </div>
                </div>
                <div class="line"></div>
                <div class="wishlist__content">
                <a href="#">
                    <img src="${item.GameSlides}" class = "wishlist__img">
                </a>

                <div class="wishlish__text row">
                    <a href="#" class="col-12">
                        <h2>${item.GameName}</h2>
                    </a>
                    <div class="product_details col-8">
                        <div class="row">
                            <p class="col-4">發行日期:</p>
                            <p class="col-8">${item.ReleaseTime}</p>
                        </div>
                    </div>
                    <div class="buy_btn col-4 row">
                        <p class="col-5">NT$ ${item.GamePrice}</p>
                        <button type="button" class="btn btn-success col-6">加入購物車</button>
                    </div>
                    <div class="bottom col-12" data-id=${item.WishId}>
                        <ul>
                            <a type="button" class="btn btn-outline-secondary">${item.Typelist[0]}</a>
                            <a type="button" class="btn btn-outline-secondary">${item.Typelist[1]}</a>
                            <a type="button" class="btn btn-outline-secondary">${item.Typelist[2]}</a>
                            <a type="button" class="btn btn-outline-secondary">${item.Typelist[3]}</a>
                        </ul>
                        <p>新增於 ${item.AddTime}<a href="#" class="card-link" id="delete_btn">（移除）</a></p>
                    </div>
                    
                </div>
            </div>
        `;
            listItems.push(listItem);
            draggable_list.appendChild(listItem);
        });
}

//Read
fetch(url)
    .then(res => res.json())
    .then(data => wishLists(data))

draggable_list.addEventListener('click', (e) => {
    e.preventDefault();
    let delete_btnIsPressed = e.target.id == 'delete_btn';

    let id = e.target.parentElement.dataset.id;
    console.log(id); //測試抓到id是否

    //Delete
    if (delete_btnIsPressed) {
        fetch(`${url}/${id}`, {
            method: 'DELETE'
        })
            .then(res => res.json())
            .then(() => location.reload())
    }
})


//drag and drop API 設置可移動元素
const dragArea = document.querySelector(".wishlist")

new Sortable(dragArea, {
    animation: 350,
    handle: ".movable",
    axis: "y"
});


//將預設拖曳圖片半透明效果去除
var image = new Image();

image.src = '';
document.addEventListener('dragstart', function (event) {
    event.dataTransfer.setDragImage(image, 10, 10);
});

//滑鼠移入移出方法，預設圖片切換投影片的設置
const order_input = document.querySelector(".order_input");
function mouseDown() {
    order_input.style.display = "none";
}

function mouseUp() {
    order_input.style.display = "block";
}

//滑鼠移入移出事件，投影片的播印與否
let slideIndex = 1;
const wishlist__img = document.querySelectorAll(".wishlist__img");

for (let i = 0; i < wishlist__img.length; i++) {  // 利用迴圈抓到滑鼠選到的圖片index
    wishlist__img[i].addEventListener('mouseover',
        function changeSlides() {
            wishlist__img[i].src = "./images" + (i) + "/" + slideIndex + "s.jpg";
            slideIndex++;
            if (slideIndex > 4) { slideIndex = 1 }
            timer = setTimeout(changeSlides, 1000); // Change image every 1 seconds
        })
    wishlist__img[i].addEventListener('mouseout',
        function stopSlides() {
            clearTimeout(timer);
            wishlist__img[i].src = "./images" + (i) + "/0s.jpg";
        })
}