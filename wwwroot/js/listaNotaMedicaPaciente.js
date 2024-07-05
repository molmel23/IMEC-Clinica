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
            "url": "/Usuario/Expediente/GetNotasMedicas/" + pacienteId,
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.data;
            }
        },
        "columns": [
            { "data": "texto", "width": "35%" },
            { "data": "fecha", "width": "35%" },
            { "data": "medicoTratante.nombreCompleto", "width": "25%" }
        ],
        "order": [[1, 'asc']]
    });
}
