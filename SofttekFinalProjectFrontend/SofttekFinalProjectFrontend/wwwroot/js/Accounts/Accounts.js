var token = getCookie("Token");
var id = getCookie("Id");
console.log(token)
function initializeDataTable(url, tableId, columns) {
    return new DataTable(tableId, {
        ajax: {
            url: url,
            dataSrc: "data.items",
            headers: {
                "Authorization": "Bearer " + token
            }
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
                    <a href='javascript:CheckTheBalanceFiduciary(${JSON.stringify(data.cbu)})'>
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
    { data: 'typeOfAccount', title: 'Type of Account' },
    {
        data: function (data) {
            var buttons =
                `<td>
                    <a href='javascript:CheckTheBalanceCrypto(${JSON.stringify(data.uuid)})'>
                        <i class="fa-solid fa-eye checkTheBalance"></i>
                    </a>
                </td>`
            return buttons;
        }
    }
];

var tableFiduciary = initializeDataTable('https://localhost:7172/api/Accounts/' + id + '?parameter=0&pageSize=10&pageToShow=1', '#tableFiduciary', fiduciaryColumns);
var tableCrypto = initializeDataTable('https://localhost:7172/api/Accounts/' + id + '?parameter=1&pageSize=10&pageToShow=1', '#tableCrypto', cryptoColumns);

function CheckTheBalanceFiduciary(cbu) {
    $.ajax({
        type: "GET",
        url: "https://localhost:7172/api/Accounts?name=" + cbu + "&parameter=0",
        dataType: "json",
        headers: {
            "Authorization": "Bearer " + token
        },
        success: function (data) {
            console.log("Received data:", data);

            $('#cbu').text(data.data.cbu);
            $('#alias').text(data.data.alias);
            $('#accountNumber').text(data.data.accountNumber);
            $('#amount').text(data.data.amount);
            var typeOfAccount = data.data.typeOfAccount;

            var textToDisplay = '';
            if (typeOfAccount === 0) {
                textToDisplay = 'Pesos';
            } else if (typeOfAccount === 1) {
                textToDisplay = 'Dollar';
            } else if (typeOfAccount === 2) {
                textToDisplay = 'Crypto';
            }
            $('#typeOfAccount').text(textToDisplay);
            $('#userModalFiduciary').modal('show');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}

function CheckTheBalanceCrypto(uuid) {
    $.ajax({
        type: "GET",
        url: "https://localhost:7172/api/Accounts?name=" + uuid + "&parameter=1",
        dataType: "json",
        headers: {
            "Authorization": "Bearer " + token
        },
        success: function (data) {
            console.log("Received data:", data);

            $('#uuid').text(data.data.uuid);
            $('#nameOfCrypto').text(data.data.nameOfCrypto);
            $('#amountCrypto').text(data.data.amount);
            var typeOfAccount = data.data.typeOfAccount;

            var textToDisplay = '';
            if (typeOfAccount === 0) {
                textToDisplay = 'Pesos';
            } else if (typeOfAccount === 1) {
                textToDisplay = 'Dollar';
            } else if (typeOfAccount === 2) {
                textToDisplay = 'Crypto';
            }
            $('#typeOfAccountCrypto').text(textToDisplay);
            $('#userModalCrypto').modal('show');
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}
