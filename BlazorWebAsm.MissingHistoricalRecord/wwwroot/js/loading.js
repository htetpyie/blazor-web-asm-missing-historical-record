window.enableLoading = function () {
    console.log(document.getElementById("loading"))
    $('#loading').css('display','flex');
}

window.disableLoading = function () {
    $('#loading').css('display', 'none');
}