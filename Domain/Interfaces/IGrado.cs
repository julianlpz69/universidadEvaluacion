using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGrado : IGenericRepository<Grado> 
    {
        Task<IEnumerable<object>> NumeroGrados();
        Task<IEnumerable<object>> GradoMayor40();
        Task<IEnumerable<object>> SumaCreditosPorTipoAsignatura();
    }
}