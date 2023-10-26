var token = getCookie("Token");
var id = getCookie("Id");

 function SendDepositFiduciary() {

        var postData = {
            UserId: id
     };

        $.ajax({
            type: "POST",
            url: "/Deposits/DepositsFiduciaryPartial",
            data: JSON.stringify(postData),
            contentType: 'application/json',
            dataType: "html",
            success: function (result) {
                $('#depositsFiduciaryPartial').html(result);
                $('#depositsFiduciaryModal').modal('show');
            }
        });
}

$("#depositsFiduciaryButton").click(function () {
    SendDepositFiduciary();


}); function SendDepositCrypto() {

    var postData = {
        UserId: id
    };

    $.ajax({
        type: "POST",
        url: "/Deposits/DepositsCryptoPartial",
        data: JSON.stringify(postData),
        contentType: 'application/json',
        dataType: "html",
        success: function (result) {
            $('#depositsCryptoPartial').html(result);
            $('#depositsCryptoModal').modal('show');
        }
    });
}

$("#depositsCryptoButton").click(function () {
    SendDepositCrypto();
});



$(document).ready(function () {
    $('#userIdHidden').val(id); 
});






