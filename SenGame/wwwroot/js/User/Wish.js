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