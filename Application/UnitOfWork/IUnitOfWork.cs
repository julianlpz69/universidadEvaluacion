using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        IAsignatura Asignaturas {get;}
        ICursoEscolar CursosEscolares {get;}
        IDepartamento Departamentos {get;}
        IGrado Grados {get;}
        IPersona Personas {get;}
        IProfesor Profesores {get;}
    }
}