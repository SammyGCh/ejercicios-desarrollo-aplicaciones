using System;
using System.Linq;
using System.Collections.Generic;

namespace PrimeraWebApp.Logic
{
    public class Alumnos
    {
        private static List<Models.Alumno> listaAlumnos;

        public static List<Models.Alumno> Cargar()
        {
            listaAlumnos = new List<Models.Alumno>();
            listaAlumnos.Add(new Models.Alumno()
            {
                Id = 1,
                Matricula = "12345",
                Nombre = "Pancho Pantera",
                Fecha = DateTime.Parse("03/02/1960"),
                Domicilio = "Nestlé",
                Telefono = "5551801212",
                Sexo = 'H'
            });
            listaAlumnos.Add(new Models.Alumno()
            {
                Id = 2,
                Matricula = "3456789",
                Nombre = "El Conejo Quik",
                Fecha = DateTime.Parse("25/05/1970"),
                Domicilio = "Nestlé",
                Telefono = "5551801215",
                Sexo = 'H'
            });
            listaAlumnos.Add(new Models.Alumno()
            {
                Id = 3,
                Matricula = "8855659",
                Nombre = "Barbie",
                Fecha = DateTime.Parse("05/08/1975"),
                Domicilio = "Juguete",
                Telefono = "5554668989",
                Sexo = 'M'
            });
            listaAlumnos.Add(new Models.Alumno()
            {
                Id = 4,
                Matricula = "558896",
                Nombre = "El Osito Bimbo",
                Fecha = DateTime.Parse("25/08/1970"),
                Domicilio = "Bimbo",
                Telefono = "5551501215",
                Sexo = 'H'
            });

            return listaAlumnos;
        }

        public static List<ModelsDB.Alumno> CargarDB()
        {
            using (ModelsDB.alumnosContext dbContext = new ModelsDB.alumnosContext())
            {
                return dbContext.Alumnos.OrderBy(alumno => alumno.Nombre).ToList();
            }
        }

        public static void AgregarNuevoAlumno(List<Models.Alumno> listaAlumnos, Models.Alumno nuevoAlumno)
        {
            if (listaAlumnos.Count == 0)
            {
                nuevoAlumno.Id = 1;
            }
            else
            {
                nuevoAlumno.Id = listaAlumnos.Max(a => a.Id) + 1;
            }

            listaAlumnos.Add(nuevoAlumno);

        }

        public static void ActualizarAlumno(List<Models.Alumno> listaAlumnos, Models.Alumno alumnoModificado)
        {
            Models.Alumno alumnoAActualizar = listaAlumnos.FirstOrDefault(a => a.Id == alumnoModificado.Id);

            if (alumnoAActualizar is not null)
            {
                alumnoAActualizar.Matricula = alumnoModificado.Matricula;
                alumnoAActualizar.Nombre = alumnoModificado.Nombre;
                alumnoAActualizar.Domicilio = alumnoModificado.Domicilio;
                alumnoAActualizar.Fecha = alumnoModificado.Fecha;
                alumnoAActualizar.Telefono = alumnoModificado.Telefono;
                alumnoAActualizar.Sexo = alumnoModificado.Sexo;
            }
        }

        public static bool EliminarAlumno(List<Models.Alumno> listaAlumnos, int idAlumno)
        {
            bool eliminado = false;

            Models.Alumno alumnoAEliminar = listaAlumnos.FirstOrDefault(alumno => alumno.Id == idAlumno);

            if(alumnoAEliminar != null)
            {
                eliminado = listaAlumnos.Remove(alumnoAEliminar);
            }

            return eliminado;
        }

        public static void AgregarNuevoAlumnoDB(ModelsDB.Alumno alumno)
        {
            using (ModelsDB.alumnosContext dbContext = new ModelsDB.alumnosContext())
            {
                dbContext.Alumnos.Add(alumno);
                dbContext.SaveChanges();
            }
        }

        public static void ActualizarAlumnoDB(ModelsDB.Alumno alumnoModificado)
        {
            using (ModelsDB.alumnosContext dbContext = new ModelsDB.alumnosContext())
            {
                ModelsDB.Alumno alumno = dbContext.Alumnos.FirstOrDefault(a => a.Id == alumnoModificado.Id);

                if(alumno != null)
                {
                    dbContext.Update(alumnoModificado);
                    dbContext.SaveChanges();
                }
            }
        }

        public static bool EliminarAlumnoDB(int id)
        {
            bool eliminado = false;

            using (ModelsDB.alumnosContext dbContext = new ModelsDB.alumnosContext())
            {
                ModelsDB.Alumno alumnoBuscado = dbContext.Alumnos.FirstOrDefault(a => a.Id == id);

                if(alumnoBuscado != null)
                {
                    dbContext.Alumnos.Remove(alumnoBuscado);
                    dbContext.SaveChanges();
                    eliminado = true;
                }
                
            }
            

            return eliminado;
        }
    }
}