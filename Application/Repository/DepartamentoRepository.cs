using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
         private readonly UniversidadContext _context;

        public DepartamentoRepository(UniversidadContext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Departamento>> DepartamentosGrado()
        {
            var departamentos = await _context.Departamentos
                .Where(d => d.Profesores.Any(p => p.Asignaturas.Any(m => m.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")))
                .ToListAsync();
            return departamentos;
        }


        public async Task<IEnumerable<Departamento>> DepartamentosSinProfesores()
        {
            var departamentosSinProfesores = await _context.Departamentos
                .Where(d => d.Profesores.Count == 0)
                .ToListAsync();

            return departamentosSinProfesores;
        }

        public async Task<IEnumerable<object>> AsignaturasSinImpartir()
        {
            var asignaturasNoImpartidas = await _context.Asignaturas
            .Where(a => !a.Alumno_Se_Matricula_Asignaturas.Any())
            .ToListAsync();

            var departamentosConAsignaturas = asignaturasNoImpartidas
                .GroupBy(a => a.Id_Grado)
                .Join(_context.Departamentos,
                    a => a.Key,
                    d => d.Id,
                    (a, d) => new
                    {
                        NombreDepartamento = d.Nombre,
                        NombreAsignatura = a.Select(x => x.Nombre)
                    }).ToList();
            

            return departamentosConAsignaturas;
        }


        public async Task<IEnumerable<object>> NumeroProfesDep()
        {
            var resultado = await _context.Departamentos
                .Where(d => d.Profesores.Any())
                .Select(d => new
                {
                    NombreDepartamento = d.Nombre,
                    CantidadProfesores = d.Profesores.Count()
                })
                .OrderByDescending(r => r.CantidadProfesores)
                .ToListAsync();

            return resultado;
        }



        public async Task<IEnumerable<object>> NumeroProfesDep2()
        {
            var resultado = await _context.Departamentos
                .GroupJoin(
                    _context.Profesors,
                    d => d.Id, 
                    p => p.Id_Departamento, 
                    (departamento, profesores) => new
                    {
                        NombreDepartamento = departamento.Nombre,
                        CantidadProfesores = profesores.Count()
                    }
                )
                .ToListAsync();

            return resultado;
        }


        public async Task<IEnumerable<Departamento>> DepartamentosSinAsignaturas()
        {
            var departamentosSinAsignaturas = await _context.Departamentos
                .Where(d => !d.Profesores.Any(p => p.Asignaturas.Any(a => a.Alumno_Se_Matricula_Asignaturas.Any())))
                .ToListAsync();

            return departamentosSinAsignaturas;
}
    }
}