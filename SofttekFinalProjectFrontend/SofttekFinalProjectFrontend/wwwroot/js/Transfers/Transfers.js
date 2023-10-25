var token = getCookie("Token");
var id = localStorage.getItem('Id');
console.log(id);

 function SendDepositFiduciary() {

        var postData = {
            UserId: id
     };

        $.ajax({
            type: "POST",
            url: "/Transfers/TransfersAddPartial",
            data: JSON.stringify(postData),
            contentType: 'application/json',
            dataType: "html",
            success: function (result) {
                $('#transfersAddPartial').html(result);
                $('#transfersModal').modal('show');
            }
        });
}

$("#transfersFiduciaryButton").click(function () {
    SendDepositFiduciary();
});

$(document).ready(function () {
    var id = localStorage.getItem('Id');
    $('#userIdHidden').val(id); // Set the value of the hidden input field
});






