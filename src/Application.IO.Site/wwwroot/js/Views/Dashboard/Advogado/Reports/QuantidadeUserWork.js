function LoadReportUserWork() {
    $.ajax({
        type: "POST",
        url: baseUrl + "/Dashboard/GetReportUserWork",
        success: function (result) {
            $(".mes-passado").html(formatMoney(result[0], 0, "", "."));
            $(".mes-atual").html(formatMoney(result[1], 0, "", "."));
            $(".nesta-semana").html(formatMoney(result[2], 0, "", "."));
            $(".total-hoje").html(formatMoney(result[3], 0, "", "."));
        },
        error: function () {
            DefaultErrorAlert();
        }
    });
}


$(document).ready(function () {
    LoadReportUserWork();

    $(".refresh-report-user-work").click(function () {
        LoadReportUserWork();
    });
});