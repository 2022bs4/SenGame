let checkbox = document.querySelector('.User-Protocol input')
window.onload = function () {
    $('main').addClass("close-section Check-Buy");
    $('main').removeClass("container-fluid");

    checkbox.addEventListener('click', AgreeBuy)
}



//判別沒有勾選同意不能購買
function AgreeBuy() {
    if (checkbox.checked == true) {
        $('.Btn_Buy').removeAttr("disabled")
        $('.Btn_Buy').css("cursor", "pointer")
    }
    else {
        $('.Btn_Buy').attr("disabled", "disabled")
        $('.Btn_Buy').css("cursor", "default")
    }
}
