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
    { data: 'amount', title: 'Amount' }
];

const cryptoColumns = [
    { data: 'uuid', title: 'UUID' },
    { data: 'nameOfCrypto', title: 'Crypto Name' },
    { data: 'amount', title: 'Amount' },
    { data: 'typeOfAccount', title: 'Type of Account' },
];

let tableFiduciary = initializeDataTable('https://localhost:7172/api/Accounts/1?parameter=0&pageSize=10&pageToShow=1', '#tableFiduciary', fiduciaryColumns);
let tableCrypto = initializeDataTable('https://localhost:7172/api/Accounts/1?parameter=1&pageSize=10&pageToShow=1', '#tableCrypto', cryptoColumns);

