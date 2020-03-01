var dataTable = null; //Variable global para referenciar a las tablas de manera global para este Script

// Mostrar una barra de carga o un circulo de espera mientras se obtienen resultados AJAX
function showPreloader() {

}
function getHtmlData(uri) {
$("#parcialCreateUpdate").html(""); //Limpiar el contenido para evitar errores
    $.ajax({
        type: "GET",
        url: uri,
        success: function (data) {
            $("#parcialCreateUpdate").html(data);                    
        }
    });
}

function deleteSubmitForm(form) {
    $.ajax({
        type: "POST",
        url: form.action,
        data: $(form).serialize(),
        success: function (data) {
            if (data.success) {
                dataTable.ajax.reload();
                $("#modal-default .close").click(); //Ocultar modal
                //Notificacion("warning", data.message, "pe-7s-check");
            }
        },
        error: function (data) {
            alert(data.message);
            //Notificacion("danger", "Error: No se ha eliminado", "pe-7s-close");
        }
    });
    return false;
}


$form = null;
function SubmitForm(form) {
    $form = form;
    //Validar el formulario
    $.validator.unobtrusive.parse(form);
    //Enviar los datos en segundo plano
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $("#"+$form.id).trigger("reset"); //Limpiar Form
                    dataTable.ajax.reload(); //Actualizar la tabla.
                    $("#modal-default .close").click(); //Ocultar modal
                    //Notificacion("success", data.message, "pe-7s-check");
                }
                else {
                    //Notificacion("warning", data.message, "pe-7s-close");
                }
            }
        });
    }
    return false; //Retornamos false para evitar el redireccionamiento del POST
}

function Delete(url) {

    var formToken = $("#_AjaxToken"); // Token creado en Index
    var token = $('input[name="__RequestVerificationToken"]', formToken).val();
    if (confirm("Eliminar el registro?")) {
        $.ajax({
            type: "POST",
            url: url,
            data: {
                __RequestVerificationToken: token
            },
            success: function (data) {
                if (data.success) {
                    dataTable.ajax.reload();
                    alert(data.message);
                    //Notificacion("warning", data.message, "pe-7s-check");
                }
            },
            error: function (data) {
                alert(data.message);
                //Notificacion("danger", "Error: No se ha eliminado", "pe-7s-close");
            }

        });
    }
    else {
        //Notificacion("info", "Sin cambios", "pe-7s-smile");
    }
}