$(function () {
    $("#realizarOperacion").click(function () {
        var operando1 = Number($("#operando1").val());
        var operando2 = Number($("#operando2").val());
        var operacion = $("#operador").val();

        $("#validacion_operando1").html("");
        if (operando1 == "") {
            $("#validacion_operando1").html("<li>El operando 1 no puede estar vacío</li>");
            $("#operando1").focus();
            return false;
        }
        if (isNaN(operando1)) {
            $("#validacion_operando1").html("<li>El operando 1 tiene un valor inválido</li>");
            $("#operando1").focus();
            return false;
        }

        $("#validacion_operando2").html("");
        if (operando2 == "") {
            $("#validacion_operando2").html("<li>El operando 2 no puede estar vacío</li>");
            $("#operando2").focus();
            return false;
        }

        var URL = "/OperacionesArit/Calcular?operando1="+operando1+"&operando2="+operando2+"&operador="+operacion;
        $.ajax({url: URL, success: function(data, status, xhr) {
            $("#resultado").val(data);
        }});

        return false;
    });
});

function OperacionJS() {
    $("#realizarOperacion").click(function () {
        var operando1 = Number($("#operando1").val());
        var operando2 = Number($("#operando2").val());
        var operacion = $("#operador").val();
        var resultado = 0;

        $("#validacion_operando1").html("");
        if (operando1 == "") {
            $("#validacion_operando1").html("<li>El operando 1 no puede estar vacío</li>");
            $("#operando1").focus();
            return false;
        }
        if (isNaN(operando1)) {
            $("#validacion_operando1").html("<li>El operando 1 tiene un valor inválido</li>");
            $("#operando1").focus();
            return false;
        }

        $("#validacion_operando2").html("");
        if (operando2 == "") {
            $("#validacion_operando2").html("<li>El operando 2 no puede estar vacío</li>");
            $("#operando2").focus();
            return false;
        }
        

        
        const SUMA = "1";
        const RESTA = "2";
        const MULTIPLICACION = "3";
        const DIVISION = "4";

        if (operacion == SUMA) {
            resultado = operando1 + operando2;
        }
        else if (operacion == RESTA) {
            resultado = operando1 - operando2;
        }
        else if (operacion == MULTIPLICACION) {
            resultado = operando1 * operando2;
        }
        else if (operacion == DIVISION) {
            resultado = operando1 / operando2;
        }

        $("#resultado").val(resultado);
        return false;
    });
}