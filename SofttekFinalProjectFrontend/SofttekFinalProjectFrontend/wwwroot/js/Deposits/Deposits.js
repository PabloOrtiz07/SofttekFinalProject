var token = getCookie("Token");
var id = localStorage.getItem('Id');
console.log(id);

 function SendDepositFiduciary() {

        var postData = {
            UserId: id
     };

        $.ajax({
            type: "POST",
            url: "/Deposits/DepositsAddPartial",
            data: JSON.stringify(postData),
            contentType: 'application/json',
            dataType: "html",
            success: function (result) {
                $('#depositsAddPartial').html(result);
                $('#depositsModal').modal('show');
            }
        });
}

$("#depositsFiduciaryButton").click(function () {
    SendDepositFiduciary();
});

$(document).ready(function () {
    var id = localStorage.getItem('Id');
    $('#userIdHidden').val(id); // Set the value of the hidden input field
});






