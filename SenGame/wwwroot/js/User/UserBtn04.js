
//$(document).ready(function () {
    
//})

//編輯畫面4 改變隱私狀態
function ChangePrivacie() {
    Swal.fire({
        position: 'top',
        icon: 'success',
        title: '已送出好友請求',
        showConfirmButton: false,
        timer: 1500
    })
}
let sumbit = document.querySelector('.post_btn')
let list = document.querySelector('.list')

function submitValue() {
 
    //可以抓到選公開的時候可以是1，僅限好友是2
    list.addEventListener('change', function () {
        var option = this.options[this.selectedIndex];
        $(`.list`).attr("value", `${option.value}`) 
    })

    
}

sumbit.addEventListener("click", function () {
    test()
})
async function test() {
    const url = '/User/Post_E4_UserPrivacy'
    let request = new Request(url, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            UserPrivacyId: `${list.value}`
        })
    })
    let action = await fetch(request)
    let data = await action.json()
}






