function GetCidades(id) {
    $.getJSON("/Values/ListCidades", { idGeoEstado: id }, function (data) {
        $("#IdGeoCidade").empty();
        let items = "";
        $.each(data, function (i, e) {
            items += "<option value=\"" + e.id + "\">" + e.nome + "</option>";
        });

        $("#IdGeoCidade").html(items);
        $("#IdGeoCidade").removeAttr("Disabled");
    });
}

function RefreshSituacao(idadv) {
    $.ajax({
        type: "POST",
        url: "/Dashboard/GetSituacao",
        data: { idAdv: idadv },
        success: function (result) {
            $(".ckb-situacao").empty();

            if (result.length === 0)
                $(".ckb-situacao").html("<span class=\"span-situacao-notfound\">Nenhum item encontrado</span>");
            else
                $(result).each(function (i, e) {
                    $(".ckb-situacao").append("<label><input type=\"checkbox\" value=\"" + e.id + "\"" + (e.selected ? " checked" : "") + " /><span>" + e.nome + "</span></label>");
                });
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}

function RefreshAreaAtuacao(idadv) {
    $.ajax({
        type: "POST",
        url: "/Dashboard/GetAreaAtuacao",
        data: { idAdv: idadv },
        success: function (result) {
            $(".ckb-areaatuacao").empty();

            if (result.length === 0)
                $(".ckb-areaatuacao").html("<span class=\"span-areatuacao-notfound\">Nenhum item encontrado</span>");
            else
                $(result).each(function (i, e) {
                    $(".ckb-areaatuacao").append("<label><input type=\"checkbox\" value=\"" + e.id + "\"" + (e.selected ? " checked" : "") + " /><span>" + e.nome + "</span></label>");
                });
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}

$(document).ready(function () {
    $("#IdGeoEstado").change(function () {
        GetCidades($("#IdGeoEstado").val());
    });

    $("#FormEdtAdvogado").submit(function () {
        let situacao = [];
        $($(".ckb-situacao input[type='checkbox']:checked")).each(function (i, e) {
            situacao.push(e.value);
        });

        let areaAtuacao = [];
        $($(".ckb-areaatuacao input[type='checkbox']:checked")).each(function (i, e) {
            areaAtuacao.push(e.value);
        });

        let erros = [];
        if (situacao.length === 0) erros.push("Nenhum item selecionado em \"Situação\"");
        if (areaAtuacao.length === 0) erros.push("Nenhum item selecionado em \"Área de Atuação\"");

        if (erros.length !== 0) {
            DefaultInfo(erros, 420);
            return;
        }
        else
            toastr.clear();

        var fdata = new FormData();
        fdata.append("IFoto", ($('#IFoto')[0]).files[0]);

        $($(this).serializeArray()).each(function (i, e) {
            fdata.append(e.name, e.value);
        });

        fdata.append("ListSituacao", situacao.join("-"));
        fdata.append("ListAreaAtuacao", areaAtuacao.join("-"));

        $.ajax({
            type: this.method,
            url: this.action,
            contentType: false,
            processData: false,
            data: fdata,
            success: function (result) {
                if (result.valido !== undefined && !result.valido)
                    DefaultError(result.mensagens, 500);
                else {
                    DefaultSucessAlert();

                    //se der td certo e não for edição reseta o formulario
                    if (modelidadv === 0)
                        $("#FormEdtAdvogado")[0].reset();
                    else
                        window.location.href = "/Dashboard/Index";
                }
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });
});