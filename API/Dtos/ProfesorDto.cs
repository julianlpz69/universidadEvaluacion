using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProfesorDto
    {
        public int Id {get; set;}
        public DepartamentoDto Departamento {get; set;}
        public PersonaDto Persona {get; set;}
        
        public ICollection<AsignaturaDto> Asignaturas {get; set;}
    }
}