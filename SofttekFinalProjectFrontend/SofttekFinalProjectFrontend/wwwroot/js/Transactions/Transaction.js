var token = getCookie("Token");
var idUser = getCookie("Id");

function initializeDataTable(url, tableId, columns) {
    return new DataTable(tableId, {
        ajax: {
            url: url,
            dataSrc: "data.items",
            headers: { "Authorization": "Bearer " + token }
        },
        columns: columns
    });
}

const transactionsColumns = [
    { data: 'id', title: 'ID' },
    { data: 'descriptionOperation', title: 'Description Operation' },
    { data: 'amount', title: 'Amount' },
    {
        data: function (data) {
            var buttons =
                `<td>
                    <a href='javascript:CheckTheTransaction(${JSON.stringify(data.id)})'>
                        <i class="fa-solid fa-eye checkTheBalance"></i>
                    </a>
                </td>`
            return buttons;
        }
    }

];


let tableTransactions = initializeDataTable('https://localhost:7172/api/Transactions/' + idUser + '?parameter=0&pageSize=10&pageToShow=1', '#tableTransactions', transactionsColumns);

function CheckTheTransaction(id) {
    $.ajax({
        type: "GET",
        url: `https://localhost:7172/api/Transactions/GetTransaction/${id}`,
        dataType: "json",
        success: function (data) {
            console.log("Received data:", data.data);

            $('#descriptionOperation').text(data.data.descriptionOperation);
            $('#createdTimeUtc').text(data.data.createdTimeUtc);
            $('#amount').text(data.data.amount);

            $('#userModal').modal('show');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}










