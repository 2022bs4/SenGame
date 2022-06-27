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

var SpecialDiscountSwiper = new Swiper(".SpecialDiscount", {
    slidesPerView: 1,
    spaceBetween: 10,
    loop: true,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    breakpoints: {
        768: {
            slidesPerView: 2,
            spaceBetween: 20,
        },
        1200: {
            slidesPerView: 3,
            spaceBetween: 40,
        },
        1440: {
            slidesPerView: 4,
            spaceBetween: 50,
        },
    },
});

var popVRGameSwiper = new Swiper(".popVRGame", {
    slidesPerView: 2,
    spaceBetween: 10,
    loop: true,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    breakpoints: {
        768: {
            slidesPerView: 3,
            spaceBetween: 20,
        },

        1200: {
            slidesPerView: 4,
            spaceBetween: 40,
        },
    },
});

var lossThenThreeHSwiper = new Swiper(".lossThenThreeH", {
    slidesPerView: 2,
    spaceBetween: 10,
    loop: true,
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    breakpoints: {
        768: {
            slidesPerView: 3,
            spaceBetween: 20,
        },

        1200: {
            slidesPerView: 4,
            spaceBetween: 40,
        },
    },
});