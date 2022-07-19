

//在JS中建立集線器
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
//與Service建立連線
connection.start()
    .then(function () { })
    .catch(function (err) {
        alert('連線錯誤: ' + err.toString());
    });
//忍術:全域變數
let useridArray = []
let groupnameArray = []
let del = document.querySelector(".delete-type")
let rightmenudel = document.querySelector("#groupdelete")
let allgroup = document.querySelectorAll(".friend-group")
let friendarray = []
let frienddetails = {}
//用來限制聊天框一次只能產出一個
let bool = true;

//好友名單
let ul = document.querySelector(".friend-ul")
//用來做拖移改變好友列表寬度
let R = document.querySelector(".resizeR")
//好友列表裡的搜尋好友
let search = document.querySelector(".search")
//狀態欄
let li = document.querySelectorAll(".state-li")
//畫面左右側
let left = document.querySelector(".chat-left")
let right = document.querySelector(".chat-right")
//滑鼠右鍵的自定義選單
let rightmenu = document.getElementById('rightmenu');
//新增群組的span
let addtype = document.querySelector(".add-type")
//刪除好友的span
let delfriend = document.querySelector(".del-friend")
//群組分類
let modal = document.getElementById("myModal");

//modal的選擇好友區塊
let addblock = document.querySelector(".add")
//modal內的確認按鈕
let check = document.querySelector(".check")
let friendgroup = document.querySelector(".friends")
let AllFriends = document.querySelectorAll(".friend-li")
let delmodal = document.getElementById("delModal")
//載入的時候判斷裝置，決定有什麼樣功能
window.onload = function () {
    Setnavbar(".container-fluid");
    if (screen.width > 768) {
        computer()
    }
    else {
        phone()
    }
}
//送出資料到後端
async function Post(url, data) {
    await fetch(url, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'content-type': 'application/json'
        }

    })
        .then(res => { return res.json() })
        .then(result => console.log(result))
}

function computer(){
    allgroup.forEach(item => {
        item.style.cursor = 'pointer'
        let fspan = item.querySelector(".friends-span")
        let list = item.querySelector(".friend-ul")
        //控制群組縮放及刪除
        fspan.onmousedown = function (e) {
            if (e.which == 3) {

                delmenuCTRL(fspan)
                let delcheck = document.querySelector(".del-check")
                delcheck.onclick = function () {
                    var data = {
                        Groupname: fspan.innerHTML,
                    }
                    console.log(data)
                    var url = "/Friend/DeleteGroup"
                    Post(url, data)
                    delModal.style.display = 'none'
                }
                let editcheck = document.querySelector(".edit-check")
                editcheck.onclick = function () {
                    var data = {
                        NewGroupName: editgroup.value,
                        Groupname: fspan.innerHTML,
                    }
                    var url = "/Friend/EditGroupName"
                    Post(url, data)
                    fspan.innerHTML = editgroup.value
                    editModal.style.display = 'none'
                }
            }
            else {
                $(list).toggle()
            }


        }

        var allfriendlist = item.querySelectorAll(".friend-li")
        allfriendlist.forEach(friend => {
            friend.onmousedown = function (e) {
                if (e.which == 3) {
                    rightmenuCTRL(friend)
                    //從群組中刪除好友
                    let delfriendcheck = document.querySelector(".del-friend-check")
                    let friendId = friend.querySelector("#friendid")
                    delfriendcheck.onclick = function () {
                        var data = {
                            UserId: friendId.value,
                            Groupname:fspan.innerHTML,
                        }
                      
                        
                        console.log(data)
                        var url = "/Friend/DeleteFriend"
                        Post(url, data)
                        delfriendModal.style.display = 'none'
                    }

                    //新增群組
                    let choose = document.querySelector(".choose-friend")
                    chooseFriend()
                    check.onclick = function () {
                        var data = {
                            GroupNames: groupnameArray,
                            Ids: useridArray,
                        }
                        let span = document.createElement("span")
                        span.setAttribute("class", "friends-span w-100 pl-2 py-2 d-block user-select-none")
                        let group = document.createElement("div")
                        group.append(span)
                        group.setAttribute("class", "friend-group new-group w-100")
                        let div = document.createElement("div")
                        div.setAttribute("class", `friend-ul w-100`)
                        friendarray.forEach(item => {

                            //自定義群組名稱
                            span.innerText = `${groupname.value}`
                            div.append(getfriend(item.img, item.name, item.line))
                            group.append(div)

                        })
                        friendarray = []
                        friendgroup.append(group)
                        modal.style.display = 'none'
                        addblock.innerHTML = ' '
                        choose.innerHTML = ' '
                        groupname.value = ' '
                        var url = "/Friend/Chat"
                        Post(url, data)



                    }
                }
                else {
                    document.ondragend = function (e2) {
                        if (e2.clientX > 250 && bool == true) {
                            bool = false
                            var url = "/Friend/ReadChatContent"
                            
                            let id = friend.querySelector("#friendid").value
                            Get(url,id)
                            let img = friend.querySelector("img").src
                            let name = friend.querySelector(".friend-name").innerText
                            right.append(getcard(id, img, name))
                           
                            let show = document.querySelector(".show")
                            //點擊X後關閉聊天視窗
                            let close = document.querySelector(".close")
                            close.onclick = function () {
                                right.innerHTML = ' '
                                bool = true

                            }
                            $("#text").keydown(function (e) {
                                if (e.which == 13) {
                                    
                                    let text = document.getElementById("text")
                                    var time = new Date()
                                    let p = document.createElement("p")
                                    let timep = document.createElement("p")
                                    timep.setAttribute("class", "pt-3 mb-0")

                                    var chatdata = {
                                        ChatContent: text.value,
                                        UserId: fid.value,
                                    }
                                    var url = "/Friend/CreateChatContext"


                                    timep.innerText = `${time.getHours().toString().padStart(2, "0")}:${time.getMinutes().toString().padStart(2, "0")}`
                                    let div = document.createElement("div")
                                    div.style.display = 'flex'
                                    p.setAttribute("class", "content px-2 py-2 my-1")
                                    p.innerText = text.value
                                    text.value = ' '
                                    div.append(p, timep)
                                    show.append(div)
                                    Post(url, chatdata)
                                }
                            })
                        }
                        
                    }
                }
                
            }
        })
    })
}


