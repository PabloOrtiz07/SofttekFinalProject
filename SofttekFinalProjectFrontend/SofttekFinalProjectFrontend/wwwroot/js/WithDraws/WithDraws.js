var token = getCookie("Token");
var id = localStorage.getItem('Id');
console.log(id);

 function SendWithDrawFiduciary() {

        var postData = {
            UserId: id
     };

        console.log(postData);

        $.ajax({
            type: "POST",
            url: "/WithDraws/WithDrawsAddPartial",
            data: JSON.stringify(postData),
            contentType: 'application/json',
            dataType: "html",
            success: function (result) {
                $('#withDrawAddPartial').html(result);
                $('#withDrawModal').modal('show');
            }
        });
}

$("#withDrawFiduciaryButton").click(function () {
    SendWithDrawFiduciary();
});




$(document).ready(function () {
    var id = localStorage.getItem('Id');
    $('#userIdHidden').val(id); // Set the value of the hidden input field
});






