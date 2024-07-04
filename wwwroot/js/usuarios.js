
var dataTable;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            "url": "/Admin/ListaUsuarios/GetAll",
            "type": "GET",
            "datatype": "json",
            "datasrc": "data"
        },
        "columns": [
            { "data": "identificacion", "width": "20%" },
            { "data": "nombreCompleto", "width": "20%" },
            {
                "data": "identificacion",
                "render": function (data) {
                    return `

                    <a href="/Admin/ListaUsuarios/Upsert/${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Editar
                            </a>

                    <a onClick=Delete(${data}) class="btn btn-danger mx-2">
                        <i class="bi bi-trash"></i> Delete
                    </a>
                  `
                }, "width": "35%"
            }
        ]

    });
}

function Delete(_id) {
    Swal.fire({
        title: "Esta seguro?",
        text: "No se puede revertir",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, borrar!"
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: "/Admin/ListaUsuarios/Delete/" + _id,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                },
                error: function () {
                    toastr.error("Error connecting to endpoint");
                }
            });
        }
    });
}