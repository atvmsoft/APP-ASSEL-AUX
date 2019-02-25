$(document).ready(function () {
    $("#FormAdvChangeAvatar").submit(function () {
        var fdata = new FormData();

        fdata.append("IFoto", ($('#IFoto')[0]).files[0]);
        fdata.append("Id", $('#Id').val());

        $.ajax({
            type: this.method,
            url: this.action,
            contentType: false,
            processData: false,
            data: fdata,
            success: function (result) {
                if (result.valido !== undefined && !result.valido)
                    DefaultError(result.mensagens, 500);
                else {
                    DefaultSucessAlert();
                    $("#ModalMain").modal("hide");
                }
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });
});