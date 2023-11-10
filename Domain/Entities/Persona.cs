using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona : BaseEntity
    {
        public string Nif {get; set;}
        public string Nombre {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string Ciudad {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public DateOnly Fecha_Nacimiento {get; set;}
        public Genero Sexo { get; set; }
        public Rol Tipo { get; set; }
        public enum Genero
        {
            H,
            M 
        }
        public enum Rol
        {
            alumno,
            profesor
        }
         public ICollection<Asignatura> Asignaturas { get; set; } = new HashSet<Asignatura>();
         public ICollection<CursoEscolar> CursoEscolars { get; set; } = new HashSet<CursoEscolar>();
        public ICollection<AlumnoMatriculaAsignatura> Alumno_Se_Matricula_Asignaturas {get; set;}
        public Profesor Profesor {get; set;}
    }

}