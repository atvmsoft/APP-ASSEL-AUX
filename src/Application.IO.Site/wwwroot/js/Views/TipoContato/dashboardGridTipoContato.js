function GridTipoContatoEdt(id) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/EdtTipoContato",
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

function GridTipoContatoDel(id) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/DelTipoContato",
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