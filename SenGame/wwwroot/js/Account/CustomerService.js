let typeError = document.querySelector(".type-error")
let nameError = document.querySelector(".name-error")
let textcontent = document.querySelector(".text-content")
let textarea = document.querySelector("textarea")
let btn = document.querySelector(".send")
let type = document.getElementById("game-type")
let name = document.getElementById("game-name")
btn.onclick = function () {
    if ($("#game-type option:selected").text() == "請選擇遊戲類型") {
        type.style.border = '2px solid #FF0000'
        typeError.innerText = "未選擇遊戲類型"
        typeError.style.color = "red"
    }
    else if ($("#game-name option:selected").text() == "請選擇遊戲名稱") {
        name.style.border = '2px solid #FF0000'
        nameError.innerText = "未選擇遊戲名稱"
        nameError.style.color = "red"
    }
    else if (textarea.value == '') {
        textarea.style.border = '2px solid #FF0000'
        textcontent.innerText = "內容不得為空白!"
        textcontent.style.color = '#FF0000'
    }
}

  