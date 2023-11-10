using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AlumnoMatriculaAsignatura
    {
        public int Id_Alumno {get; set;}
        public Persona Persona {get; set;}
        public int Id_Asignatura {get; set;}
        public Asignatura Asignatura {get; set;}
        public int ID_curso_escolar {get; set;}
        public CursoEscolar CursoEscolar {get; set;}
    }
}