//modal的取消按紐
let cancel = document.querySelector(".cancel");
//modal的X
let span = document.querySelector(".close");
span.onclick = function () {
    modalReset()
    groupnameReset()
}
cancel.onclick = function () {
   modalReset()
    groupnameReset()
}


//關閉刪除群組的Modal
let delcancel = document.querySelector(".del-cancel")
delcancel.onclick = function () {
    delModal.style.display = 'none'
}
let editcancel = document.querySelector(".edit-cancel")
editcancel.onclick = function () {
    editModal.style.display = 'none'
}
let delfriendcancel = document.querySelector(".del-friend-cancel")
delfriendcancel.onclick = function () {
    delfriendModal.style.display = 'none'
}
let delclose = document.querySelector(".del-close")
delclose.onclick = function () {
    delModal.style.display = 'none'
}
let delfriendclose = document.querySelector(".del-friend-close")
delfriendclose.onclick = function () {
    delfriendModal.style.display = 'none'
}
let editclose = document.querySelector(".edit-close")
editclose.onclick = function () {
    editModal.style.display = 'none'
}



//產出好友清單
function getfriend(img, name, line) {
    let clone = friendcard.content.cloneNode(true)
    clone.querySelector("img").src = img
    clone.querySelector("span").innerText = name
    clone.querySelector("p").innerText = line
    return clone;
}

//產出modal裡的好友清單
function getfriend2(img, name, line) {
    let clone = friendcard2.content.cloneNode(true)
    clone.querySelector("img").src = img
    clone.querySelector("span").innerText = name
    clone.querySelector("p").innerText = line
    return clone;
}


//控制狀態欄出現/消失
$(".user-span").click(function () {
    $(".state-ul").toggle();
})

//改變上線狀態
li.forEach((item, index) => {
    item.addEventListener('click', function () {
        document.querySelector(".line").innerText = item.innerText
        $(".state-ul").toggle();
    })
})

//產出對話框
function getcard(id,src, text) {
    let clone = message.content.cloneNode(true)
    clone.querySelector("input").value = id
    clone.querySelector("img").src = src
    clone.querySelector("p").innerText = text
    return clone
}

//產出群組分類
function tag(name) {
    let clone = friendtag.content.cloneNode(true)
    clone.querySelector("p").innerText = name.innerText
    clone.querySelector("span")
    return clone
}

//調整好友列表寬度
R.onmousedown = function (e) {
    document.onmousemove = function (e1) {
        left.style.width = e1.clientX - e.offsetX + "px"
        search.style.width = e1.clientX - e.offsetX - 80 + "px"
    }
    document.onmouseup = function () {
        document.onmousedown = null
        document.onmousemove = null
    }
}

// 滑鼠點擊其他位置時隱藏自定義選單
document.onclick = function () {
    rightmenu.style.display = 'none';
    groupdelete.style.display = 'none'
}
let edit = document.querySelector(".edit")
edit.onclick = function () {
    editModal.style.display = 'block'
}
addtype.onclick = function () {
    modal.style.display = "block";
}
delfriend.onclick = function () {
    delfriendModal.style.display = 'block'
}
del.onclick = function () {
    delmodal.style.display = "block"
}


