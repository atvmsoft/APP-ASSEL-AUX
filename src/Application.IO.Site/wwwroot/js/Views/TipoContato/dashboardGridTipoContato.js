$("#tab-t-cont").click(function () {
    if ($("#GridTipoContato").is(":empty")) {
        new MvcGrid(document.querySelector('#GridTipoContato'), {
            sourceUrl: baseUrl + '/Dashboard/GridTipoContato'
        });
    }
});

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