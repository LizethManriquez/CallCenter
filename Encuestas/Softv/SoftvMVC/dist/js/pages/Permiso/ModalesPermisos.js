function agregar() {
    $('#ModalAgregarPermiso').modal('show');
}

function enviar_permiso() {

    if (document.getElementById('OptAdd').checked) { var a = true } else { var a = false }
    if (document.getElementById('OptSelect').checked) { var s = true } else { var s = false }
    if (document.getElementById('OptDelete').checked) { var d = true } else { var d = false }
    if (document.getElementById('OptUpdate').checked) { var u = true } else { var u = false }


    var objPermiso = {};

    objPermiso.IdRol = $('#IdRol').val();
    objPermiso.IdModule = $('#IdModule').val();
    objPermiso.OptAdd = a;
    objPermiso.OptSelect = s;
    objPermiso.OptDelete = d;
    objPermiso.OptUpdate = u;


    if (objPermiso.IdRol == "") {
        swal("Por favor seleccione un Rol", "", "error");
    }
    else if (objPermiso.IdModule == "") {
        swal("Por favor seleccione un Modulo", "", "error");
    }
    else {
        $.ajax({
            url: "/Permiso/Create/",
            type: "POST",
            data: { 'objPermiso': objPermiso },
            success: function (data, textStatus, jqXHR) {
                swal({
                    title: "!Hecho!", text: "Permiso agregado con éxito!",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonColor: "#5cb85c",
                    confirmButtonText: "Aceptar",
                    cancelButtonText: "Aceptar",
                    closeOnConfirm: false,
                    closeOnCancel: false
                }, function (isConfirm) {
                    location.reload();
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {

            }
        });
    }
}


function editar_role() {

    //$('.editar_permiso').val(data.getAttribute('data-name'));
    //$('.editar_permiso2').val(data.getAttribute('data-name2'));
    //$('.editar_permiso3').val(data.getAttribute('data-name3'));

    $('#ModalEditarPermiso').modal('show');
}

//function enviar_editar_role() {
//    var NuevoRolNombre = $('.editar_role').val();
//    var NuevoRolDescripcion = $('.editar_role2').val();
//    var NuevoRolEstado = true;
//    var IdRol = $('.editar_role').attr('id');

//    var objRole = {};
//    objRole.Nombre = NuevoRolNombre;
//    objRole.Descripcion = NuevoRolDescripcion;
//    objRole.Estado = NuevoRolEstado;
//    objRole.IdRol = IdRol;
//    if (NuevoRolNombre == "") {
//        swal("Por favor introduce un nombre para el Rol", "", "error");
//    }
//    if (NuevoRolDescripcion == "") {
//        swal("Por favor introduce una descripción para el Rol", "", "error");
//    }
//    else {
//        $.ajax({
//            url: "/Role/Edit/",
//            type: "POST",
//            data: { 'objRole': objRole },
//            success: function (data, textStatus, jqXHR) {
//                swal({
//                    title: "!Hecho!", text: "Rol editado con éxito!",
//                    type: "success",
//                    showCancelButton: false,
//                    confirmButtonColor: "#5cb85c",
//                    confirmButtonText: "Aceptar",
//                    cancelButtonText: "Aceptar",
//                    closeOnConfirm: false,
//                    closeOnCancel: false
//                }, function (isConfirm) {
//                    location.reload();
//                });
//            },
//            error: function (jqXHR, textStatus, errorThrown) {

//            }
//        });
//    }
//}

