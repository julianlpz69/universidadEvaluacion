using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersona : IGenericRepository<Persona>
    {
        Task<IEnumerable<Persona>> AlumnosOrdenados();
        Task<IEnumerable<Persona>> AlumnosSinTelefono();
        Task<IEnumerable<Persona>> Alumnos1999();
        Task<IEnumerable<Persona>> ProfesoresSinTelefono();
        Task<IEnumerable<Persona>> Womens();
        Task<IEnumerable<Persona>> AlumnoSolo();
        Task<IEnumerable<Persona>> Matriculado2018();
        Task<Object> CantidadAlumnas();
        Task<Object> AlumnosNacidos1999();
        Task<Persona> AlumnoMasJoven();
    
        
    }
}