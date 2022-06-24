window.onload = function () {
    Setnavbar("main");
}
//全域
let searchbtn = document.querySelector(".search-form-btn");
let submit = document.querySelector(".search-form-btn-submit")
let hiddenbtn = document.querySelector(".header-box-nav-content-collapse");
let sidenavbar = document.querySelector(".header-box-nav-content");
let logo = document.querySelector(".logo");
let sidenavbaropen = document.querySelector(".sidebar-toggler");
let main = document.querySelector("main");
let navbcg = document.querySelector(".header-box-nav");

//傳入內容區塊做畫面效果
//傳入內容區塊做畫面效果
function Setnavbar(content) {
    Addtoggle();//添加選單開關
    AddNavClick();//添加選單的click效果

    function Addtoggle() {
        const toggler = document.querySelector('.nav-toggler');
        const navbar = document.querySelector('.header-box');
        toggler.addEventListener("click", () => {
            navbar.classList.toggle("open");
            document.querySelector(content).classList.toggle("open-section");
            navbcg.classList.toggle("MainScreen");
            

        })
    }
    function AddNavClick() {
        const list = document.querySelectorAll('.header-box-nav-content-tours>li');
        function ActiveLink() {
            for (var item of list) {
                item.classList.remove("active");
                this.classList.add("active");
            }
        }
        for (var item of list) {
            item.addEventListener("click", ActiveLink);
        }
    }
}
//input點擊後射出來
searchbtn.addEventListener('click',function(){
    document.querySelector(".form-control").classList.toggle("form-control-open")
    searchbtn.style = "display:none"
    submit.style = "display:block"
    logo.classList.toggle("logomove")
});
submit.addEventListener('click',function(){
    document.querySelector(".form-control").classList.toggle("form-control-open")
    searchbtn.style = "display:block"
    submit.style = "display:none"
    logo.classList.toggle("logomove")
});

//隱藏左邊導覽列
hiddenbtn.addEventListener('click',function(){
    navbcg.classList.toggle("closenav");
    main.classList.toggle("MainScreen");
    document.querySelector(".nav-toggler").style = "display:none";
    sidenavbaropen.style="display:flex";
});
//讓左邊導覽列顯示出來
sidenavbaropen.addEventListener('click',function(){
    navbcg.classList.toggle("closenav");
    main.classList.toggle("MainScreen");
    sidenavbaropen.style="visibility: hidden;";
    document.querySelector(".nav-toggler").style = "display:flex";
});


