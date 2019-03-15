$("#tab-att").click(function () {
    if ($("#GridAreaAtuacao").is(":empty")) {
        new MvcGrid(document.querySelector('#GridAreaAtuacao'), {
            sourceUrl: baseUrl + '/Dashboard/GridAreaAtuacao'
        });
    }
});

function GridAreaAtuacaoEdt(id, inscadadv = false) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/EdtAreaAtuacao",
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

function GridAreaAtuacaoDel(id) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/DelAreaAtuacao",
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