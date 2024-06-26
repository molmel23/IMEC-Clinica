var dataTable;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            "url": "/Medicina/Tratamiento/getall",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nombre", "width": "15%" },
            { "data": "descripcion", "width": "65%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <a href="/Medicina/Tratamiento/Upsert/${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>

                            <a onClick=Delete(${data}) class="btn btn-danger mx-2">
                                <i class="bi bi-trash"></i> Delete
                            </a>
                          `
                },
                "orderable": false
            }
        ],
        "order": [[1, 'asc']]  // Ordenar por la segunda columna (Nombre Completo) de forma ascendente
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
                url: "/Medicina/Tratamiento/delete/" + _id,
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