// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    CargarCombo();
});

function CargarCombo() {
    var array = ["Supervisor", "Soportista", "prueba1", "prueba2", "prueba3", "prueba4"];
    var combo = document.getElementById('ocupation-employee');

    for (var i = 0; i < array.length; i++) {
        var option2 = document.createElement("option");
        option2.value = array[i];
        option2.text = array[i];
        combo.appendChild(option2);
    }

}



function Mostrar() {
    document.getElementById("login").classList.add("hide");
    document.getElementById("all-information").classList.remove("hide");
}

function InsertEmployeeInServices(mobile_Phone, landline, cable, internet) {



}

function InsertEmployee() {


    var employee = {
        employeeName: $('#name-employee').val(),
        employeeFirstName: $('#first-name-employee').val(),
        employeeSecondName: $('#second-name-employee').val(),
        employeeEmail: $('#email-employee').val(),
        employeePassword: $('#input-employee').val(),
        employeeOccupation: $('#ocupation-employee').val(),
        employeeSupervisor: 1,
        status: "iniciado",
        userCreation: 1,
        modificationUser: 1,
    };


    var mobile_Phone = document.getElementById('cbTelefonia-movil').checked;
    var landline = document.getElementById('cbTelefonia-fija').checked;
    var cable = document.getElementById('cbCable').checked;
    var internet = document.getElementById('cbInternet').checked;

  //  InsertEmployeeInServices(mobile_Phone, landline, cable, internet);



    var password_confirmation = document.getElementById('confirm-input-employee').value;

   // if (employee.password == password_confirmation) {

    $.ajax({
        url: "/Prueba/PostEmployee",
        data: JSON.stringify(employee),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
            success: function (result) { //aca recibo el resultado del backend (datos, objetos, mensajes, etc)

                //funcion para borrar los campos
                if (result == 1) {
                    //falta llemado de result. atributo password del objeto esto solo es una suposicion
                    if (password == result.password) {
                        Mostrar();
                    } else {
                        //mensaje de contraseña equivocada o usuario no existe
                    }

                }

            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    //} else {
        //confirmacion de contraseña incorrecta 
    //}
}





/*

function CheckLogin() {

    email = $('#email-login').value();
    password = $('#password-employee').value();

    $.ajax({
        url: "/Home/Metodo para obtener al employee por id(controlador)",
        data: { id: email },
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) { //aca recibo el resultado del backend (datos, objetos, mensajes, etc)

            //funcion para borrar los campos
            if (result == 1) {
                if (password == result.employeePassword) {
                    Mostrar();
                } else {
                    mensaje de contraseña equivocada o usuario no existe
                }

            }

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

  



function LoadRequestSupervisor() {
    $.ajax({
        url: "/Home/GetRequestSupervisor-metodo de controller que trae las solicitudes",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.reportId + '</td>';
                html += '<td>' + item.reportDescription + '</td>';
                html += '<td>' + item.reportDataTime + '</td>';
                html += '<td><a href="#"  onclick="ViewRequest(' + item.reportId + ')">View</a> </td>';
            });
            $('.tbody').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

    function GetModel(reportId)
    {
        var issus = GetIssus(reporId);
        var client = GetClient(issus.clientId);
        var comment = GetComment(reportId);
        var sopporter = GetSupporter();
        FillModel(issus, cliente, comment,sopporter);
    }


    function GetIssus(reportId)
    {
        $.ajax({
            url: "/Home/Metodo para obtener el reporte en controller",
            data: JSON.stringify(reportId),
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) { 


            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });

        return result;
    }

    function GetIssus(clientId) {

        $.ajax({
            url: "/Home/Metodo para obtener al cliente en la controller",
            data: JSON.stringify(clientId),
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {


            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });

        return result;
    }

function FillModel(issue, client, comment, supporter) {
    document.getElementById(' ').value = issue.reportId;
    document.getElementById(' ').value = client.name;
    document.getElementById(' ').value = issue.reportDescripcion;
    document.getElementById(' ').value = client.email;
    document.getElementById(' ').value = client.phone;
    document.getElementById(' ').value = client.secondPhone;
    document.getElementById(' ').value = issus.status;
   //combo box para asignar el soportista
    document.getElementById(' ').value = comment.description;
    document.getElementById(' ').value = client.
         
    }


function GetComment(reportId) {

    $.ajax({
        url: "/Home/Metodo para obtener el comentario del reporte",
        data: JSON.stringify(reportId),
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {


        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

    return result;

}

function GetSupporter() {

    $.ajax({
        url: "/Home/Metodo para extraer a todos los soportistas",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

    return result;

}


function AssignReport() {
    var modelcomboAssign = document.getElementById('');
    var modelReporId = document.getElementById('');
    var model
}

function LoadRequestSupporter(idSupporter) {
    $.ajax({
        url: "/Home/GetRequestSopporter",
        data: JSON.stringify(reportId),
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.reportId + '</td>';
                html += '<td>' + item.reportClasification + '</td>';
                html += '<td>' + item.reportDataTime + '</td>';
                html += '<td><a href="#"  onclick="ViewRequest(' + item.reportId + ')">View</a> </td>';
            });
            $('.tbody').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })
}

*/