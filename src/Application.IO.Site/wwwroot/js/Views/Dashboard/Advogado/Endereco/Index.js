$(document).ready(function () {
    $("#CodCep").focusout(function () {

        if ($(this).val() === "") return false;

        $(".msg-box").addClass("hide");

        $.ajax({
            type: "post",
            url: "/Values/PostalCode",
            data: { pcode: $(this).val() },
            success: function (result) {
                $("#Logradouro,#Bairro,#Cidade,#Estado").val("");
                $("#Logradouro,#Bairro,#Cidade,#Estado").removeAttr("disabled");

                if (result !== null) {
                    $("#Logradouro").val(result.endereco);
                    $("#Bairro").val(result.bairro);
                    $("#Cidade").val(result.cidade);
                    $("#Estado").val(result.estado);

                    $("#Logradouro,#Bairro,#Cidade,#Estado").attr("disabled", "");
                }
                else
                    $(".msg-box").removeClass("hide");
            },
            error: function () {
                DefaultErrorAlert();
            }
        });
    });

    $(".cep-box").mask("00.000-000");

    $('[autofocus]').first().focus();
});