let email = document.getElementById("email")
let forgetbtn = document.querySelector(".forget-btn")
let emailRule = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/;
forgetbtn.addEventListener('click', function () {
    if (email.value == '') {
        email.style.border = '2px solid #FF0000'
        alert("不得空白!")
    }
    else if (email.value.search(emailRule) == -1) {
        email.style.border = '2px solid #FF0000'
        alert("請輸入正確的電子郵件格式!")
    }
})