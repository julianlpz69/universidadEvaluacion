using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CursoEscolar : BaseEntity
    {
        public int Año_Incio {get; set;}
        public int Año_Fin {get; set;}
        public ICollection<Asignatura> Asignaturas { get; set; } = new HashSet<Asignatura>();
         public ICollection<Persona> Personas { get; set; } = new HashSet<Persona>();
        public ICollection<AlumnoMatriculaAsignatura> Alumno_Se_Matricula_Asignaturas {get; set;}
    }
}