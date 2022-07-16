
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

