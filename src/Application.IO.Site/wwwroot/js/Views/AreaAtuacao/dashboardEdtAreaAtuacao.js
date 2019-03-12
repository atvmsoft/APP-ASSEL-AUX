$("#FormEdtAreaAtuacao").submit(function () {
    $.ajax({
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (result) {
            if (result.valido !== undefined && !result.valido)
                DefaultError(result.mensagens, 400);
            else {
                DefaultSucessAlert();
                $("#ModalMain").modal("hide");

                if (!inscadadv)
                    new MvcGrid(document.querySelector('#GridAreaAtuacao')).reload();
                else {
                    if ($(".span-areatuacao-notfound").length > 0)
                        $(".span-areatuacao-notfound").remove();

                    $(".ckb-areaatuacao").append("<label><input type=\"checkbox\" checked value=\"" + result.objRetorno.id + "\"><span>" + result.objRetorno.nome + "</span></label>");
                }
            }
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
});