$("#tab-t-end").click(function () {
    if ($("#GridTipoEndereco").is(":empty")) {
        new MvcGrid(document.querySelector('#GridTipoEndereco'), {
            sourceUrl: baseUrl + '/Dashboard/GridTipoEndereco'
        });
    }
});

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