
//$(document).ready(function () {
    
//})

//編輯畫面4 改變隱私狀態
//function ChangePrivacie() {
//    Swal.fire({
//        position: 'top',
//        icon: 'success',
//        title: '已送出好友請求',
//        showConfirmButton: false,
//        timer: 1500
//    })
//}

let sumbit = document.querySelector('.post_btn')

let list1 = document.querySelector('.list1')
let list2 = document.querySelector('.list2')
let list3 = document.querySelector('.list3')
submitValue()
function submitValue() {


    //可以抓到選公開的時候可以是1，僅限好友是2
    list1.addEventListener('change', function () {
        var option = this.options[this.selectedIndex];
        $(`.list1`).attr("value", `${option.value}`) 
    })
    list2.addEventListener('change', function () {
        var option = this.options[this.selectedIndex];
        $(`.list2`).attr("value", `${option.value}`)
    })
    list3.addEventListener('change', function () {
        var option = this.options[this.selectedIndex];
        $(`.list3`).attr("value", `${option.value}`)
    })
}

//我的個人檔案隱私
sumbit.addEventListener("click", function () {
    prypersonalFile()
})

async function prypersonalFile() {
    const url = '/User/Post_E4_UserPrivacy'
    let request1 = new Request(url, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            UserPriPersonal: `${list1.value}`,
            Userprygame: `${list2.value}`,
            UserFriendList: `${list3.value}`,
        })
    })
    let action = await fetch(request1)
    let data = await action.json()
    console.log(data)
    if (data.message == "您的隱私設定已更改成功") {
        Swal.fire(data.message, '', 'success')
    }
    else {
        Swal.fire(data.message, '', 'error')
    }
    
}

////遊戲資料隱私
//sumbit.addEventListener("click", function () {
//    prygameFile()
//})
//async function prygameFile() {
//    const url = '/User/Post_E4_UserPrivacy'
//    let request2 = new Request(url, {
//        method: "POST",
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify({
//            UserPrivacyId: `${list2.value}`
//        })
//    })
//    let action = await fetch(request2)
//    let data = await action.json()
//}

////好友隱私設定
//sumbit.addEventListener("click", function () {
//    test()
//})
//async function test() {
//    const url = '/User/Post_E4_UserPrivacy'
//    let request = new Request(url, {
//        method: "POST",
//        headers: { 'Content-Type': 'application/json' },
//        body: JSON.stringify({
//            UserPrivacyId: `${list.value}`
//        })
//    })
//    let action = await fetch(request)
//    let data = await action.json()
//}






