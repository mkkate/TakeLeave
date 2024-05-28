$(function () {
    var url = '/Chat/GetUsers';
    $.get(url, function (data) {
        $("#userListContainer").html(data);
    });
});
