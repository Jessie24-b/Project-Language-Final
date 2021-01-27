// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    CargarCombo();
});

function CargarCombo() {
    var array = ["Supervisor", "Soportista"];
    var combo = document.getElementById('ocupation-employed');

    for (var i = 0; i < array.length; i++) {
        var option2 = document.createElement("option");
        option.value = array[i].ToString();
        option.text = array[i].ToString();
        combo.appendChild(option);
    }

}

function Mostrar() {
    document.getElementById("login").classList.add("hide");
    document.getElementById("all-information").classList.remove("hide");
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

    function InsertEmployee() 
    {


    var employee = {
     fullName = $('#name-employee').value(),
     firstName = $('#first-name-employee').value(),
     secondName = $('#second-name-employee').value(),
     email = $('#email-employee').value(),
     password = $('#input-employee').value(),
     ocupation = $('#input-employee').value(),
     supervisor = $('#supervisor-employee').value(),
     };

    password-confirmation = $('#confirm-input-employee').value();
    
        if (employee.password == password - confirmation) {

            $.ajax({
                url: "/Home/Metodo para insertar employee(controlador)",
                data: JSON.stringify(student),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) { //aca recibo el resultado del backend (datos, objetos, mensajes, etc)

                    //funcion para borrar los campos
                    if (result == 1) {
                        //falta llemado de result. atributo password del objeto esto solo es una suposicion
                        if (password == result.employeePassword) {
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
        } else {
            //confirmacion de contraseña incorrecta 
        }
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
        FillModel(issus, cliente);
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

function FillModel(issus, client) {
    document.getElementById(' ').value = client.
    document.getElementById(' ').value = client.
    document.getElementById(' ').value = client.
    document.getElementById(' ').value = client.
    document.getElementById(' ').value = client.
    document.getElementById(' ').value = client.
    document.getElementById(' ').value = client.
    document.getElementById(' ').value = client.
 // hacia abajo los del reporte hacia rriba los del cliente
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
    document.getElementById(' ').value = issus.
         
    }

function SolveReportSupervisor() {


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