$("#tab-sit").click(function () {
    if ($("#GridSituacao").is(":empty")) {
        new MvcGrid(document.querySelector('#GridSituacao'), {
            sourceUrl: baseUrl + '/Dashboard/GridSituacao'
        });
    }
});

function GridSituacaoEdt(id, inscadadv = false) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/EdtSituacao",
        datatype: "Application/Json",
        data: { id: id, insCadAdv: inscadadv },
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
        url: baseUrl + "/Dashboard/DelSituacao",
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