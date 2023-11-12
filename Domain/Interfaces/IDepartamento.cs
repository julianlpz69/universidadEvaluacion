using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDepartamento : IGenericRepository<Departamento>
    {
        Task<IEnumerable<Departamento>> DepartamentosGrado();
        Task<IEnumerable<Departamento>> DepartamentosSinProfesores();
        Task<IEnumerable<object>> NumeroProfesDep();
        Task<IEnumerable<object>> NumeroProfesDep2();
        Task<IEnumerable<Departamento>> DepartamentosSinAsignaturas();
        Task<IEnumerable<object>> AsignaturasSinImpartir();
    }
}