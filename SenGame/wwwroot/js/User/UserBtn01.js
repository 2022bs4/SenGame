
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

//初始按鈕
let sumbit = document.querySelector('.E1post_btn')
//最終按鈕
let testsumbit = document.querySelector('Test_E1post_btn')

//個人檔案名稱
let UserName = document.querySelector('.E1_UserName')
//密碼
let password = document.querySelector('.E1_password')
//國家/地區
let country = document.querySelector('.E1_list1')
//關於我
let UserAbout = document.querySelector('.E1_UserAbout')

E1_submitValue()
function E1_submitValue() {

    //先抓國家的東東
    country.addEventListener('change', function () {
        var option = this.options[this.selectedIndex];
        $(`.E1_list1`).attr("value", `${option.value}`)
    })
}
//使用者編輯
sumbit.addEventListener("click", function () {
    EditUserFile()
})
//fetch寫法
async function EditUserFile() {
    const url = '/User/E1_User'
    let E1_request = new Request(url, {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            UserCountry: `${country.value}`
        })

    })
}




//抓取使用者輸入的個人檔案名稱
//const getValueInput = () => {
//    let inputValue = UserName.value;
//    InputUserName.innerHTML = inputValue;
//}

