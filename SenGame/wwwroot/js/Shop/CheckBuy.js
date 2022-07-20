let checkbox = document.querySelector('.User-Protocol input')
window.onload = function () {
    $('main').addClass("close-section Check-Buy");
    $('main').removeClass("container-fluid");

    checkbox.addEventListener('click', AgreeBuy)
    Payment()
    CancelPurchase()
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

//取消購買
function CancelPurchase() {
    let Btn_Cancel = document.querySelector('.Btn_Cancel')
    Btn_Cancel.addEventListener('click', function () {
        CancelFetch()
    })

    async function CancelFetch() {
        const url = '/api/Shop/RemoveCheckBuy'
        let action = await fetch(url, {method : "Post"})
        let data = await action.text();
        alert(data)
        Return()
    }
    async function Return() {
         window.location.href = '/Shop/ShoppingCart';
    }
}

function Payment() {
    let Btn_Buy = document.querySelector('.Btn_Buy')
    var data
    Btn_Buy.addEventListener('click', function () {
        GetPayInformation()
    })

    async function GetPayInformation() {
        const url = '/api/Shop/Payment'
        let paymentAction = await fetch(url)
        data = await paymentAction.json();
        console.log(data)
        Ecpay(data);

    }
    function Ecpay(data) {
        let ecpay_form = document.querySelector('.ecpay_form')
        var key = Object.keys(data)
        var value = Object.values(data)

        value.forEach((item) => {
            let input = document.createElement('input')
            input.setAttribute('class', 'ecpay-Information d-none')
            input.value = item
            ecpay_form.append(input)
        })
        let ecpay = document.querySelectorAll('.ecpay-Information')
        key.forEach((item, index) => {
            ecpay[index].name = item
        })
        document.querySelector('.ecpay_form').submit()

    }
}

