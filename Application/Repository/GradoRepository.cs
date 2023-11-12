using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class GradoRepository : GenericRepository<Grado>, IGrado
    {
         private readonly UniversidadContext _context;

        public GradoRepository(UniversidadContext context):base(context)
        {
            _context = context;
        }



        public async Task<IEnumerable<object>> NumeroGrados()
        {
            var resultado = await _context.Grados
                .GroupJoin(
                    _context.Asignaturas,
                    g => g.Id, // 
                    a => a.Id_Grado, 
                    (grado, asignaturas) => new
                    {
                        NombreGrado = grado.Nombre,
                        CantidadAsignaturas = asignaturas.Count()
                    }
                )
                .OrderByDescending(r => r.CantidadAsignaturas)
                .ToListAsync();

            return resultado;
        }



        public async Task<IEnumerable<object>> GradoMayor40()
        {
            var resultado = await _context.Grados
                .Where(g => g.Asignaturas.Count > 40)
                .Select(g => new
                {
                    NombreGrado = g.Nombre,
                    CantidadAsignaturas = g.Asignaturas.Count
                })
                .OrderByDescending(r => r.CantidadAsignaturas)
                .ToListAsync();

            return resultado;
        }



        public async Task<IEnumerable<object>> SumaCreditosPorTipoAsignatura()
        {
            var resultado = await _context.Asignaturas
                .Include(a => a.Grado)
                .Include(a => a.TipoAsignatura)
                .GroupBy(a => new { NombreGrado = a.Grado.Nombre, TipoAsignatura = a.TipoAsignatura.Nombre })
                .Select(grupo => new
                {
                    NombreGrado = grupo.Key.NombreGrado,
                    TipoAsignatura = grupo.Key.TipoAsignatura,
                    SumaCreditos = grupo.Sum(a => a.Creditos)
                })
                .OrderByDescending(r => r.SumaCreditos)
                .ToListAsync();

            return resultado;
        }
    }
}