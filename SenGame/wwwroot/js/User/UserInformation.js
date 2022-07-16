
//使用者主SUserinformation() {
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