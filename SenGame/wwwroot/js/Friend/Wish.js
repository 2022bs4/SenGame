const draggable_list = document.getElementById('sortable');

const wishlist_data = [
    ['7', './images0/0s.jpg', '1 Half-Life: Alyx', '壓倒性好評', '2020 年 3 月 24 日', '858', ['虛擬實境', '第一人稱射擊', '劇情豐富', '恐怖女主人翁']],
    ['2', './images1/0s.jpg', '2 FINAL FANTASY VII REMAKE INTERGRADE', '極度好評', '6 月 17 日', '1,990', ['角色扮演', '動作冒險', '劇情豐富', '動作角色扮演']],
    ['3', './images2/0s.jpg', "3 DEATH STRANDING DIRECTOR'S CUT", '極度好評', '3 月 30 日', '1,190', ['動作', '步行模擬', '劇情豐富', '開放世界']]
]

const listItems = [];

createList();

function createList() {
    [...wishlist_data]
        .map(a => ({ value: a, sort: a[0] }))
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
                            <img src="${item[1]}" class = "wishlist__img">
                        </a>
                        
                        <div class="wishlish__text row">
                            <a href="#" class="col-12">
                                <h2>${item[2]}</h2>
                            </a>
                            <div class="product_details col-8">
                                <div class="row">
                                    <p class="col-4">整體評論:</p>
                                    <p class="col-8">${item[3]}</p>
                                </div>
                                <div class="row">
                                    <p class="col-4">發行日期:</p>
                                    <p class="col-8">${item[4]}</p>
                                </div>
                            </div>
                            <div class="buy_btn col-4 row">
                                <p class="col-5">NT$ ${item[5]}</p>
                                <button type="button" class="btn btn-success col-6">加入購物車</button>
                            </div>
                            <div class="bottom col-12">
                                <ul>
                                    <button type="button" class="btn btn-outline-secondary">${item[6][0]}</button>
                                    <button type="button" class="btn btn-outline-secondary">${item[6][1]}</button>
                                    <button type="button" class="btn btn-outline-secondary">${item[6][2]}</button>
                                    <button type="button" class="btn btn-outline-secondary">${item[6][3]}</button>
                                </ul>
                                <p>新增於 2022/6/30（移除）</p>
                            </div>
                            
                        </div>
                    </div>
            `;

            listItems.push(listItem);

            draggable_list.appendChild(listItem);



        });
}

const dragArea = document.querySelector(".wishlist")

new Sortable(dragArea, {
    animation: 350,
    handle: ".movable", //只能點 可移動圖示區域 才能移動
    axis: "y",     //只能垂直拖移
});



var image = new Image();
image.src = ''; //不設定任何拖曳圖片
document.addEventListener('dragstart', function (event) {
    // 設置拖曳圖片，預設為半透明
    event.dataTransfer.setDragImage(image, 10, 10);
});

const order_input = document.querySelector(".order_input");
// :not(.order_input)
function mouseDown() {
    order_input.style.display = "none";
}

function mouseUp() {
    order_input.style.display = "block";
}

//投影片區域

//全域
let slideIndex = 1;
const wishlist__img = document.querySelectorAll(".wishlist__img");

// 用迴圈是為了抓到滑鼠選到的圖片index
for (let i = 0; i < wishlist__img.length; i++) {
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