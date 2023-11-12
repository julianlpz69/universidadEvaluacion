using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EstudianteSoloDto
    {
        public string Nombre {get; set;}
        public string Nif {get; set;}
        public ICollection<AsignaturasEstudianteSoloDto> Matriculas {get; set;}
    }
}