// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var employeeGlobal = null;
var issueGlobal = null;

$(document).ready(function () {
    LoadEmployees();
    LoadIssues();
    LoadMyIssues();
    ComboOfRegister();
});


function Mostrar() {

    var id = parseInt($('#e-id').val());

    $.ajax({
        url: "/Employee/GetEmployeeById",
        data: JSON.stringify(id),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            document.getElementById('e-name').value = result.employeeName;
            document.getElementById('e-email').value = result.employeeEmail;
            document.getElementById('e-ocupation').value = result.employeeOccupation;
            document.getElementById('e-supervisor').value = result.employeeSupervisor;

              if (result.employeeOccupation.toString() == 'Supervisor') {
                  document.getElementById("li-issue").classList.remove("hide");
                  document.getElementById("li-list-employees").classList.remove("hide");
                  document.getElementById("li-register-employee").classList.remove("hide");
                  document.getElementById("issues").classList.remove("hide");
                  document.getElementById("list-employees").classList.remove("hide");
                  document.getElementById("register-employee").classList.remove("hide");
              }


        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
    }


function Clear() {
    document.getElementById("email-login").value = '';
    document.getElementById("password-employee").value = '';
}

function ComboOfRegister() {

    var combo = document.getElementById('supervisor-employee');

    $("#supervisor-employee").find('option').remove();

    $.ajax({
        url: "/Employee/GetEmployees",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {


            $.each(result, function (key, item) {
                if (item.status == 'true' && item.employeeOccupation == 'Supervisor') {
                    var option = document.createElement("option");
                    option.value = item.employeeId;
                    option.text = item.employeeName;
                    combo.appendChild(option);
                }

            });
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}

function LoadEmployees() {
    $.ajax({
        url: "/Employee/GetEmployees",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {

                if (item.status == 'true') {
                    html += '<tr>';
                    html += '<td>' + item.employeeId + '</td>';
                    html += '<td>' + item.employeeName + '</td>';
                    html += '<td>' + item.employeeEmail + '</td>';
                    html += '<td>' + item.employeeOccupation + '</td>';
                    html += '<td>' + item.employeeSupervisor + '</td>';
                    html += '<td><a href="#students" onclick="return GetEmployeeById(' + item.employeeId + ')">Edit</a> | <a href="##list-employees" onclick="return DeleteEmployee(' + item.employeeId + ')">Delete</a></td>';
                }
               
            });
            $('.info-employees').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}

function InsertEmployee() {

    if (document.getElementById('cbTelefonia-movil').checked || document.getElementById('cbTelefonia-fija').checked ||
        document.getElementById('cbCable').checked || document.getElementById('cbInternet').checked) {

        if (document.getElementById('password2-employee').value == document.getElementById('confirm-password-employee').value) {

            var employee = {
                employeeName: $('#name-employee').val() + ' ' + $('#first-name-employee').val() + ' ' + $('#second-name-employee').val(),
                employeeEmail: $('#email-employee').val(),
                employeePassword: $('#password2-employee').val(),
                employeeOccupation: $('#ocupation-employee').val(),
                employeeSupervisor: parseInt(document.getElementById("supervisor-employee").value),
                status: "true",
                dateCreation: new Date(),
                modificationDate: new Date(),
                userCreation: parseInt($('#e-id').val()),
                modificationUser: parseInt($('#e-id').val()),
            };

            $.ajax({
                url: "/Employee/InsertEmployee",
                data: JSON.stringify(employee),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) { 



                    if (document.getElementById('cbTelefonia-movil').checked) {
                        InsertEmployeeInServices(result.employeeId, 1)
                    }
                    if (document.getElementById('cbTelefonia-fija').checked) {
                        InsertEmployeeInServices(result.employeeId, 2)
                    }
                    if (document.getElementById('cbCable').checked) {
                        InsertEmployeeInServices(result.employeeId, 3)
                    }
                    if (document.getElementById('cbInternet').checked) {
                        InsertEmployeeInServices(result.employeeId, 4)
                    }

                    if (result.employeeOccupation == 'Supervisor') {
                        ComboOfRegister();
                    }
                    LoadEmployees();
                },
                error: function (errorMessage) {
                    alert(errorMessage.responseText);
                }
            });


        } else {
            var con = 'contrasenia incorrecta';
        }

    } else {
        var ocu = 'no selecionada';
    }

}

function GetEmployeeById(employeeId) {

    $.ajax({
        url: "/Employee/GetEmployeeById",
        data: JSON.stringify(employeeId),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            employeeGlobal = result;

            document.getElementById('id-employee2').value = result.employeeId;
            document.getElementById('new-name').value = result.employeeName;
            document.getElementById('new-email').value = '' + result.employeeEmail;
            document.getElementById('new-supervisor').value = '' + result.employeeSupervisor;
            
            if (result.employeeOccupation == 'Supervisor') {
                document.getElementById("new-ocupation").selectedIndex = "0";
            } else {
                document.getElementById("new-ocupation").selectedIndex = "1";
            }

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}



function InsertEmployeeInServices(emId, serId) {

    var employeeService = {
        employeeId: emId,
        serviceId: serId,
        status: "true",
        dateCreation: new Date(),
        modificationDate: new Date(),
        userCreation: parseInt($('#e-id').val()),
        modificationUser: parseInt($('#e-id').val()),
    };

    $.ajax({
        url: "/EmployeeService/InsertEmployeeService",
        data: JSON.stringify(employeeService),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) { 

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

function EditEmployee() {

    var employee = {
        employeeId: employeeGlobal.employeeId,
        employeeName: $('#new-name').val(),
        employeeEmail: employeeGlobal.employeeEmail,
        employeePassword: employeeGlobal.employeePassword,
        employeeOccupation: $('#new-ocupation').val(),
        employeeSupervisor: parseInt($('#new-supervisor').val()),
        status: employeeGlobal.status,
        dateCreation: employeeGlobal.dateCreation,
        modificationDate: new Date(),
        userCreation: employeeGlobal.userCreation,
        modificationUser: parseInt($('#e-id').val()),
    };


        $.ajax({
            url: "/Employee/UpdateEmployeeById",
            data: JSON.stringify(employee),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) { 


                    
                document.getElementById('id-employee2').value = '';
                document.getElementById('new-name').value = '';
                document.getElementById('new-email').value = '';
                document.getElementById('new-supervisor').value = '';
                LoadEmployees();
                

            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
}

function DeleteEmployee(employeeId) {
    var employee = null;
    $.ajax({
        url: "/Employee/GetEmployeeById",
        data: JSON.stringify(employeeId),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            employee = result;

            employee.status = 'false';
            employee.modificationUser = parseInt($('#e-id').val());

            $.ajax({
                url: "/Employee/UpdateEmployeeById",
                data: JSON.stringify(employee),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result2) {
                    LoadEmployees();
                    ComboOfRegister();
                },
                error: function (errorMessage) {
                    alert(errorMessage.responseText);
                }
            });


        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}


            //----------------ISSUES--------------------
function LoadIssues() {
    $.ajax({
        url: "/Issue/GetIssues",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var service = ["Mobile Phone", "Landline", "Cable", "Internet"];
            $.each(result, function (key, item) {
                if (item.employeeId == null) {
                    html += '<tr>';
                    html += '<td>' + item.reportId + '</td>';
                    html += '<td>' + service[item.serviceId - 1] + '</td>';
                    html += '<td>' + item.reportDateTime + '</td>';
                    html += '<td><a href="#students" onclick="return Llamar(' + item.reportId + ')">To show</a> </td>';
                }

            });
            $('.info-issues').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

} 

function Llamar(id) {
    $('#myModal').modal('show');

    GetIssueById(id);
}

function GetIssueById(id) {

    $.ajax({
        url: "/Issue/GetIssueById",
        data: JSON.stringify(id),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) { //aca recibo el resultado del backend (datos, objetos, mensajes, etc)
            issueGlobal = result;
            document.getElementById('report-number').value = result.reportId;
            document.getElementById('register-timestamp').value = result.reportDateTime;
            document.getElementById('status').value = result.reportStatus;

            document.getElementById("classification").selectedIndex = "1";
            
            var service = ["Mobile Phone", "Landline", "Cable", "Internet"];
            document.getElementById('service').value = service[result.serviceId - 1];
            document.getElementById('notes').value = '';
            LoadEmployeesIncombo(result.serviceId);
           

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}


function LoadEmployeesIncombo(id) {

    var combo= document.getElementById('employee-in-charge');
    $("#employee-in-charge").find('option').not(':first').remove();
        $.ajax({
            url: "/EmployeeService/GetEmployeeServicesByIdService",
            data: JSON.stringify(id),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                $.each(result, function (key, item) {


                  $.ajax({
                      url: "/Employee/GetEmployeeById",
                      data: JSON.stringify(item.employeeId),
                      type: "POST",
                      contentType: "application/json;charset=utf-8",
                      dataType: "json",
                    success: function (result) {

                        

                        if (result.status == 'true') {
                            var option = document.createElement("option");
                            option.value = result.employeeId;
                            option.text = result.employeeName;
                                combo.appendChild(option);
                        }

                    },
                    error: function (errorMessage) {
                        alert(errorMessage.responseText);
                    }
                })


                });


            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        })

}

function ToAssign() {

    var issue = {
        reportId: parseInt(issueGlobal.reportId),
        reportClassification: $('#classification').val(),
        serviceId: parseInt(issueGlobal.serviceId),
        reportStatus: 'Assigned',
        reportDateTime: issueGlobal.reportDateTime,
        reportResolution: issueGlobal.reportResolution, 
        employeeId: parseInt(document.getElementById("employee-in-charge").value),
        status: issueGlobal.status,
        dateCreation: issueGlobal.dateCreation,
        modificationDate: new Date(),
        userCreation: parseInt(issueGlobal.userCreation),
        modificationUser: parseInt($('#e-id').val())
    };
    
    $.ajax({
        url: "/Issue/UpdateIssueById",
        data: JSON.stringify(issue),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            
            LoadIssues();
            RegisterNote(issue.reportId, issue.employeeId);
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

function RegisterNote(idIssue, idEmployee) {

    var note = {
        noteDescription: $('#notes').val(),
        noteTime: new Date(),
        employeeId: idEmployee,
        issueId: idIssue,

        status: "true",
        dateCreation: new Date(),
        modificationDate: new Date(),
        userCreation: parseInt($('#e-id').val()),
        modificationUser: parseInt($('#e-id').val()),
    }

    $.ajax({
        url: "/Note/InsertNote",
        data: JSON.stringify(note),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });


}

function Solve() {

    var issue = {
        reportId: parseInt(issueGlobal.reportId),
        reportClassification: $('#classification').val(),
        serviceId: parseInt(issueGlobal.serviceId),
        reportStatus: 'Assigned',
        reportDateTime: issueGlobal.reportDateTime,
        reportResolution: issueGlobal.reportResolution,
        employeeId: parseInt($('#e-id').val()),
        status: issueGlobal.status,
        dateCreation: issueGlobal.dateCreation,
        modificationDate: new Date(),
        userCreation: parseInt(issueGlobal.userCreation),
        modificationUser: parseInt($('#e-id').val())
    };

    $.ajax({
        url: "/Issue/UpdateIssueById",
        data: JSON.stringify(issue),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            LoadIssues();
            RegisterNote(issue.reportId, issue.employeeId);
            LoadMyIssues();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

 //----------------MY ISSUES--------------------
function LoadMyIssues() {

    $.ajax({
        url: "/Issue/GetIssues",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var service = ["Mobile Phone", "Landline", "Cable", "Internet"];
            $.each(result, function (key, item) {
                if (item.employeeId == parseInt($('#e-id').val())) {
                    html += '<tr>';
                    html += '<td>' + item.reportId + '</td>';
                    html += '<td>' + service[item.serviceId - 1] + '</td>';
                    html += '<td>' + item.reportDateTime + '</td>';
                    html += '<td><a href="#students" onclick="return MyIssues(' + item.reportId + ')">To show</a> </td>';
                }

            });
            $('.info-my-issues').html(html);

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    })

}

function MyIssues(id) {
    $('#myModalIssues').modal('show');

    GetMyIssueById(id);
}

function GetMyIssueById(id) {

    $.ajax({
        url: "/Issue/GetIssueById",
        data: JSON.stringify(id),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) { //aca recibo el resultado del backend (datos, objetos, mensajes, etc)
            issueGlobal = result;
            document.getElementById('report-number2').value = result.reportId;
            document.getElementById('register-timestamp2').value = result.reportDateTime;
            document.getElementById('status2').value = result.reportStatus;
            document.getElementById('resolution-comments2').value = result.reportResolution;

            if (result.reportClassification.toString() == 'Median') {
                document.getElementById("classification2").selectedIndex = "1";
            } else if (result.reportClassification.toString() == 'High') {
                document.getElementById("classification2").selectedIndex = "2";
            } else {
                document.getElementById("classification2").selectedIndex = "0";
            }
            var service = ["Mobile Phone", "Landline", "Cable", "Internet"];
            document.getElementById('service2').value = service[result.serviceId - 1];

            
            $.ajax({
                url: "/Note/GetNoteById",
                data: JSON.stringify(id),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {

                    document.getElementById('notes2').value = result.noteDescription;

                },
                error: function (errorMessage) {
                    alert(errorMessage.responseText);
                }
            });

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

function SolveMyIssues() {

    var issue = {
        reportId: parseInt(issueGlobal.reportId),
        reportClassification: $('#classification2').val(),
        serviceId: parseInt(issueGlobal.serviceId),
        reportStatus: $('#status2').val(),
        reportDateTime: issueGlobal.reportDateTime,
        reportResolution: $('#resolution-comments2').val(),
        employeeId: parseInt(issueGlobal.employeeId),
        status: issueGlobal.status,
        dateCreation: issueGlobal.dateCreation,
        modificationDate: new Date(),
        userCreation: parseInt(issueGlobal.userCreation),
        modificationUser: parseInt($('#e-id').val())
    };

    $.ajax({
        url: "/Issue/UpdateIssueById",
        data: JSON.stringify(issue),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            
            UpdateNote(issue.reportId);
            LoadMyIssues();
        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });

}

function UpdateNote(idIssue) {

    var note = null;
    
        $.ajax({
            url: "/Note/GetNoteById",
            data: JSON.stringify(idIssue),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                note = result;

                note.noteDescription = $('#notes2').val();
                note.modificationUser = parseInt($('#e-id').val());

                $.ajax({
                    url: "/note/UpdateNoteById",
                    data: JSON.stringify(note),
                    type: "POST",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (result2) {


                    },
                    error: function (errorMessage) {
                        alert(errorMessage.responseText);
                    }
                });


            },
            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });



}

