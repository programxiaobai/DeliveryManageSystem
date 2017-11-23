$(function () {
    //未经登录不可查看内容
    var IsAuthenticated = $("#IsAuthenticated").text();
    if (IsAuthenticated === "False") {
        $("#STOProduct").hide();
        $("#STOOrder").hide();
    }
});
