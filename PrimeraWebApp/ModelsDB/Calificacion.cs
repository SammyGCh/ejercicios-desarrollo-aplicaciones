using System;
using System.Collections.Generic;

#nullable disable

namespace PrimeraWebApp.ModelsDB
{
    public partial class Calificacion
    {
        public int Id { get; set; }
        public int? Idalumno { get; set; }
        public int? IdexperienciaEducativa { get; set; }
        public int? Valor { get; set; }
        public int? Oportunidad { get; set; }

        public virtual Alumno IdalumnoNavigation { get; set; }
    }
}
