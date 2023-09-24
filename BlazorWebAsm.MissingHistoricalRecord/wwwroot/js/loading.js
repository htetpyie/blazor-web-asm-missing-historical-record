window.enableLoading = function () {
    console.log(document.getElementById("loading"))
    $('#loading').css('display','flex');
    $('body').css('overflow','hidden');
}

window.disableLoading = function () {
    $('#loading').css('display', 'none');
    $('body').css('overflow','auto');
    
}