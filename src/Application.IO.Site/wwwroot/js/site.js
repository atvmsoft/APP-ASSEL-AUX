function DefaultMessage(type, title, msgs, width) {

    width = (width < 270 || width === undefined) ? 270 : width;

    var error = "<ul style=\"padding-top:10px!important; padding-left: 16px!important;\">";
    
    $(msgs).each(function (i, e) {
        error += "<li>" + e + "</li>";
    });

    error += "</ul>";

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "0",
        "hideDuration": "0",
        "timeOut": "0",
        "extendedTimeOut": "0",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    let ttr = toastr[type](error, title);
    if (ttr === undefined) return;

    ttr.css("width", width + "px");
}

function DefaultError(msgs, width) {
    DefaultMessage("error", "Falha ao executar ação!", msgs, width);
}
function DefaultErrorAlert() {
    DefaultError(["Ocorreu um erro. Favor tentar novamente mais tarde."], 430);
}

function DefaultSucess(msgs, width) {
    DefaultMessage("success", "Operação realizada com sucesso!", msgs, width);
}
function DefaultSucessAlert() {
    DefaultSucess(["Tudo certo. Prossiga."], 340);
}

function DefaultInfo(msgs, width) {
    DefaultMessage("info", "Informação importante!", msgs, width);
}

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
})