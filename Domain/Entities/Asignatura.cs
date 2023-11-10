using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Asignatura : BaseEntity
    {
        public string Nombre {get; set;}
        public float Creditos {get; set;}
        public enum Tipo
        {
            básica,
            obligatoria
        }

        public int  Curso {get; set;}
        public int Cuatrimestre {get; set;}
        public int Id_Profesor {get; set;}
        public Profesor Profesor {get; set;}
        public int Id_Grado {get; set;}
        public Grado Grado {get; set;}
        public ICollection<Persona> Personas { get; set; } = new HashSet<Persona>();
         public ICollection<CursoEscolar> CursoEscolars { get; set; } = new HashSet<CursoEscolar>();
        public ICollection<AlumnoMatriculaAsignatura> Alumno_Se_Matricula_Asignaturas {get; set;}

    }
}