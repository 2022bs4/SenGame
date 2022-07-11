const draggable_list = document.getElementById('sortable');

const wishlist_data = [
    ['7', './images0/0s.jpg', '1 Half-Life: Alyx', '壓倒性好評', '2020 年 3 月 24 日', ['虛擬實境', '第一人稱射擊', '劇情豐富', '恐怖女主人翁']],
    ['2', './images1/0s.jpg', '2 FINAL FANTASY VII REMAKE INTERGRADE', '極度好評', '6 月 17 日', ['角色扮演', '動作冒險', '劇情豐富', '動作角色扮演']],
    ['3', './images2/0s.jpg', "3 DEATH STRANDING DIRECTOR'S CUT", '極度好評', '3 月 30 日', ['動作', '步行模擬', '劇情豐富', '開放世界']]
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
                    <div id="movable">
                        <i class="fa-solid fa-sort"></i>
                        <div class="order">
                            <input class="order_input bg-dark text-white" type="text" value="${index + 1}">
                        </div>
                    </div>
                    <div class="line"></div>
                    <div class="wishlist__content">
                        <a href="#">
                            <img src="${item[1]}" class = "wishlist__img">
                        </a>
                        
                        <div class="wishlish__text">
                            <a href="#">
                                <h2>${item[2]}</h2>
                            </a>
                            <p>整體評論:${item[3]}</p>
                            <p>發行日期:${item[4]}</p>
                            <button type="button" class="btn btn-outline-secondary">${item[5][0]}</button>
                            <button type="button" class="btn btn-outline-secondary">${item[5][1]}</button>
                            <button type="button" class="btn btn-outline-secondary">${item[5][2]}</button>
                            <button type="button" class="btn btn-outline-secondary">${item[5][3]}</button>
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
    handle: ".wishlist", //只能點 可移動圖示區域 才能移動
    axis: "y",     //只能垂直拖移
});

var image = new Image();
image.src = ''; //不設定任何拖曳圖片
document.addEventListener('dragstart', function (event) {
    // 設置拖曳圖片，預設為半透明
    event.dataTransfer.setDragImage(image, 10, 10);
});

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