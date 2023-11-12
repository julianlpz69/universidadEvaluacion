using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAsignatura : IGenericRepository<Asignatura>
    {
        Task<IEnumerable<Asignatura>> AsignaturasCuatrimestre1();
        Task<IEnumerable<Asignatura>> AsignaturasGrado();
        Task<IEnumerable<Asignatura>> SinProfe();
        
    }
}