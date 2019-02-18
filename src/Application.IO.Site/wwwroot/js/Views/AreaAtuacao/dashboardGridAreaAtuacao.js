function GridAreaAtuacaoEdt(id) {
    $.ajax({
        type: "POST",
        url: '/Dashboard/EdtAreaAtuacao',
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

function GridAreaAtuacaoDel(id) {
    $.ajax({
        type: "POST",
        url: '/Dashboard/DelAreaAtuacao',
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