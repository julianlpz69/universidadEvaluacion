using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     public class ProfesorController : BaseApiController
    {
        
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public ProfesorController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
         {
            var Profesors = await unitofwork.Profesores.GetAllAsync();
            return mapper.Map<List<ProfesorDto>>(Profesors);
         }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfesorDto>> Get(int id)
        {
            var Profesor = await unitofwork.Profesores.GetByIdAsync(id);
            return mapper.Map<ProfesorDto>(Profesor);
        }


          [HttpPost]

          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Profesor>> Post([FromBody]ProfesorDto ProfesorDto)
          {
              var Profesor = mapper.Map<Profesor>(ProfesorDto);
              unitofwork.Profesores.Add(Profesor);
              await unitofwork.SaveAsync();

              if (Profesor == null){
                  return BadRequest();
              }
              ProfesorDto.Id = Profesor.Id;
              return CreatedAtAction(nameof(Post), new {id = ProfesorDto.Id}, ProfesorDto); 
           }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ProfesorDto>> Put(int id, [FromBody]ProfesorDto ProfesorDto){
            if(ProfesorDto == null)
                return NotFound();

            var Profesor = this.mapper.Map<Profesor>(ProfesorDto);
            unitofwork.Profesores.Update(Profesor);
            await unitofwork.SaveAsync();
            return ProfesorDto;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete (int id){
            var Profesor = await unitofwork.Profesores.GetByIdAsync(id);
            if(Profesor == null)
                return NotFound();
            
            unitofwork.Profesores.Remove(Profesor);
            await unitofwork.SaveAsync();
            return NoContent();    }



        [HttpGet("Departamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDepartamentoDto>>> GetDepartamentos()
         {
            var Personas = await unitofwork.Profesores.ProfesOrdenados();
            return mapper.Map<List<ProfesorDepartamentoDto>>(Personas);
         }


         [HttpGet("Departamentos2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> Profes()
         {
            var Personas = await unitofwork.Profesores.ProfesoresConDepartamentos();
            return Ok(Personas);
         }


        [HttpGet("SinAsignatura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfeSinAsignaturaDto>>> ProfesSin()
         {
            var Personas = await unitofwork.Profesores.SinAsignatura();
             return mapper.Map<List<ProfeSinAsignaturaDto>>(Personas);
         }


        [ HttpGet("AsignaturasXProfe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> AsignaturasXProfe()
         {
            var Grados = await unitofwork.Profesores.AsignaturasXProfesor();
            return Ok(Grados);
         }



         [HttpGet("SinDepartamento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfeSinAsignaturaDto>>> SinDepartamento()
         {
            var Personas = await unitofwork.Profesores.ProfesoresSinDepartamento();
             return mapper.Map<List<ProfeSinAsignaturaDto>>(Personas);
         }



         [HttpGet("ProfesConYSin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfeSinAsignaturaDto>>> ProfesConYSin()
         {
            var Personas = await unitofwork.Profesores.ProfesConYSin();
             return mapper.Map<List<ProfeSinAsignaturaDto>>(Personas);
         }
    }
}