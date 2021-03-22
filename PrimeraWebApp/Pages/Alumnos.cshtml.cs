using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;


namespace PrimeraWebApp.Pages
{
    public class AlumnosModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Matricula { get; set; }

        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public string Domicilio { get; set; }

        [BindProperty]
        public string Telefono { get; set; }

        [BindProperty]
        public DateTime Fecha { get; set; }

        [BindProperty]
        public Char Sexo { get; set; }

        [ViewData]
        public List<Models.Alumno> ListaAlumnos { get; set;}

        public void OnGet()
        {
            CargarModelo();
        }

        public ActionResult OnPost()
        {
            CargarModelo();

            if(ModelState.IsValid)
            {
                if (Id == 0) 
                {
                    AgregarNuevoAlumno();
                }
                else
                {
                    ActualizarAlumno();
                }
            }

            Thread.Sleep(2000);
            return Page();
        }

        private void CargarModelo()
        {
            ListaAlumnos = new List<Models.Alumno>();
            ListaAlumnos.Add(new Models.Alumno()
            {
                Id = 1,
                Matricula = "12345",
                Nombre = "Pancho Pantera",
                Fecha = DateTime.Parse("03/02/1960"),
                Domicilio = "Nestlé",
                Telefono = "5551801212",
                Sexo = 'H'
            });
            ListaAlumnos.Add(new Models.Alumno()
            {
                Id = 2,
                Matricula = "3456789",
                Nombre = "El Conejo Quik",
                Fecha = DateTime.Parse("25/05/1970"),
                Domicilio = "Nestlé",
                Telefono = "5551801215",
                Sexo = 'H'
            });
            ListaAlumnos.Add(new Models.Alumno()
            {
                Id = 3,
                Matricula = "8855659",
                Nombre = "Barbie",
                Fecha = DateTime.Parse("05/08/1975"),
                Domicilio = "Juguete",
                Telefono = "5554668989",
                Sexo = 'M'
            });
            ListaAlumnos.Add(new Models.Alumno()
            {
                Id = 4,
                Matricula = "558896",
                Nombre = "El Osito Bimbo",
                Fecha = DateTime.Parse("25/08/1970"),
                Domicilio = "Bimbo",
                Telefono = "5551501215",
                Sexo = 'H'
            });
        }

        private void AgregarNuevoAlumno()
        {
            if(ListaAlumnos.Count == 0)
            {
                Id = 1;
            }
            else
            {
                Id = ListaAlumnos.Max(a => a.Id) + 1;
            }

            ListaAlumnos.Add(new Models.Alumno()
            {
                Id = Id,
                Matricula = Matricula,
                Nombre = Nombre,
                Fecha = Fecha,
                Domicilio = Domicilio,
                Telefono = Telefono,
                Sexo = Sexo
            });
        }

        private void ActualizarAlumno()
        {
            Models.Alumno alumnoAActualizar = ListaAlumnos.FirstOrDefault(a => a.Id == Id);

            if (alumnoAActualizar is not null) 
            {
                alumnoAActualizar.Matricula = Matricula;
                alumnoAActualizar.Nombre = Nombre;
                alumnoAActualizar.Domicilio = Domicilio;
                alumnoAActualizar.Fecha = Fecha;
                alumnoAActualizar.Telefono = Telefono;
                alumnoAActualizar.Sexo = Sexo;
            }
        }
    }
}