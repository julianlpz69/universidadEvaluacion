using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     public class GradoController : BaseApiController
    {
        
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public GradoController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<GradoDto>>> Get()
         {
            var Grados = await unitofwork.Grados.GetAllAsync();
            return mapper.Map<List<GradoDto>>(Grados);
         }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradoDto>> Get(int id)
        {
            var Grado = await unitofwork.Grados.GetByIdAsync(id);
            return mapper.Map<GradoDto>(Grado);
        }


          [HttpPost]

          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Grado>> Post([FromBody]GradoDto GradoDto)
          {
              var Grado = mapper.Map<Grado>(GradoDto);
              unitofwork.Grados.Add(Grado);
              await unitofwork.SaveAsync();

              if (Grado == null){
                  return BadRequest();
              }
              GradoDto.Id = Grado.Id;
              return CreatedAtAction(nameof(Post), new {id = GradoDto.Id}, GradoDto); 
           }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<GradoDto>> Put(int id, [FromBody]GradoDto GradoDto){
            if(GradoDto == null)
                return NotFound();

            var Grado = this.mapper.Map<Grado>(GradoDto);
            unitofwork.Grados.Update(Grado);
            await unitofwork.SaveAsync();
            return GradoDto;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete (int id){
            var Grado = await unitofwork.Grados.GetByIdAsync(id);
            if(Grado == null)
                return NotFound();
            
            unitofwork.Grados.Remove(Grado);
            await unitofwork.SaveAsync();
            return NoContent();    }



        [HttpGet("Asignaturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetAsignaturas()
         {
            var Grados = await unitofwork.Grados.NumeroGrados();
            return Ok(Grados);
         }


         [HttpGet("Mayor40")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> Masde40()
         {
            var Grados = await unitofwork.Grados.GradoMayor40();
            return Ok(Grados);
         }


        [ HttpGet("SumaCreditos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> SumaCreditos()
         {
            var Grados = await unitofwork.Grados.SumaCreditosPorTipoAsignatura();
            return Ok(Grados);
         }
    }
}