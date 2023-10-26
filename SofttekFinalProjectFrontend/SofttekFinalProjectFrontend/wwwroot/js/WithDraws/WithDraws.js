var token = getCookie("Token");
var id = getCookie("Id");

function SendWithDrawFiduciary() {

    var postData = {
        UserId: id
    };


    $.ajax({
        type: "POST",
        url: "/WithDraws/WithDrawsFiduciaryPartial",
        data: JSON.stringify(postData),
        contentType: 'application/json',
        dataType: "html",
        success: function (result) {
            $('#withDrawFiduciaryPartial').html(result);
            $('#withDrawFiduciaryModal').modal('show');
        }
    });
}

$("#withDrawFiduciaryButton").click(function () {
    SendWithDrawFiduciary();
});

function SendWithDrawCrypto() {

    var postData = {
        UserId: id
    };

    console.log(postData);

    $.ajax({
        type: "POST",
        url: "/WithDraws/WithDrawsCryptoPartial",
        data: JSON.stringify(postData),
        contentType: 'application/json',
        dataType: "html",
        success: function (result) {
            $('#withDrawCryptoPartial').html(result);
            $('#withDrawCryptoModal').modal('show');
        }
    });
}

$("#withDrawCryptoButton").click(function () {
    SendWithDrawCrypto();
});



$(document).ready(function () {
    $('#userIdHidden').val(id);
});