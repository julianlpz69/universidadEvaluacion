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
        public int IdGenero {get; set;}
        public Genero Genero {get; set;}
        public int IdRol {get; set;}
        public Rol Rol { get; set; }
        public ICollection<AlumnoMatriculaAsignatura> Alumno_Se_Matricula_Asignaturas {get; set;}
        public Profesor Profesor {get; set;}
    }

}