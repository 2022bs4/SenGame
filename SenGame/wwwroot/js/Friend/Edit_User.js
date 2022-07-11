
//使用者主頁，加好友
function Userinformation() {
    var addbtn = document.getElementById("AddFriendBtn");
    var cancelbtn = document.getElementById("CancelFriendBtn");
    addbtn.onclick = function () {
        if (cancelbtn.style.display == "none") {
            cancelbtn.style.display = "block";
            addbtn.value = "取消加好友Q";
            Swal.fire({
                position: 'top',
                icon: 'success',
                title: '已送出好友請求',
                showConfirmButton: false,
                timer: 1500
            })
        }
        else {
            cancelbtn.style.display = "none";
            addbtn.value = "加好友 NOW";
            Swal.fire({
                position: 'top',
                icon: 'error',
                title: '取消加好友Q',
                showConfirmButton: false,
                timer: 1500
            })
        }
    }
}

//編輯畫面1 關閉編輯以及取消編輯以及儲存編輯
function ChangeDisabled(value) {
    var EditInput05 = document.getElementById('EditInput01');
    var EditInput05 = document.getElementById('EditInput02');
    var EditInput05 = document.getElementById('EditInput03');
    var EditInput05 = document.getElementById('EditInput04');
    var EditInput05 = document.getElementById('EditInput05');
    if (value == '1') {
        EditInput01.disabled = false;　// 變更欄位為可用
        EditInput02.disabled = false;
        EditInput03.disabled = false;
        EditInput04.disabled = false;
        EditInput05.disabled = false;

    } else {
        if (value == '2') {
            Swal.fire({
                position: 'top',
                icon: 'error',
                title: '取消編輯',
                showConfirmButton: false,
                timer: 1500
            })
            EditInput01.disabled = true;　// 變更欄位為可用
            EditInput02.disabled = true;
            EditInput03.disabled = true;
            EditInput04.disabled = true;
            EditInput05.disabled = true;
        }
        else {
            EditInput01.disabled = true;　// 變更欄位為禁用
            EditInput02.disabled = true;
            EditInput03.disabled = true;
            EditInput04.disabled = true;
            EditInput05.disabled = true;
            Swal.fire({
                position: 'top',
                icon: 'success',
                title: '確認修改送出',
                showConfirmButton: false,
                timer: 1500
            })
        }

    }
}

//編輯畫面2 取消上傳 上傳成功通知
function ConfirmRpload() {
    Swal.fire({
        title: '確定設這張照片為大頭貼嗎?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: '確定',
        denyButtonText: `取消上傳`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            Swal.fire('上傳成功!', '', 'success')
        } else if (result.isDenied) {
            Swal.fire('已取消上傳!', clean(), 'info')
        }
    })
}

function clean() {
    Swal.fire('已取消上傳!', '', 'info')
    // var dataURL = reader.result;
    // $('#output').attr('src', dataURL);; //清空 Edit2-PhotoBox
    document.getElementById("output").src = '';
}

//編輯畫面3 改變背景顏色
function color(str) {
    document.body.style.backgroundImage = str;
    document.getElementById('card-Edit_User').style.backgroundImage = str;
}