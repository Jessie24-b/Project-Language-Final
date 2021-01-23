// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    //LlenarCombo();
    CargarCombo();
});

function LlenarCombo() {
    var combo = document.getElementById('ocupation-employed');

    var option = document.createElement("option");
    option.value = "Supervisor";
    option.text = "Supervisor"
    combo.appendChild(option);

    var option2 = document.createElement("option");
    option2.value = "Soportista";
    option2.text = "Soportista"
    combo.appendChild(option2);
}

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