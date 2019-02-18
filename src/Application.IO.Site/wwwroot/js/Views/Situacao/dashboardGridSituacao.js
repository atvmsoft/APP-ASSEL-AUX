function GridSituacaoEdt(id) {
    $.ajax({
        type: "POST",
        url: '/Dashboard/EdtSituacao',
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

function GridSituacaoDel(id) {
    $.ajax({
        type: "POST",
        url: '/Dashboard/DelSituacao',
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