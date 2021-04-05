using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeraWebApp.Models;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

namespace PrimeraWebApp.Controllers
{
    public class AlumnosServerController : Controller
    {
        public void Index()
        {
            
        }

        private void CargarModelo()
        {
            byte []arr;
            HttpContext.Session.TryGetValue("alumnos", out arr);
            string cad = "";

            if(arr == null) 
            {
                
                var ListaAlumnos = Logic.Alumnos.Cargar();

                cad = JsonSerializer.Serialize(ListaAlumnos);
                HttpContext.Session.Set("alumnos", Encoding.UTF8.GetBytes(cad));
            }
        }

        [HttpGet]
        public IActionResult ObtenerAlumnos()
        {
            // IActionResult resultado = null;
            // byte[] arr;
            // HttpContext.Session.TryGetValue("alumnos", out arr);
            // string cad = "";

            // if (arr == null)
            // {
            //     CargarModelo(); 
            // }

            // cad = Encoding.UTF8.GetString(arr);
            // var listaAlumnos = JsonSerializer.Deserialize<List<Models.Alumno>>(cad);
            var listaAlumnos = Logic.Alumnos.CargarDB();
            return new JsonResult(new {data=listaAlumnos});
        }
        
        [HttpPost]
        public IActionResult Guardar([FromBody] Alumno alumno)
        {
            bool estaGuardado = false;
            string mensaje = "";
            byte[] arr;
            HttpContext.Session.TryGetValue("alumnos", out arr);
            string cad = "";

            if (alumno != null && arr != null) 
            {
                cad = Encoding.UTF8.GetString(arr);
                var listaAlumnos = JsonSerializer.Deserialize<List<Models.Alumno>>(cad);

                if(alumno.Id == 0)
                {
                    Logic.Alumnos.AgregarNuevoAlumno(listaAlumnos, alumno);
                }
                else
                {
                    Logic.Alumnos.ActualizarAlumno(listaAlumnos, alumno);
                }


                cad = JsonSerializer.Serialize(listaAlumnos);
                HttpContext.Session.Set("alumnos", Encoding.UTF8.GetBytes(cad));

                try
                {
                    estaGuardado = true;
                    mensaje = "Sí se pudo";
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                mensaje = "Hubo un error en los datos enviados.";
            }
            

            return new JsonResult(new {guardado = estaGuardado, mensaje = mensaje});
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            bool seElimino = false;
            string mensaje = "";

            byte[] arr;
            HttpContext.Session.TryGetValue("alumnos", out arr);
            string cad = "";

            if(arr != null)
            {
                cad = Encoding.UTF8.GetString(arr);
                var listaAlumnos = JsonSerializer.Deserialize<List<Models.Alumno>>(cad);

                if(id != 3)
                {
                    seElimino = Logic.Alumnos.EliminarAlumno(listaAlumnos, id);
                }
            }
            return new JsonResult(new {eliminado = seElimino, mensaje = mensaje});
        }

        [HttpPost]
        public IActionResult GuardarDB([FromBody] ModelsDB.Alumno alumno)
        {
            bool estaGuardado = false;
            string mensaje = "";

            try
            {
                if(alumno != null)
                {
                    if (alumno.Id == 0)
                    {
                        Logic.Alumnos.AgregarNuevoAlumnoDB(alumno);
                    }
                    else
                    {
                        Logic.Alumnos.ActualizarAlumnoDB(alumno);
                    }

                    estaGuardado = true;
                    mensaje = "Sí se pudo";
                }
                else
                {
                    mensaje = "Hubo un error en los datos enviados.";
                }
            }
            catch(Exception)
            {
                mensaje = "Hubo un error en los datos enviados.";
            }

            return new JsonResult(new {guardado = estaGuardado, mensaje = mensaje});
        }

        [HttpPost]
        public IActionResult EliminarDB(int id)
        {
            bool seElimino = false;
            string mensaje = "";

            seElimino = Logic.Alumnos.EliminarAlumnoDB(id);
            return new JsonResult(new {eliminado = seElimino, mensaje = mensaje});
        }
    }
}
