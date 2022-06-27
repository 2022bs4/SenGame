function color(str) {
    document.body.style.backgroundImage = str;
    document.getElementById('card-Edit_User').style.backgroundImage = str;
}

window.onload = function () {
    var addbtn = document.getElementById("AddFriendBtn");
    var cancelbtn = document.getElementById("CancelFriendBtn");
    addbtn.onclick = function () {
        if (cancelbtn.style.display == "none") {
            cancelbtn.style.display = "block";
            addbtn.value = "取消加好友Q";
        }
        else {
            cancelbtn.style.display = "none";
            addbtn.value = "加好友 NOW";
        }
    }
}