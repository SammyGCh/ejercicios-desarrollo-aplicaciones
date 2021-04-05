using System;
using System.Collections.Generic;

#nullable disable

namespace PrimeraWebApp.ModelsDB
{
    public partial class Alumno
    {
        public Alumno()
        {
            Calificacions = new HashSet<Calificacion>();
        }

        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public byte[] Foto { get; set; }
        public string Sexo { get; set; }

        public virtual ICollection<Calificacion> Calificacions { get; set; }
    }
}