//顯示聊天紀錄
async function Get(url) {
    await fetch(url)
        .then(res => res.json())
        .then(res => res.forEach((index => {
            if (index.userId == fid.value) {
                
                let div = document.createElement("div")
                let p = document.createElement("p")
                let timep = document.createElement("p")
                let show = document.querySelector(".show")
                p.setAttribute("class", "content px-2 py-2 my-1")
                p.innerHTML = index.chatContent
                //timep.innerHTML = index.ChatTime
                div.append(p)
                show.append(div)
               
            }

        })))
       

       
}

//產出群組分類
function chooseFriend() {
    var li2 = document.querySelectorAll(".friend-li2")
    li2.forEach(item => {
        item.onclick = function () {
            if (groupname.value != '') {
                var tagname = item.querySelector(".friend-name2")
                var userid = item.querySelector("#userid")

                groupnameArray.push(groupname.value)
                useridArray.push(userid.value)

                addblock.append(tag(tagname))
                item.style.display = 'none'
                var img = item.querySelector(".friend-img2").src
                var name = item.querySelector(".friend-name2").innerHTML
                var line = item.querySelector(".friend-line2").innerHTML
                frienddetails["img"] = img
                frienddetails["name"] = name
                frienddetails["line"] = line
                friendarray.push(frienddetails)
                frienddetails = {}
            }
            else {
               
                groupname.style.border = '1px solid #FF0000'
                groupname.style.color = '#FF0000'
                groupname.onclick = function () {
                 groupnameReset()
                }
            }

        }
    })
}


//手機能用的功能
function phone() {
    AllFriends.forEach(item => {

        ul.append(getfriend(item.img, item.name, item.line))

    })
    let friend = document.querySelectorAll(".friend-li")
    friend.forEach((item, index) => {
        item.addEventListener('click', function () {
            LRctrl()
            var img = item.querySelector("img").src
            var name = item.querySelector(".friend-name").innerText
            right.append(getcard(id,img, name))
            let title = document.querySelector(".message-title")
            title.style.width = '100%'
            let show = document.querySelector(".show")
            //點擊X後關閉聊天視窗
            let close = document.querySelector(".close")
            close.addEventListener('click', function () {
                bool = false
                right.innerHTML = " "
                LRctrl()
            })
            let send = document.querySelector(".input-group-text")
            send.addEventListener('click', function () {
                let text = document.getElementById("text")
                let p = document.createElement("p")
                let div = document.createElement("div")
                p.setAttribute("class", "content px-2 py-2 my-1")
                p.innerText = text.value
                text.value = ' '
                div.append(p)
                show.append(div)
            })
            //上傳圖片
            upload.addEventListener('change', function (e) {
                let img = document.createElement("img")
                var [file] = upload.files
                if (file) {
                    img.style.display = "block"
                    img.style.maxWidth = "100px"
                    img.src = URL.createObjectURL(file)
                    show.append(img)
                }
            })
        })
    })
}
//重置
function groupnameReset() {
    groupname.value = ''
    groupname.style.color = '#000'
    groupname.style.border = 'none'
}
function modalReset() {
    modal.style.display = "none";
    addblock.innerText = ' '
}
//控制左右側顯現/消失
function LRctrl() {
    $(".chat-right").toggle();
    $(".chat-left").toggle();
}
function rightmenuCTRL(e) {
    e.oncontextmenu = function (e1) {
        var e1 = e1 || window.event;
        e1.preventDefault();  //阻止系統右鍵選單
        // 顯示自定義的選單調整位置
        let scrollTop = document.documentElement.scrollTop || document.body.scrollTop;// 獲取垂直滾動條位置
        let scrollLeft = document.documentElement.scrollLeft || document.body.scrollLeft;// 獲取水平滾動條位置
        rightmenu.style.display = 'block';
        rightmenu.style.left = e1.clientX + scrollLeft + 'px';
        rightmenu.style.top = e1.clientY + scrollTop + 'px';
    }
}

function delmenuCTRL(e) {
    e.oncontextmenu = function (e1) {
        var e1 = e1 || window.event;
        e1.preventDefault();  //阻止系統右鍵選單
        // 顯示自定義的選單調整位置
        let scrollTop = document.documentElement.scrollTop || document.body.scrollTop;// 獲取垂直滾動條位置
        let scrollLeft = document.documentElement.scrollLeft || document.body.scrollLeft;// 獲取水平滾動條位置
        groupdelete.style.display = 'block';
        groupdelete.style.left = e1.clientX + scrollLeft + 'px';
        groupdelete.style.top = e1.clientY + scrollTop + 'px';
    }
}

