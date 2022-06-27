Featured()

TempForeChoese()


function Featured() {
    var FeaturedWrapper = document.querySelector('#featured-wrapper');
    var temp = FeaturedWrapper.getElementsByTagName("template")[0];

    for (i = 0; i < 5; i++) {
        var clon = temp.content.cloneNode(true)

        FeaturedWrapper.appendChild(clon)
    }
    var featuredSwiper = new Swiper(".featured", {
        slidesPerView: 1,
        loop: true,

        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },

    });


}
function TempForeChoese() {
    var tabNew = document.querySelector('.tab-new');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }

    var tabNew = document.querySelector('.tab-bestSell');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }

    var tabNew = document.querySelector('.tab-hotBePost');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }

    var tabNew = document.querySelector('.tab-specialDiscount');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }
    var specialOffer = document.querySelector('.special-offer');
    var temp = specialOffer.getElementsByTagName("template")[0];
    for (i = 0; i < 6; i++) {
        var clon = temp.content.cloneNode(true)
        specialOffer.appendChild(clon)
    }
}