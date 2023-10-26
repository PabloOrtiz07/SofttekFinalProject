var token = getCookie("Token");
var idUser = getCookie("Id");

var tableSale;

function initializeDataTable(url, tableId, columns) {
    if (tableSale) {
        // If the DataTable already exists, destroy it before reinitializing
        tableSale.destroy();
    }

    tableSale = new DataTable(tableId, {
        ajax: {
            url: url,
            dataSrc: "data.items",
            headers: { "Authorization": "Bearer " + token }
        },
        columns: columns
    });
}

var saleColumns = [
    { data: 'saleNumber', title: 'Sale Number' },
    { data: 'amount', title: 'Price' },
    { data: 'nameOfCrypto', title: 'Name Of Crypto' },
    {
        data: function (data) {
            var buttons =
                `<td>
                    <a href='javascript:CheckTheSale(${JSON.stringify(data.id)})'>
                        <i class="fa-solid fa-eye checkTheSale"></i>
                    </a>
                </td>` +
                `<td><a href='javascript:BuySale(${JSON.stringify(data.id)})'><i class="fas fa-shopping-cart"></i></a></td>`
            return buttons;
        }
    }
];

// Initial DataTable initialization
initializeDataTable('https://localhost:7172/api/Sales?parameter=0&pageSize=10&pageToShow=1', '#tableSale', saleColumns);

function CheckTheSale(id) {
    $.ajax({
        type: "GET",
        url: `https://localhost:7172/api/Sales/${id}`,
        dataType: "json",
        success: function (data) {
            console.log("Received data:", data);

            $('#saleNumber').text(data.data.saleNumber);
            $('#amountSale').text(data.data.amount);
            $('#nameOfCryptoSale').text(data.data.nameOfCrypto);
            $('#saleModal').modal('show');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}

function BuySale(id) {
    Swal.fire({
        title: "Confirm Purchase",
        text: "Are you sure you want to make this purchase?",
        icon: "question",
        showCancelButton: true,
        confirmButtonText: "Yes",
        cancelButtonText: "No"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "PUT",
                url: `https://localhost:7172/api/Users/buy/${idUser}?saleNumber=${id}`,
                dataType: "json",
                headers: { "Authorization": "Bearer " + token },

                success: function (result) {
                    if (result.status == 200) {
                        toastr.success("The sale operation was successful");
                        window.location.href = "https://localhost:7800/Sales/Sales";
                    } else {
                        toastr.error("An error occurred while buying");
                    }
                },
                error: function (error) {
                    toastr.error("Error occurred while buying");
                }
            });
        }
    });
}

function Sale() {
    var postData = {
        UserId: idUser
    };
    $.ajax({
        type: "POST",
        url: "/Sales/SalesPartial",
        data: JSON.stringify(postData),
        contentType: 'application/json',
        dataType: "html",
        success: function (result) {
            $('#salePartial').html(result);
            $('#saleModalPartial').modal('show');
        }
    });
}

$("#sendSaleButton").click(function () {
    Sale();
});

$(document).ready(function () {
    $('#userIdHidden').val(idUser);
});
