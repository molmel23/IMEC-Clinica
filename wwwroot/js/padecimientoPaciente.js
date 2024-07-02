var dataTable;

$(document).ready(function () {
    var pacienteId = $('#pacienteId').val(); // Obtener el ID del paciente del campo oculto
    if (pacienteId) {
        loadDataTable(pacienteId);
    } else {
        console.error("Paciente ID no encontrado en el campo oculto");
    }
});

function loadDataTable(pacienteId) {
    dataTable = $('#tblData').DataTable({
        ajax: {
            "url": "/Medicina/Paciente/GetPadecimientos/" + pacienteId,
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.data;
            }
        },
        "columns": [
            { "data": "padecimiento.nombre", "width": "35%" },
            { "data": "padecimiento.descripcion", "width": "35%" },
            { "data": "medicoTratante.nombreCompleto", "width": "25%" },
            {
                "data": "id", "width": "5%",
                "render": function (data) {
                    return `
                        <a onClick=Delete(${data}) class="btn btn-danger mx-2">
                            <i class="bi bi-trash"></i> Suspender
                        </a>
                    `;
                },
                "orderable": false
            }
        ],
        "order": [[0, 'asc']]
    });
}

function Delete(_id) {
    Swal.fire({
        title: "¿Está seguro?",
        text: "No se puede revertir",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sí, suspender!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Medicina/Paciente/SuspenderPadecimiento/" + _id,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
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
