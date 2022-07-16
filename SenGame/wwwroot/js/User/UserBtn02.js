
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
