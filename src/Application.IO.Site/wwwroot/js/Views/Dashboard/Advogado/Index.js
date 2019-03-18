function GetCidades(id) {
    $.getJSON(baseUrl + "/Values/ListCidades", { idGeoEstado: id }, function (data) {
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
        url: baseUrl + "/Dashboard/GetSituacao",
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
        url: baseUrl + "/Dashboard/GetAreaAtuacao",
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

function GridAdvogadoContatoEdt(id, idadv) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/EdtAdvContato",
        data: { id: id, idAdv: idadv },
        success: function (result) {
            $("#ModalMainContent").html(result);
            $("#ModalMain").modal("show");
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}

function GridAdvogadoContatoDel(id, idadv) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/DelAdvContato",
        data: { id: id, idAdv: idadv },
        success: function (result) {
            $("#ModalMainContent").html(result);
            $("#ModalMain").modal("show");
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}

function GridAdvogadoEnderecoEdt(id, idadv) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/EdtAdvEndereco",
        data: { id: id, idAdv: idadv },
        success: function (result) {
            $("#ModalMainContent").html(result);
            $("#ModalMain").modal("show");
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}

function GridAdvogadoEnderecoDel(id, idadv) {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/DelAdvEndereco",
        data: { id: id, idAdv: idadv },
        success: function (result) {
            $("#ModalMainContent").html(result);
            $("#ModalMain").modal("show");
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

    $(".btn-novo-adv").click(function () {
        window.location.href = baseUrl + "/Dashboard/Lawyer";
    });

    $("#FormEdtAdvogado").submit(function () {
        $.blockUI({
            message: "<img src=\"" + baseUrl + "/images/load01.gif\" height=\"100\"/>"
        });

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
        //if (areaAtuacao.length === 0) erros.push("Nenhum item selecionado em \"Área de Atuação\"");

        if (erros.length !== 0) {
            DefaultInfo(erros, 420);
            return;
        }
        else
            toastr.clear();

        var fdata = new FormData();

        if ($("#Id").val() === "0") fdata.append("IFoto", ($('#IFoto')[0]).files[0]);

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
                    if ($("#Id").val() === "0") {
                        window.location.href = window.location.origin + baseUrl + "/Dashboard/Lawyer/" + result.objRetorno;
                    }
                    else
                        DefaultSucessAlert();
                }
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });

    $(".btn-ver-foto").click(function () {
        $.ajax({
            type: "POST",
            url: baseUrl + "/Dashboard/EdtAdvAvatar",
            datatype: "Application/Json",
            data: { id: $("#Id").val() },
            success: function (result) {
                $("#ModalMainContent").html(result);
                $("#ModalMain").modal("show");
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });

    $(".dateformat").mask("00/00/0000");
    $(".oabformat").mask("0000000000");
    $(".phone-number").mask("(00) 000000000");
});