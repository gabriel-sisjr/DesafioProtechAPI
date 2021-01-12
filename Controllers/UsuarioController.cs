using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioProtechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get() => Ok(_usuarioService.ObterTodos());

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_usuarioService.ObterPorId(id));

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioModel usuarioModel) => Ok(_usuarioService.Inserir(usuarioModel));

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UsuarioModel usuarioModel) => Ok(_usuarioService.Atualizar(usuarioModel));

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] UsuarioModel usuarioModel) => Ok(_usuarioService.Excluir(usuarioModel));
    }
}
