var token = getCookie("Token");

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

const fiduciaryColumns = [
    { data: 'cbu', title: 'CBU' },
    { data: 'alias', title: 'Alias' },
    { data: 'accountNumber', title: 'Account Number' },
    { data: 'typeOfAccount', title: 'Type of Account' },
    {
        data: function (data) {
            var buttons =
                `<td>
                    <a href='javascript:CheckTheBalance(${JSON.stringify(data)})'>
                        <i class="fa-solid fa-eye checkTheBalance"></i>
                    </a>
                </td>`
            return buttons;
        }
    }

];



const cryptoColumns = [
    { data: 'uuid', title: 'UUID' },
    { data: 'nameOfCrypto', title: 'Crypto Name' },
    { data: 'typeOfAccount', title: 'Type of Account' }
];

let tableFiduciary = initializeDataTable('https://localhost:7172/api/Accounts/1?parameter=0&pageSize=10&pageToShow=1', '#tableFiduciary', fiduciaryColumns);
let tableCrypto = initializeDataTable('https://localhost:7172/api/Accounts/1?parameter=1&pageSize=10&pageToShow=1', '#tableCrypto', cryptoColumns);

function CheckTheBalance() {
    $.ajax({
        type: "GET",
        url: "https://localhost:7172/api/Accounts?Cbu=CBU1&parameter=0&pageSize=10&pageToShow=1",
        dataType: "json",
        success: function (data) {
            console.log("Received data:", data);

            // Update the modal content with the received data
            $('#cbu').text(data.data.cbu);
            $('#alias').text(data.data.alias);
            $('#accountNumber').text(data.data.accountNumber);
            $('#amount').text(data.data.amount);

            // Show the modal
            $('#userModal').modal('show');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}










