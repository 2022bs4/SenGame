console.log(document.cookie);
var btn1 = document.querySelector('.row-large-btn');
btn1.addEventListener('click', function () {
    ChangeRow("row-large");
    document.cookie = 'cookie3=value3';
})
var btn2 = document.querySelector('.row-cells-btn');
btn2.addEventListener('click', function () {
    ChangeRow("row-cells");
})
var btn3 = document.querySelector('.row-list-btn');
btn3.addEventListener('click', function () {
    ChangeRow("row-list");
})

function ChangeRow(css){
    var main = document.querySelector('main>article');
    main.setAttribute("class", "");
    main.classList.add(css);
}

