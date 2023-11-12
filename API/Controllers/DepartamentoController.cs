using API.Dtos;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     public class DepartamentoController : BaseApiController
    {
        
        private IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public DepartamentoController(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitofwork = unitOfWork;
            this.mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
         {
            var Departamentos = await unitofwork.Departamentos.GetAllAsync();
            return mapper.Map<List<DepartamentoDto>>(Departamentos);
         }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var Departamento = await unitofwork.Departamentos.GetByIdAsync(id);
            return mapper.Map<DepartamentoDto>(Departamento);
        }


          [HttpPost]

          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Departamento>> Post([FromBody]DepartamentoDto DepartamentoDto)
          {
              var Departamento = mapper.Map<Departamento>(DepartamentoDto);
              unitofwork.Departamentos.Add(Departamento);
              await unitofwork.SaveAsync();

              if (Departamento == null){
                  return BadRequest();
              }
              DepartamentoDto.Id = Departamento.Id;
              return CreatedAtAction(nameof(Post), new {id = DepartamentoDto.Id}, DepartamentoDto); 
           }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto DepartamentoDto){
            if(DepartamentoDto == null)
                return NotFound();

            var Departamento = this.mapper.Map<Departamento>(DepartamentoDto);
            unitofwork.Departamentos.Update(Departamento);
            await unitofwork.SaveAsync();
            return DepartamentoDto;
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete (int id){
            var Departamento = await unitofwork.Departamentos.GetByIdAsync(id);
            if(Departamento == null)
                return NotFound();
            
            unitofwork.Departamentos.Remove(Departamento);
            await unitofwork.SaveAsync();
            return NoContent();    }


        [HttpGet("Grado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetDepGrado()
        {
            var Departamentos = await unitofwork.Departamentos.DepartamentosGrado();
            return mapper.Map<List<DepartamentoDto>>(Departamentos);
        }


        [HttpGet("SinProfes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetDepSin()
        {
            var Departamentos = await unitofwork.Departamentos.DepartamentosSinProfesores();
            return mapper.Map<List<DepartamentoDto>>(Departamentos);
        }


          [HttpGet("NumeroProfes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetNumeroProfes()
         {
            var Departamentos = await unitofwork.Departamentos.NumeroProfesDep();
            return Ok(Departamentos);
         }



         [HttpGet("NumeroProfes2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetNumeroProfes2()
         {
            var Departamentos = await unitofwork.Departamentos.NumeroProfesDep2();
            return Ok(Departamentos);
         }



         [HttpGet("SinAsignaturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> SinAsignaturas()
        {
            var Departamentos = await unitofwork.Departamentos.DepartamentosSinAsignaturas();
            return mapper.Map<List<DepartamentoDto>>(Departamentos);
        }



        [HttpGet("AsignaturasSinImpartir")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> AsignaturasSinImpartir()
         {
            var Departamentos = await unitofwork.Departamentos.AsignaturasSinImpartir();
            return Ok(Departamentos);
         }


    }
}