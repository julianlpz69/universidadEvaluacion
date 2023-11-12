using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
         private readonly UniversidadContext _context;

        public PersonaRepository(UniversidadContext context):base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Persona>> AlumnosOrdenados()
        {
            var Alumnos = await _context.Personas
                .Where(c => c.Rol.Nombre == "Alumno")
                .Include(p => p.Rol)
                .Select(a => new Persona
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Apellido1 = a.Apellido1,
                    Apellido2 = a.Apellido2,
                    Rol = a.Rol
                })
                .OrderBy(a => a.Apellido1)
                .ThenBy(a => a.Apellido2)
                .ThenBy(a => a.Nombre)
                .ToListAsync();
            return Alumnos;
        }


        public async Task<IEnumerable<Persona>> AlumnosSinTelefono()
        {
            var Alumnos = await _context.Personas
                .Where(c => c.Rol.Nombre == "Alumno" && (c.Telefono == null || c.Telefono == ""))
                .Include(p => p.Rol)
                .Select(a => new Persona
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Apellido1 = a.Apellido1,
                    Apellido2 = a.Apellido2,
                    Telefono = a.Telefono,
                    Rol = a.Rol
                })
                .ToListAsync();
            return Alumnos;
        }


        public async Task<IEnumerable<Persona>> Alumnos1999()
        {
            var Alumnos = await _context.Personas
                .Where(c => c.Rol.Nombre == "Alumno" && c.Fecha_Nacimiento.Year == 1999)
                .Include(p => p.Rol)
                .ToListAsync();
            return Alumnos;
        }




        public async Task<IEnumerable<Persona>> ProfesoresSinTelefono()
        {
            var Alumnos = await _context.Personas
                .Where(c => c.Rol.Nombre == "Profesor" && c.Nif.EndsWith("K") && (c.Telefono == null || c.Telefono == ""))
                .Include(p => p.Rol)
                .Select(a => new Persona
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Apellido1 = a.Apellido1,
                    Apellido2 = a.Apellido2,
                    Telefono = a.Telefono,
                    Nif = a.Nif,
                    Rol = a.Rol
                })
                .ToListAsync();
            return Alumnos;
        }



         public async Task<IEnumerable<Persona>> Womens()
        {
            var Alumnos = await _context.Personas
                .Where(c => c.Rol.Nombre == "Alumno" && c.Genero.Nombre == "Femenino" &&
                 c.Alumno_Se_Matricula_Asignaturas.Any(m => m.Asignatura.Grado.Nombre == "Grado en Ingeniería Informática (Plan 2015)"))
                .Include(p => p.Rol)
                .ToListAsync();
            return Alumnos;
        }


        public async Task<IEnumerable<Persona>> AlumnoSolo()
        {
            var Alumno = await _context.Personas
                .Where(c => c.Nif == "26902806M")
                .Include(u => u.Alumno_Se_Matricula_Asignaturas)
                .ThenInclude(u => u.Asignatura)
                .Include(u => u.Alumno_Se_Matricula_Asignaturas)
                .ThenInclude(m => m.CursoEscolar) 
                .ToListAsync();
              
            return Alumno;
        }


        public async Task<IEnumerable<Persona>> Matriculado2018()
        {
            var Alumnos = await _context.Personas
                .Where(c => c.Rol.Nombre == "Alumno" && c.Alumno_Se_Matricula_Asignaturas
                .Any(u => u.CursoEscolar.Año_Incio == 2018 && u.CursoEscolar.Año_Fin == 2019))
                .Include(p => p.Rol)
                .ToListAsync();
            return Alumnos;
        }



        public async Task<Object> CantidadAlumnas()
        {
            int totalAlumnas = await _context.Personas
                .Where(p => p.Genero.Nombre == "Femenino" && p.Rol.Nombre == "Alumno")
                .CountAsync();

            var resultado = new 
            {
                CantidadAlumnas = totalAlumnas
            };

            return resultado;
        }




        public async Task<Object> AlumnosNacidos1999()
        {
            int totalAlumnas = await _context.Personas
                .Where(p => p.Fecha_Nacimiento.Year == 1999 && p.Rol.Nombre == "Alumno")
                .CountAsync();

            var resultado = new 
            {
                AlumnosNacidosEn1999 = totalAlumnas
            };

            return resultado;
        }


        public async Task<Persona> AlumnoMasJoven()
        {
            var alumnoMasJoven = await _context.Personas
                .Where(p => p.Rol.Nombre == "Alumno") 
                .Include(u => u.Genero)
                .Include(u => u.Rol)
                .OrderByDescending(p => p.Fecha_Nacimiento)
                .FirstOrDefaultAsync();

            return alumnoMasJoven;
        }

        


    }
}