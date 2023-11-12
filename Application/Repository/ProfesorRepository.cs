using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
    {
         private readonly UniversidadContext _context;

        public ProfesorRepository(UniversidadContext context):base(context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Profesor>> ProfesOrdenados()
        {
            var Profes = await _context.Profesors
                .Include(p => p.Persona)
                .Include(p => p.Departamento)
                .OrderBy(a => a.Persona.Apellido1)
                .ThenBy(a => a.Persona.Apellido2)
                .ThenBy(a => a.Persona.Nombre)
                .ToListAsync();
            return Profes;
        }


        public async Task<IEnumerable<object>> ProfesoresConDepartamentos()
        {
            var profesores = await _context.Profesors
                .Select(p => new
                {
                    NombreDepartamento = p.Departamento != null ? p.Departamento.Nombre : "Sin departamento",
                    PrimerApellido = p.Persona.Apellido1,
                    SegundoApellido = p.Persona.Apellido2,
                    Nombre = p.Persona.Nombre
                })
                .OrderBy(p => p.NombreDepartamento)
                .ThenBy(p => p.PrimerApellido)
                .ThenBy(p => p.SegundoApellido)
                .ThenBy(p => p.Nombre)
                .ToListAsync();

            return profesores;
        }


        public async Task<IEnumerable<Profesor>> SinAsignatura()
        {
            var Profes = await _context.Profesors
                .Where(d => d.Asignaturas.Count == 0)
                .Include(u => u.Persona)
                .ThenInclude(u => u.Rol)
                .ToListAsync();

            return Profes;
        }



        public async Task<IEnumerable<object>> AsignaturasXProfesor()
        {
            var resultado = await _context.Profesors
                .Select(profesor => new
                {
                    Id = profesor.Id,
                    Nombre = profesor.Persona.Nombre,
                    PrimerApellido = profesor.Persona.Apellido1,
                    SegundoApellido = profesor.Persona.Apellido2,
                    NumeroAsignaturas = profesor.Asignaturas.Count()
                })
                .OrderByDescending(r => r.NumeroAsignaturas)
                .ToListAsync();

            return resultado;
        }


        public async Task<IEnumerable<Profesor>> ProfesoresSinDepartamento()
        {
            var profesoresSinDepartamento = await _context.Profesors
                .Where(p => p.Departamento == null)
                .Include(P => P.Persona)
                .ToListAsync();

            return profesoresSinDepartamento;
        }


        public async Task<IEnumerable<Profesor>> ProfesConYSin()
        {
            var profesoresSinAsignaturas = await _context.Profesors
                .Where(p => p.Departamento != null && !p.Asignaturas.Any())
                .Include(p => p.Persona)
                .ToListAsync();

            return profesoresSinAsignaturas;
        }
    }
}