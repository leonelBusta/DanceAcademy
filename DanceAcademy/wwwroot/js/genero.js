// consumir api
$(document).ready(function () {
    cargarDataTable();
});

var dataTable;

function cargarDataTable() {

    dataTable = $('#tablaGeneros').DataTable({
        "ajax": {
            "type": "POST",
            "datatype": "json",
            "url": "/Main/Genero/Listar"
        },
        "columns": [
            { "data": "id" },
            { "data": "tipo" },
            { "data": "descripcion" },
            {
                "data": "id",
                "width": "25%",
                "render": function (data) {
                    return `<div class="text-center"><a class="btn btn-primary" href="/Main/Genero/Edit/${data}">Editar</a> &nbsp; <a class="btn btn-danger text-white" style="cursor:pointer;" onclick= "Delete('/Main/Genero/Eliminar/${data}')">Eliminar</a> </div>`

                }
            }
        ],
    });

}

function Delete(urlDestino) {
    swal({
        title: "Estas seguro de borrar el instructor?",
        text: "esta accion no se puede revertir",
        type: "warning",
        showCancelButton: true,
        confirmButtom: "si, borrar",
        closeOnConfirm: true
    },
        function () {
            $.ajax({
                type: "DELETE",
                url: urlDestino,
                success: function (response) {
                    if (response.success == true) {
                        toastr.success(response.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(response.message);
                    }
                }
            });
        }
    );
}
