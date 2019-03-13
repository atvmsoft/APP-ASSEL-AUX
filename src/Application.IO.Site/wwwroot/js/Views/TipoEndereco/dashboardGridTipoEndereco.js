function GridTipoEnderecoEdt(id) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/EdtTipoEndereco",
        datatype: "Application/Json",
        data: { id: id },
        success: function (result) {
            $("#ModalMainContent").html(result);
            $("#ModalMain").modal("show");
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}

function GridTipoEnderecoDel(id) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/DelTipoEndereco",
        datatype: "Application/Json",
        data: { id: id },
        success: function (result) {
            $("#ModalMainContent").html(result);
            $("#ModalMain").modal("show");
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}