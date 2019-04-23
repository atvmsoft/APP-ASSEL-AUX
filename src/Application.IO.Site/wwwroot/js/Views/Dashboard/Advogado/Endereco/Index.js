function GetEndCidades(idEndGeoEstado, idEndGeoCidade) {
    $.ajax({
        type: "GET",
        url: baseUrl + "/Values/ListCidades",
        data: { idGeoEstado: idEndGeoEstado },
        success: function (result) {
            $("#IdEndGeoCidade").empty();
            let items = "";
            $.each(result, function (i, e) {
                items += "<option value=\"" + e.id + "\">" + e.nome + "</option>";
            });

            $("#IdEndGeoCidade").html(items);

            if (idEndGeoCidade !== 0 && idEndGeoCidade !== undefined) $("#IdEndGeoCidade").val(idEndGeoCidade.toString());
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}

function StartEstadoCidade() {
    $("#IdEndGeoEstado").val($("#IdEndGeoEstado option:first").val());
    GetEndCidades($("#IdEndGeoEstado").val());
    $("#IdEndGeoCidade").val($("#IdEndGeoCidade option:first").val());
}

$(document).ready(function () {
    $("#CodCep").focusout(function () {
        if ($(this).val() === "") return false;

        $(".msg-box,.msg-new-adress,.add-new-adress").addClass("hide");

        $.ajax({
            type: "post",
            url: baseUrl + "/Values/PostalCode",
            data: { pcode: $(this).val() },
            success: function (result) {
                $("#ddlEnderecos").empty();
                $("#ddlEnderecos").removeAttr("required");

                $("#Logradouro,#Bairro").val("");

                if (result.length > 0) {
                    if (result.length === 1) {

                        if (!$(".row-adresses").hasClass("hide")) $(".row-adresses").addClass("hide");
                        $(".row-adress").removeClass("hide");

                        $("#IdGeoCep").val(result[0].id);
                        $("#Logradouro").val(result[0].endereco);
                        $("#Bairro").val(result[0].bairro);
                        $("#IdEndGeoEstado").val(result[0].idGeoEstado.toString());

                        GetEndCidades(result[0].idGeoEstado, result[0].idGeoCidade);

                        $("#Logradouro,#Bairro,#IdEndGeoEstado,#IdEndGeoCidade").attr("disabled", "");
                    }
                    else {
                        if (!$(".row-adress").hasClass("hide")) $(".row-adress").addClass("hide");
                        $(".row-adresses").removeClass("hide");

                        $("#ddlEnderecos").attr("required", "");
                        $("#ddlEnderecos").append($("<option></option>").val("").html("Selecione"));

                        $(result).each(function () {
                            $("#ddlEnderecos").append($("<option cd=\"" + this.idGeoCidade + "\" st=\"" + this.idGeoEstado + "\" br=\"" + this.bairro + "\" ed=\"" + this.endereco + "\"></option>")
                                .val(this.id).html(this.endereco + ", " + this.bairro + ", " + this.cidade + "/" + this.estado));
                        });
                    }

                    $(".msg-new-adress").removeClass("hide");

                    return;
                }

                $("#IdGeoCep").val(0);

                StartEstadoCidade();

                $(".msg-box").removeClass("hide");
                $("#Logradouro,#Bairro,#IdEndGeoEstado,#IdEndGeoCidade").removeAttr("disabled");
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });

    $("#FormEdtAdvEndereco").submit(function () {
        let disabled = $(this).find(":input:disabled").removeAttr("disabled");
        let lData = $(this).serialize();
        disabled.attr("disabled", "");

        $.ajax({
            type: this.method,
            url: this.action,
            data: lData,
            success: function (result) {
                if (result.valido !== undefined && !result.valido)
                    DefaultError(result.mensagens, 500);
                else {
                    DefaultSucessAlert();
                    new MvcGrid(document.querySelector('#GridAdvogadoEndereco')).reload();
                    $("#ModalMain").modal("hide");
                }
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });

    $("#IdEndGeoEstado").change(function () {
        GetEndCidades($("#IdEndGeoEstado").val());
    });

    $("#ddlEnderecos").change(function () {
        var op = $("#ddlEnderecos option:selected");

        if (op.val() === "") {
            $("#Logradouro,#Bairro").val("");
            StartEstadoCidade();
        }
        else {
            $("#IdGeoCep").val(op.val());
            $("#Logradouro").val(op.attr("ed"));
            $("#Bairro").val(op.attr("br"));
            $("#IdEndGeoEstado").val(op.attr("st"));

            GetEndCidades(parseInt(op.attr("st")), parseInt(op.attr("cd")));
        }
    });

    $(".cep-box").mask("00.000-000");

    $("#Logradouro,#Bairro,#IdEndGeoEstado,#IdEndGeoCidade").attr("disabled", "");

    $(".link-new-adress").click(function () {
        $("#ddlEnderecos").removeAttr("required");
        $(".msg-new-adress,.row-adresses").addClass("hide");
        $(".add-new-adress,.row-adress").removeClass("hide");

        $("#IdGeoCep").val(0);
        $("#InsEndereco").val(true);
        $("#Logradouro,#Bairro,#IdEndGeoEstado,#IdEndGeoCidade").removeAttr("disabled");
        $("#Logradouro,#Bairro,#Numero,#Complemento").val("");

        StartEstadoCidade();

        $("#Logradouro").focus();
    });

    $(".btn-can-adress").click(function () {
        $(".add-new-adress").addClass("hide");
        $("#CodCep").focus();
        $("#InsEndereco").val(false);

        StartEstadoCidade();

        $("#Logradouro,#Bairro,#Numero,#Complemento,#CodCep").val("");
        $("#Logradouro,#Bairro,#IdEndGeoEstado,#IdEndGeoCidade").attr("disabled", "");
    });
});