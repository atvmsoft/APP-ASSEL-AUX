function GridAdvogadoEdt(id) {
    window.location.href = "/Dashboard/Lawyer/" + id;
}

function GridAdvogadoDel(id) {
    $.ajax({
        type: "POST",
        url: '/Dashboard/DelAdvogado',
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