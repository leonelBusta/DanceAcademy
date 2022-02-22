$(document).ready(function () {
    cargarDataTable();
});

var dataTable;

function cargarDataTable() {

    dataTable = $('#tableInstructores').DataTable({
        "ajax": {
            "type": "GET",
            "datatype": "json",
            "url": "/Main/Instructor/Listar"
        },
        "columns": [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "apPaterno" },
            { "data": "apMaterno" },
            {
                "data": "urlFoto",
                "render": function (data) {
                    return `<img src=/${data} alt="" width="100"/>`
                }
            },
            { "data": "codigoInstructor" },
            {
                "data": "id",
                "width": "25%",
                "render": function (data) {
                    return `<div class="text-center"><a class="btn btn-primary" href="/Main/Instructor/Edit/${data}">Editar</a> &nbsp; <a class="btn btn-danger text-white" style="cursor:pointer;" onclick= "Delete('/Main/Instructor/Eliminar/${data}')">Eliminar</a> </div>`

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

