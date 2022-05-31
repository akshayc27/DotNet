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
            { 'data': 'name' },
            {
             
                "data": "id",
              
                "render": function (data) {
                    return `<a href="Admin/Category/Upsert/${data}" class="editUser">Edit</a>`;
                }
            }
           
        ]
    })
    
}