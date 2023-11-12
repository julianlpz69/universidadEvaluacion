using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EstudiantesOrdenadosDto
    {
        public int Id {get; set;}
        public string Nif {get; set;}
        public DateOnly Fecha_Nacimiento {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string Nombre {get; set;}
        public string Telefono {get; set;}
        public RolDto Rol { get; set; }

    }
}