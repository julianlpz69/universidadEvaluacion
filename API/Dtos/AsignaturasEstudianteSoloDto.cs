using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AsignaturasEstudianteSoloDto
    {
        public string NombreAsignatura {get; set;}
        public int Año_Incio {get; set;}
        public int Año_Fin {get; set;}
    }
}