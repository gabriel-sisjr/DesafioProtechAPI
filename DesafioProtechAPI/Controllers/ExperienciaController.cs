using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioProtechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private readonly IExperienciaService _experienciaService;
        public ExperienciaController(IExperienciaService experienciaService)
        {
            _experienciaService = experienciaService;
        }

        // GET: api/<ExperienciaController>
        [HttpGet]
        public IActionResult Get() => Ok(_experienciaService.ObterTodos());

        // GET api/<ExperienciaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_experienciaService.ObterPorId(id));

        // POST api/<ExperienciaController>
        [HttpPost]
        public IActionResult Post([FromBody] ExperienciaModel experienciaModel) => Ok(_experienciaService.Inserir(experienciaModel));

        // PUT api/<ExperienciaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ExperienciaModel experienciaModel) => Ok(_experienciaService.Atualizar(experienciaModel));

        // DELETE api/<ExperienciaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] ExperienciaModel experienciaModel) => Ok(_experienciaService.Excluir(experienciaModel));
    }
}
