using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioProtechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormacaoController : ControllerBase
    {
        private readonly IFormacaoService _formacaoService;
        public FormacaoController(IFormacaoService formacaoService)
        {
            _formacaoService = formacaoService;
        }

        // GET: api/<FormacaoController>
        [HttpGet]
        public IActionResult Get() => Ok(_formacaoService.ObterTodos());

        // GET api/<FormacaoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_formacaoService.ObterPorId(id));

        // POST api/<FormacaoController>
        [HttpPost]
        public IActionResult Post([FromBody] FormacaoModel formacaoModel) => Ok(_formacaoService.Inserir(formacaoModel));

        // PUT api/<FormacaoController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] FormacaoModel formacaoModel) => Ok(_formacaoService.Atualizar(formacaoModel));

        // DELETE api/<FormacaoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] FormacaoModel formacaoModel) => Ok(_formacaoService.Excluir(formacaoModel));
    }
}
