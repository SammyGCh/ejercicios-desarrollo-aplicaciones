using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeraWebApp.Models;

namespace PrimeraWebApp.Controllers
{
    public class OperacionesAritController : Controller
    {
        public string Index()
        {
            return "Hola mundo desde un servicio web";
        }
        
        public decimal Calcular(decimal operando1, decimal operando2, int operador = 1)
        {
            if (operador < 1 || operador > 4) 
            {
                operador = 1;
            }

            Operacion miOperacion = new Operacion{
                Operando1 = operando1,
                Operando2 = operando2,
                Operador = operador
            };
            return miOperacion.Ejecutar();
        }
    }
}
