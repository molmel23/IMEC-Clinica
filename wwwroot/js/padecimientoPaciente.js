var dataTable;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        ajax: {
            "url": "/Medicina/Paciente/getpadecimientos",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "cedulaPaciente", "width": "35%" },
            { "data": "numeroColegiadoMedico", "width": "25%" },
            {
                "data": "id", "width": "35%",
                "render": function (data) {
                    return `
                            <a onClick=Delete(${data}) class="btn btn-danger mx-2">
                                <i class="bi bi-trash"></i> Eliminar
                            </a>
                          `
                },
                "orderable": false
            }
        ],
        "order": [[1, 'asc']]
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
                url: "/Medicina/Paciente/deletePaciente/" + _id,
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