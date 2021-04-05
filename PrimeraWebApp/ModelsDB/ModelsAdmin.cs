using System;

namespace PrimeraWebApp.ModelsDB
{
    public partial class Alumno
    {
        public String NombreCompleto {
            get {
                var Fecha2 = $"{Fecha.Year}-{Fecha.Month:00}-{Fecha.Day:00}";
                return $"<a href=\"#\" onclick='mostrarDatos({Id}, \"{Matricula}\", \"{Nombre}\", \"{Domicilio}\", \"{Telefono}\", \"{Fecha2}\");'>{Nombre}</a>";
            }
        }
 
        public String Genero {
            get {
                return Sexo.Equals("H")?"Hombre":"Mujer";
            }
        }
        public String Eliminar {
            get {
                return $"<a href=\"#\" class=\"text-danger\" onclick=\"eliminarAlumno({Id}, '{Nombre}');\"><i class=\"far fa-trash-alt\"></i> Eliminar</a>";
            }        
        }
 
        public String SSexo {
            get {
                if (Sexo.Equals("H")) {
                    return "Hombre";    
                } else {
                    return "Mujer";    
                }
            }
        }
    }
    
}