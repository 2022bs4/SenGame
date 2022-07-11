let swiperwrapper = document.querySelector(".swiper-wrapper");
let swiper = document.querySelector(".swiper");
let forum = document.querySelector(".community-body-forum");
let article = document.getElementById("article");


$(document).ready(function () {
   /* get();*/
    getimg();
    swiperinitialization();
    swiperappend();
    /*articlesappend()*/
});
function getimg() {
    fetch('/Community/Swipers')
        .then((res) => res.json())
        .then((res) => {
            swiperappend(res)
        })

}
//function get() {
//     fetch('/Community/Articles')
//        .then((res) => res.json())
//        .then((res) => {
//            console.log(res)
//            articlesappend(res)

//        })
//}
   
            

//function articlesappend(articlesarray) { 
//    articlesarray.forEach((item,index )=>{
//        forum.append(Article(item.mediaUrl, item.gameName, item.gameIntroduction));
//    });
//}


//function Article(mediaUrl, gameName, gameIntroduction) {
//    let clonearticle = article.contentEditable.cloneNode(true);
//    clonearticle.querySelector("img").innertext = mediaUrl;
//    clonearticle.querySelector("a").innertext = gameName;
//    clonearticle.querySelector(".forumcard-text").innertext = gameIntroduction;
//}



function swiperinitialization() {
    var mySwiper = new Swiper('.swiper', {
        // 垂直切换选项
        loop: true, // 循环模式选项
        // 如果需要分页器
        pagination: {
            el: '.swiper-pagination',
        },
        // 如果需要前进后退按钮
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        },
        // 如果需要滚动条
        scrollbar: {
            el: '.swiper-scrollbar',
        },
        
    })
    
};
function swiperappend(swiperarray) {
    swiperarray.forEach((item, index) => {
        var div = document.createElement("div");
        div.setAttribute('class', 'swiper-slide')
        var img = document.createElement("img");
        img.src = item.mediaUrl;
        div.append(img);
        swiperwrapper.append(div);
        swiper.append(swiperwrapper);

    });
}
        
      




//const swiperarray = [{ photo: "https://steamuserimages-a.akamaihd.net/ugc/1836918544286703101/BB1A62A3502E68F0C920933579F5AD65D4F2E23A/?imw=1920&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
//{ photo: "https://steamuserimages-a.akamaihd.net/ugc/1857184853121547261/3955A809798ECDB1D07D2059E784DA9562D085FB/?imw=1920&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
//{ photo: "https://steamuserimages-a.akamaihd.net/ugc/1845925743534822061/97E7D475F8E26320AB2D311B253CDBEE0428E521/?imw=1920&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
//{ photo: "https://steamuserimages-a.akamaihd.net/ugc/1838044444099103694/323B7B633B3E4E20700E45D6E06DD5C28028F8CF/?imw=1920&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
//{ photo: "https://steamuserimages-a.akamaihd.net/ugc/1824533645264654083/41AA85486767DD5FE0E15BCE4CF56596A706AA4C/?imw=1920&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
//{ photo: "https://steamuserimages-a.akamaihd.net/ugc/1860562440360410254/7E5BC4C102CB89A6FB2610B737C2FFF7EB961DAB/?imw=1920&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
//{ photo: "https://steamuserimages-a.akamaihd.net/ugc/1834666744428982968/A0447F8BE76701B6F68427D46FF7ACC0B711BB56/?imw=1920&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },];