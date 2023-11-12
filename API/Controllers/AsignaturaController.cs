using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     public class AsignaturaController : BaseApiController
    {
        
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public AsignaturaController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get()
         {
            var Asignaturas = await unitofwork.Asignaturas.GetAllAsync();
            return mapper.Map<List<AsignaturaDto>>(Asignaturas);
         }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AsignaturaDto>> Get(int id)
        {
            var Asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);
            return mapper.Map<AsignaturaDto>(Asignatura);
        }


          [HttpPost]

          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Asignatura>> Post([FromBody]AsignaturaDto AsignaturaDto)
          {
              var Asignatura = mapper.Map<Asignatura>(AsignaturaDto);
              unitofwork.Asignaturas.Add(Asignatura);
              await unitofwork.SaveAsync();

              if (Asignatura == null){
                  return BadRequest();
              }
              AsignaturaDto.Id = Asignatura.Id;
              return CreatedAtAction(nameof(Post), new {id = AsignaturaDto.Id}, AsignaturaDto); 
           }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AsignaturaDto>> Put(int id, [FromBody]AsignaturaDto AsignaturaDto){
            if(AsignaturaDto == null)
                return NotFound();

            var Asignatura = this.mapper.Map<Asignatura>(AsignaturaDto);
            unitofwork.Asignaturas.Update(Asignatura);
            await unitofwork.SaveAsync();
            return AsignaturaDto;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete (int id){
            var Asignatura = await unitofwork.Asignaturas.GetByIdAsync(id);
            if(Asignatura == null)
                return NotFound();
            
            unitofwork.Asignaturas.Remove(Asignatura);
            await unitofwork.SaveAsync();
            return NoContent();    }



        [HttpGet("Cuatrimestre1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetCuatrimestre1()
        {
        var Asignaturas = await unitofwork.Asignaturas.AsignaturasCuatrimestre1();
        return mapper.Map<List<AsignaturaDto>>(Asignaturas);
        }



        [HttpGet("Grado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetGrado()
         {
            var Asignaturas = await unitofwork.Asignaturas.AsignaturasGrado();
            return mapper.Map<List<AsignaturaDto>>(Asignaturas);
         }



         [HttpGet("SinProfe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetSinProfes()
         {
            var Asignaturas = await unitofwork.Asignaturas.SinProfe();
            return mapper.Map<List<AsignaturaDto>>(Asignaturas);
         }
    }
}