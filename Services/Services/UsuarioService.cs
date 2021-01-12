using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioModel Atualizar(UsuarioModel objeto) => _usuarioRepository.Atualizar(objeto);

        public bool Excluir(UsuarioModel objeto) => _usuarioRepository.Excluir(objeto);

        public UsuarioModel Inserir(UsuarioModel objeto) => _usuarioRepository.Inserir(objeto);

        public UsuarioModel ObterPorId(int id) => _usuarioRepository.ObterPorId(id);

        public List<UsuarioModel> ObterTodos() => _usuarioRepository.ObterTodos();
    }
}
