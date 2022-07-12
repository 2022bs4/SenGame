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

//取消購買--尚未完成
function CancelPurchase() {
    let Btn_Cancel = document.querySelector('.Btn_Cancel')
    Btn_Cancel.addEventListener('click', function () {
        CancelFetch()
    })

    async function CancelFetch() {
        const url = 'Shop/RemoveCheckBuy'
        let action = await fetch(url, {method : "Post"})
        let data = await action.json();
    }
}

function Payment() {
    let Btn_Buy = document.querySelector('.Btn_Buy')
    Btn_Buy.addEventListener('click', function () {
        GetPayInformation()
    })

    async function GetPayInformation() {
        const url = '/Shop/Payment'
        let paymentAction = await fetch(url)
        let data = await paymentAction.text();
    }
    //async function Ecpay() {
    //    const url = 'https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5'
    //    let request = new Request(url, {
    //        method  : "Post",
    //        headers : "",
    //        body: JSON.stringify({
                
    //        });
    //    });
    //}
}


