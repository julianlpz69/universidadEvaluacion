using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
         public MappingProfiles()
         {
                
            CreateMap<Asignatura,AsignaturaDto>().ReverseMap();
            CreateMap<CursoEscolar,CursoEscolarDto>().ReverseMap();
            CreateMap<Departamento,DepartamentoDto>().ReverseMap();
            CreateMap<Grado,GradoDto>().ReverseMap();
            CreateMap<Persona,PersonaDto>().ReverseMap();
            CreateMap<Profesor,ProfesorDto>().ReverseMap();

            CreateMap<Genero,GeneroDto>().ReverseMap();
            CreateMap<TipoAsignatura,TipoAsignaturaDto>().ReverseMap();
            CreateMap<Rol,RolDto>().ReverseMap();

            CreateMap<Persona,EstudiantesOrdenadosDto>().ReverseMap();


            CreateMap<Profesor, ProfesorDepartamentoDto>()
            .ForMember(dest => dest.Apellido1, opt => opt.MapFrom(src => src.Persona.Apellido1))
            .ForMember(dest => dest.Apellido2, opt => opt.MapFrom(src => src.Persona.Apellido2))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Persona.Nombre))
            .ForMember(dest => dest.Departamento, opt => opt.MapFrom(src => src.Departamento.Nombre));


            CreateMap<AlumnoMatriculaAsignatura, AsignaturasEstudianteSoloDto>()
            .ForMember(dest => dest.NombreAsignatura, opt => opt.MapFrom(src => src.Asignatura.Nombre))
            .ForMember(dest => dest.Año_Incio, opt => opt.MapFrom(src => src.CursoEscolar.Año_Incio))
            .ForMember(dest => dest.Año_Fin, opt => opt.MapFrom(src => src.CursoEscolar.Año_Fin));

            CreateMap<Persona, EstudianteSoloDto>()
            .ForMember(dest => dest.Matriculas, opt => opt.MapFrom(src => src.Alumno_Se_Matricula_Asignaturas));
            
             CreateMap<Profesor, ProfeSinAsignaturaDto>()
             .ForMember(dest => dest.Datos, opt => opt.MapFrom(src => src.Persona));
         }
    }
}