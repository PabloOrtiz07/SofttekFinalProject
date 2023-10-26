var token = getCookie("Token");
var id = getCookie("Id");

 function SendDepositFiduciaryToFiduciary() {

        var postData = {
            UserId: id
     };

        $.ajax({
            type: "POST",
            url: "/Transfers/TransfersFiduciaryToFiduciaryPartial",
            data: JSON.stringify(postData),
            contentType: 'application/json',
            dataType: "html",
            success: function (result) {
                $('#transfersFiduciaryToFiduciaryPartial').html(result);
                $('#transfersFiduciaryToFiduciaryModal').modal('show');
            }
        });
}

$("#transfersFiduciaryToFiduciaryButton").click(function () {
    SendDepositFiduciaryToFiduciary();


}); function SendDepositFiduciaryToCrypto() {

    var postData = {
        UserId: id
    };

    $.ajax({
        type: "POST",
        url: "/Transfers/TransfersFiduciaryToCryptoPartial",
        data: JSON.stringify(postData),
        contentType: 'application/json',
        dataType: "html",
        success: function (result) {
            $('#transfersFiduciaryToCryptoPartial').html(result);
            $('#transfersFiduciaryToCryptoModal').modal('show');
        }
    });
}

$("#transfersFiduciaryToCryptoButton").click(function () {
    SendDepositFiduciaryToCrypto();


}); function SendDepositCryptoToFiduciary() {

    var postData = {
        UserId: id
    };

    $.ajax({
        type: "POST",
        url: "/Transfers/TransfersCryptoToFiduciaryPartial",
        data: JSON.stringify(postData),
        contentType: 'application/json',
        dataType: "html",
        success: function (result) {
            $('#transfersCryptoToFiduciaryPartial').html(result);
            $('#transfersCryptoToFiduciaryModal').modal('show');
        }
    });
}

$("#transfersCryptoToFiduciaryButton").click(function () {
    SendDepositCryptoToFiduciary();
}); function SendDepositCryptoToCrypto() {

    var postData = {
        UserId: id
    };

    $.ajax({
        type: "POST",
        url: "/Transfers/TransfersCryptoToCryptoPartial",
        data: JSON.stringify(postData),
        contentType: 'application/json',
        dataType: "html",
        success: function (result) {
            $('#transfersCryptoToCryptoPartial').html(result);
            $('#transfersCryptoToCryptoModal').modal('show');
        }
    });
}

$("#transfersCryptoToCryptoButton").click(function () {
    SendDepositCryptoToCrypto();
});

$(document).ready(function () {
    $('#userIdHidden').val(id); // Set the value of the hidden input field
});






