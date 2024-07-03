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
            "url": "/Medicina/Paciente/GetNotasMedicas/" + pacienteId,
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.data;
            }
        },
        "columns": [
            { "data": "texto", "width": "35%" },  
            { "data": "fecha", "width": "35%" }, 
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
        "order": [[1, 'asc']]
    });
}
