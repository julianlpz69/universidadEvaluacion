using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     public class PersonaController : BaseApiController
    {
        
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
         {
            var Personas = await unitofwork.Personas.GetAllAsync();
            return mapper.Map<List<PersonaDto>>(Personas);
         }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var Persona = await unitofwork.Personas.GetByIdAsync(id);
            return mapper.Map<PersonaDto>(Persona);
        }


          [HttpPost]

          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Persona>> Post([FromBody]PersonaDto PersonaDto)
          {
              var Persona = mapper.Map<Persona>(PersonaDto);
              unitofwork.Personas.Add(Persona);
              await unitofwork.SaveAsync();

              if (Persona == null){
                  return BadRequest();
              }
              PersonaDto.Id = Persona.Id;
              return CreatedAtAction(nameof(Post), new {id = PersonaDto.Id}, PersonaDto); 
           }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto PersonaDto){
            if(PersonaDto == null)
                return NotFound();

            var Persona = this.mapper.Map<Persona>(PersonaDto);
            unitofwork.Personas.Update(Persona);
            await unitofwork.SaveAsync();
            return PersonaDto;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete (int id){
            var Persona = await unitofwork.Personas.GetByIdAsync(id);
            if(Persona == null)
                return NotFound();
            
            unitofwork.Personas.Remove(Persona);
            await unitofwork.SaveAsync();
            return NoContent();    }


        [HttpGet("Ordenados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstudiantesOrdenadosDto>>> GetOrdenados()
         {
            var Personas = await unitofwork.Personas.AlumnosOrdenados();
            return mapper.Map<List<EstudiantesOrdenadosDto>>(Personas);
         }


        [HttpGet("SinTelefono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstudiantesOrdenadosDto>>> GetSinTelefono()
         {
            var Personas = await unitofwork.Personas.AlumnosSinTelefono();
            return mapper.Map<List<EstudiantesOrdenadosDto>>(Personas);
         }


         [HttpGet("1999")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get1999()
         {
            var Personas = await unitofwork.Personas.Alumnos1999();
            return mapper.Map<List<PersonaDto>>(Personas);
         }




        [HttpGet("P_SinTelefono")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstudiantesOrdenadosDto>>> GetP_SinTelefono()
         {
            var Personas = await unitofwork.Personas.ProfesoresSinTelefono();
            return mapper.Map<List<EstudiantesOrdenadosDto>>(Personas);
         }


         [HttpGet("Womens")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstudiantesOrdenadosDto>>> GetWomens()
         {
            var Personas = await unitofwork.Personas.Womens();
            return mapper.Map<List<EstudiantesOrdenadosDto>>(Personas);
         }


        [HttpGet("AlumnoSolo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstudianteSoloDto>>> GetEstudentSolo()
         {
            var Personas = await unitofwork.Personas.AlumnoSolo();
            return mapper.Map<List<EstudianteSoloDto>>(Personas);
         }


         [HttpGet("matricula2018")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstudiantesOrdenadosDto>>> Getmatricula2018()
         {
            var Personas = await unitofwork.Personas.Matriculado2018();
            return mapper.Map<List<EstudiantesOrdenadosDto>>(Personas);
         }



         [HttpGet("CantidadAlumnas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetCantidadAlumnas()
         {
            var Personas = await unitofwork.Personas.CantidadAlumnas();
            return Ok(Personas);
         }



          [HttpGet("Nacidos1999")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetNacidos1999()
         {
            var Personas = await unitofwork.Personas.AlumnosNacidos1999();
            return Ok(Personas);
         }


         [HttpGet("MasJoven")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstudiantesOrdenadosDto>> GetMasJoven()
         {
            var Personas = await unitofwork.Personas.AlumnoMasJoven();
            return mapper.Map<EstudiantesOrdenadosDto>(Personas);
         }
    }
}