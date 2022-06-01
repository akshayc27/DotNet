var dataTable;

$(document).ready(function () {
    loadDataTable();
});


/*<input type='button' id='btnDelete' value='Delete' class='btn btn-danger' />*/

function loadDataTable() {

    $('#tblData').DataTable({
        ajax: {
            type: 'GET',
            dataType: 'JSON',
            url: '/Admin/Product/GetAll'
        },
        columns: [
            { 'data': 'title' },
            { 'data': 'isbn' },
            { 'data': 'price' },
            { 'data': 'author' },
            { 'data': 'category.name' },
            {
             
                "data": "id",
              
                "render": function (data) {
                    return `
  <a href="/Admin/Product/Upsert/${data}">Edit</a>
  <a href="/Admin/Product/Delete/${data}">Delete</a>
`;
                }
            }
           
        ]
    })
    
}


//function Delete(url) {

//    swal({
//        title: "Are you ssure you want to Delete",
//        text: "You will not be able to restore the data!",
//        icon: "warning"
        
//        dangerMode: true
//    }).then(
//        (willDelete) => {
//            if (willDelete) {
//                $.ajax({
//                    type: "DELETE",
//                    url: url,
//                    sucess: function (data) {
//                        if (data.sucess) {
//                            toastr.sucess(data.message);
//                            dataTable.ajax.reload();
//                        }
//                        else {
//                            toastr.error(data.message);
//                        }
//                    }
//                });
//            }
//        }
//    );
//}