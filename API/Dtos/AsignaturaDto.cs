using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AsignaturaDto
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public float Creditos {get; set;}
        public int  Curso {get; set;}
        public int Cuatrimestre {get; set;}
        public GradoDto Grado {get; set;}
        public TipoAsignaturaDto TipoAsignatura {get; set;}

    }
}