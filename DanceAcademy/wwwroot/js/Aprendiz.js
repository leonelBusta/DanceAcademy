$(document).ready(function () {
    cargarDataTable();
});

var dataTable;

function cargarDataTable() {

    dataTable = $('#tableAprendiz').DataTable({
        "ajax": {
            "type": "GET",
            "datatype": "json",
            "url": "/Main/Aprendiz/Listar"
        },
        "columns": [
            { "data": "id" },
            { "data": "nombre" },
            { "data": "apPaterno" },
            { "data": "apMaterno" },
            { "data": "edad" },
            {
                "data": "urlFoto",
                "width": "25%",
                "render": function (data) {
                    return `<img src=/${data} alt="Image" width="200"/>`
                }
            },
            {
                "data": "id",
                "width": "25%",
                "render": function (data) {
                    return `<div class="text-center"><a class="btn btn-primary" href="/Main/Aprendiz/Edit/${data}">Editar</a> &nbsp; <a class="btn btn-danger text-white" style="cursor:pointer;" onclick= "Delete('/Main/Aprendiz/Eliminar/${data}')">Eliminar</a> </div>`

                }
            }
        ],
    });

}

function Delete(urlDestino) {
    swal({
        title: "Estas seguro de borrar el Aprendiz?",
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
