using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioProtechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaEmpresaController : ControllerBase
    {
        private readonly IExperienciaEmpresaService _experienciaEmpresaService;
        public ExperienciaEmpresaController(IExperienciaEmpresaService experienciaEmpresaService)
        {
            _experienciaEmpresaService = experienciaEmpresaService;
        }

        // GET: api/<ExperienciaEmpresaController>
        [HttpGet]
        public IActionResult Get() => Ok(_experienciaEmpresaService.ObterTodos());

        // GET api/<ExperienciaEmpresaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_experienciaEmpresaService.ObterPorId(id));

        // POST api/<ExperienciaEmpresaController>
        [HttpPost]
        public IActionResult Post([FromBody] ExperienciaEmpresaModel experienciaEmpresaModel) => Ok(_experienciaEmpresaService.Inserir(experienciaEmpresaModel));

        // PUT api/<ExperienciaEmpresaController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ExperienciaEmpresaModel experienciaEmpresaModel) => Ok(_experienciaEmpresaService.Atualizar(experienciaEmpresaModel));

        // DELETE api/<ExperienciaEmpresaController>/5
        [HttpDelete("{id}")]
        public void Delete([FromBody] ExperienciaEmpresaModel experienciaEmpresaModel) => Ok(_experienciaEmpresaService.Excluir(experienciaEmpresaModel));
    }
}
