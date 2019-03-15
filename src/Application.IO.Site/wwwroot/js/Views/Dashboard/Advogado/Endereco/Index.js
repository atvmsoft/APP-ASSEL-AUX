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

$(document).ready(function () {
    $("#CodCep").focusout(function () {
        if ($(this).val() === "") return false;

        $(".msg-box").addClass("hide");

        $.ajax({
            type: "post",
            url: baseUrl + "/Values/PostalCode",
            data: { pcode: $(this).val() },
            success: function (result) {
                $("#Logradouro,#Bairro").val("");

                if (result !== null) {
                    $("#IdGeoCep").val(result.id);
                    $("#Logradouro").val(result.endereco);
                    $("#Bairro").val(result.bairro);
                    $("#IdEndGeoEstado").val(result.idGeoEstado.toString());

                    GetEndCidades(result.idGeoEstado, result.idGeoCidade);

                    $("#Logradouro,#Bairro,#IdEndGeoEstado,#IdEndGeoCidade").attr("disabled", "");

                    return;
                }

                $("#IdGeoCep").val(0);

                $("#IdEndGeoEstado").val($("#IdEndGeoEstado option:first").val());
                GetEndCidades($("#IdEndGeoEstado").val());
                $("#IdEndGeoCidade").val($("#IdEndGeoCidade option:first").val());

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

    $(".cep-box").mask("00.000-000");
    $("#Logradouro,#Bairro,#IdEndGeoEstado,#IdEndGeoCidade").attr("disabled", "");
});