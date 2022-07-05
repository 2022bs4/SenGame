//Featured()
SpecialDiscount()
PopVR()
DownThreeH()
TempForeChoese()
Personal()
Renew()

//function Featured() {
//    var FeaturedWrapper = document.querySelector('#featured-wrapper');
//    var temp = FeaturedWrapper.getElementsByTagName("template")[0];
//    for (i = 0; i < 5; i++) {
//        var clon = temp.content.cloneNode(true)
//        FeaturedWrapper.appendChild(clon)
//    }
//}
function SpecialDiscount() {
    var SpecialDiscountWrapper = document.querySelector('#SpecialDiscount-wrapper');
    var temp = SpecialDiscountWrapper.getElementsByTagName("template")[0];
    for (i = 0; i < 5; i++) {
        var clon = temp.content.cloneNode(true)
        SpecialDiscountWrapper.appendChild(clon)
    }
}
function PopVR() {
    var PopVRWrapper = document.querySelector('#popVRGame-wrapper');
    var temp = PopVRWrapper.getElementsByTagName("template")[0];
    for (i = 0; i < 4; i++) {
        var clon = temp.content.cloneNode(true)
        PopVRWrapper.appendChild(clon)
    }
}
function DownThreeH() {
    var lossThenThreeHWrapper = document.querySelector('#lossThenThreeH-wrapper');
    var temp = lossThenThreeHWrapper.getElementsByTagName("template")[0];
    for (i = 0; i < 4; i++) {
        var clon = temp.content.cloneNode(true)
        lossThenThreeHWrapper.appendChild(clon)
    }
}
function TempForeChoese() {
    var tabNew = document.querySelector('.tab-new');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }

    var tabNew = document.querySelector('.tab-bestSell');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }

    var tabNew = document.querySelector('.tab-hotBePost');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }

    var tabNew = document.querySelector('.tab-specialDiscount');
    var temp = tabNew.getElementsByTagName("template")[0];
    for (i = 0; i < 10; i++) {
        var clon = temp.content.cloneNode(true)
        tabNew.appendChild(clon)
    }


}