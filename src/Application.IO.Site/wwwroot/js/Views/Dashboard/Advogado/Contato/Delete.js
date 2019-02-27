$(document).ready(function () {
    $("#FormDelAdvDelete").submit(function () {
        $.ajax({
            type: this.method,
            url: this.action,
            data: $(this).serialize(),
            success: function (result) {
                if (result.valido !== undefined && !result.valido)
                    DefaultError(result.mensagens, 400);
                else {
                    DefaultSucessAlert();
                    new MvcGrid(document.querySelector('#GridAdvogadoContato')).reload();
                    $("#ModalMain").modal("hide");
                }
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });
});