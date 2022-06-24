let span = document.querySelector(".email-span")
let email = document.getElementById("email")
let forgetbtn = document.querySelector(".forget-btn")
let emailRule = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z]+$/;
forgetbtn.addEventListener('click', function () {
    if (email.value == '') {
        email.style.border = '2px solid #FF0000'
        span.innerText = "Email欄位不得空白"
        span.style.color = '#FF0000'
    }
    else if (email.value.search(emailRule) == -1) {
        email.style.border = '2px solid #FF0000'
        span.innerText = "Email的輸入的格式不正確"
        span.style.color = '#FF0000'
    }
})