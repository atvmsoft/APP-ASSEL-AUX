$("#FormEdtSituacao").submit(function () {
    $.ajax({
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (result) {
            if (result.valido !== undefined && !result.valido)
                DefaultError(result.mensagens, 400);
            else {
                DefaultSucessAlert();
                $("#ModalMain").modal("hide");
                new MvcGrid(document.querySelector('#GridSituacao')).reload();
            }
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
});