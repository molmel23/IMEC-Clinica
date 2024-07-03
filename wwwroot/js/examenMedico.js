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
            "url": "/Medicina/Paciente/GetExamenes/" + pacienteId,
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.data;
            }
        },
        "columns": [
            { "data": "descripcion", "width": "35%" },
            { "data": "medicoTratante.nombreCompleto", "width": "25%" },
            {
                "data": "archivoURL",
                "render": function (data) {
                    return `
                        <a href="${data}" class="btn btn-success mx-2" target="_blank">
                            <i class="bi bi-eye"></i> Abrir
                        </a>`;
                },
                "orderable": false
            }
        ],
        "order": [[0, 'asc']]
    });
}