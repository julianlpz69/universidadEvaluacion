using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private UniversidadContext _context;
        private AsignaturaRepository _Asignaturas ;
        private CursoEscolarRepository _CursosEscolares ;
        private DepartamentoRepository _Departamentos ;
        private GradoRepository _Grados ;
        private PersonaRepository _Personas ;
        private ProfesorRepository _Profesores ;
        public UnitOfWork(UniversidadContext context){
            _context = context;
        }


        public IAsignatura Asignaturas
        {
            get{
                if (_Asignaturas == null)
                {
                    _Asignaturas = new AsignaturaRepository(_context);
                }
                return _Asignaturas;
            }
        }


        public ICursoEscolar CursosEscolares
        {
            get{
                if (_CursosEscolares == null)
                {
                    _CursosEscolares = new CursoEscolarRepository(_context);
                }
                return _CursosEscolares;
            }
        }



        public IDepartamento Departamentos
        {
            get{
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepository(_context);
                }
                return _Departamentos;
            }
        }


        public IGrado Grados
        {
            get{
                if (_Grados == null)
                {
                    _Grados = new GradoRepository(_context);
                }
                return _Grados;
            }
        }


        public IPersona Personas
        {
            get{
                if (_Personas == null)
                {
                    _Personas = new PersonaRepository(_context);
                }
                return _Personas;
            }
        }

        public IProfesor Profesores
        {
            get{
                if (_Profesores == null)
                {
                    _Profesores = new ProfesorRepository(_context);
                }
                return _Profesores;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}