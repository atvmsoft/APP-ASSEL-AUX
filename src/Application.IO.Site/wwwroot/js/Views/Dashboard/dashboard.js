$(document).ready(function () {
    $(".tab-principal").height($(window).height() - 205);
    $(window).resize(function () {
        $(".tab-principal").height($(window).height() - 205);
    });

    new MvcGrid(document.querySelector('#GridAdvogado'), {
        sourceUrl: baseUrl + '/Dashboard/GridAdvogado'
    }); 
});