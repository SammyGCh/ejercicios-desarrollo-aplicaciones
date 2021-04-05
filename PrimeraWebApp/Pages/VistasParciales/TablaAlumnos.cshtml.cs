using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System.Text.Json;
using System.Text;
using PrimeraWebApp.Logic;


namespace PrimeraWebApp.Pages.VistasParciales
{
    public class TablaAlumnosModel : PageModel
    {
        [ViewData]
        public List<Models.Alumno> ListaAlumnos { get; set; }

        public void OnGet()
        {
            CargarModelo();
        }

        private void CargarModelo()
        {
            // byte []arr;
            // HttpContext.Session.TryGetValue("alumnos", out arr);
            // string cad = "";

            // if(arr == null) 
            // {
                
            //     ListaAlumnos = Alumnos.Cargar();

            //     cad = JsonSerializer.Serialize(ListaAlumnos);
            //     HttpContext.Session.Set("alumnos", Encoding.UTF8.GetBytes(cad));
            // }
            // else
            // {
            //     cad = Encoding.UTF8.GetString(arr);
            //     ListaAlumnos = JsonSerializer.Deserialize<List<Models.Alumno>>(cad);
            // }
            string cad = "";

            var ListaAlumnos = Alumnos.CargarDB();

            cad = JsonSerializer.Serialize(ListaAlumnos);
            HttpContext.Session.Set("alumnos", Encoding.UTF8.GetBytes(cad));
        }
    }
}