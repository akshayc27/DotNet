var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    $('#tblData').DataTable({
        ajax: {
            type: 'GET',
            dataType: 'JSON',
            url: '/Admin/Category/GetAll'
        },
        columns: [
            { 'data': 'id' },
            { 'data': 'name' }
        ]
    })
    
}