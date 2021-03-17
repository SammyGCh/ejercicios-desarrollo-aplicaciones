using System;

namespace PrimeraWebApp.Models {
    public class Alumno
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }

        public Char Sexo { get; set; }
    }
}