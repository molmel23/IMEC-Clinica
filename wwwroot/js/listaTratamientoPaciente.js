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
            "url": "/Usuario/Expediente/GetTratamientos/" + pacienteId,
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.data;
            }
        },
        "columns": [
            { "data": "tratamiento.nombre", "width": "35%" },
            { "data": "tratamiento.descripcion", "width": "35%" },
            { "data": "medicoTratante.nombreCompleto", "width": "25%" }
        ],
        "order": [[0, 'asc']]
    });
}
