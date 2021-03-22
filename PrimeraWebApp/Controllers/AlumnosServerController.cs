using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeraWebApp.Models;

namespace PrimeraWebApp.Controllers
{
    public class AlumnosServerController : Controller
    {
        public void Index()
        {
            
        }
        
        [HttpPost]
        public IActionResult Guardar([FromBody] Alumno alumno)
        {
            bool estaGuardado = false;
            string mensaje = "";

            try
            {
                estaGuardado = true;
                mensaje = "Sí se pudo";
            }
            catch(Exception ex) 
            {

            }

            return new JsonResult(new {guardado = estaGuardado, mensaje = mensaje});
        }
    }
}
