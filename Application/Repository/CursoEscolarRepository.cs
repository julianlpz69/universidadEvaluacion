using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolar
    {
         private readonly UniversidadContext _context;

        public CursoEscolarRepository(UniversidadContext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<object>> AlumnosMatriculadosPorCurso()
        {
            var resultado = await _context.CursoEscolars
                .Select(curso => new
                {
                    AnioInicio = curso.Año_Incio,
                    AlumnosMatriculados = curso.Alumno_Se_Matricula_Asignaturas.Count()
                })
                .ToListAsync();

            return resultado;
        }
        

    }
}