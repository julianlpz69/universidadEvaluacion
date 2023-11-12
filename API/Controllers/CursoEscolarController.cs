using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     public class CursoEscolarController : BaseApiController
    {
        
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public CursoEscolarController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<CursoEscolarDto>>> Get()
         {
            var CursoEscolars = await unitofwork.CursosEscolares.GetAllAsync();
            return mapper.Map<List<CursoEscolarDto>>(CursoEscolars);
         }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolarDto>> Get(int id)
        {
            var CursoEscolar = await unitofwork.CursosEscolares.GetByIdAsync(id);
            return mapper.Map<CursoEscolarDto>(CursoEscolar);
        }


          [HttpPost]

          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<CursoEscolar>> Post([FromBody]CursoEscolarDto CursoEscolarDto)
          {
              var CursoEscolar = mapper.Map<CursoEscolar>(CursoEscolarDto);
              unitofwork.CursosEscolares.Add(CursoEscolar);
              await unitofwork.SaveAsync();

              if (CursoEscolar == null){
                  return BadRequest();
              }
              CursoEscolarDto.Id = CursoEscolar.Id;
              return CreatedAtAction(nameof(Post), new {id = CursoEscolarDto.Id}, CursoEscolarDto); 
           }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<CursoEscolarDto>> Put(int id, [FromBody]CursoEscolarDto CursoEscolarDto){
            if(CursoEscolarDto == null)
                return NotFound();

            var CursoEscolar = this.mapper.Map<CursoEscolar>(CursoEscolarDto);
            unitofwork.CursosEscolares.Update(CursoEscolar);
            await unitofwork.SaveAsync();
            return CursoEscolarDto;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete (int id){
            var CursoEscolar = await unitofwork.CursosEscolares.GetByIdAsync(id);
            if(CursoEscolar == null)
                return NotFound();
            
            unitofwork.CursosEscolares.Remove(CursoEscolar);
            await unitofwork.SaveAsync();
            return NoContent();    }



        [ HttpGet("AlumnosAños")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> Alumos()
         {
            var Grados = await unitofwork.CursosEscolares.AlumnosMatriculadosPorCurso();
            return Ok(Grados);
         }
    }
}