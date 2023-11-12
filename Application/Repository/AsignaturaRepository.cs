
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
    {
         private readonly UniversidadContext _context;

        public AsignaturaRepository(UniversidadContext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Asignatura>> AsignaturasCuatrimestre1()
        {
            var asignatura = await _context.Asignaturas
            .Where(e=> e.Cuatrimestre ==1 && e.Curso == 3 && e.Grado.Id == 7)
            .Include(e=> e.Grado)
            .Include(e => e.TipoAsignatura)
            .ToListAsync();

            return asignatura;
        }



        public async Task<IEnumerable<Asignatura>> AsignaturasGrado()
        {
            var asignaturas = await _context.Asignaturas
            .Where(e=> e.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)")
            .Include(e=> e.Grado)
            .Include(e => e.TipoAsignatura)
            .ToListAsync();

            return asignaturas;
        }


        public async Task<IEnumerable<Asignatura>> SinProfe()
        {
            var Asignaturas = await _context.Asignaturas
                .Where(d => d.Id_Profesor == null)
                .Include(u => u.Grado)
                .Include(u => u.TipoAsignatura)
                .ToListAsync();

            return Asignaturas;
        }
    }
}