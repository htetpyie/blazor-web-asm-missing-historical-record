$(document).ready(function () {
    window.enableLoading();
})

window.enableLoading = function () {
    document.body.scrollTop = 0; 
    document.documentElement.scrollTop = 0

    $('body').css('overflow','hidden');
    $('#loading').css('display','flex');
}

window.disableLoading = function () {
    $('#loading').css('display', 'none');
    $('body').css('overflow','auto');
}