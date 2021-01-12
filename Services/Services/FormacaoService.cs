using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public class FormacaoService : IFormacaoService
    {
        private readonly IFormacaoRepository _formacaoRepository;
        public FormacaoService(IFormacaoRepository formacaoRepository)
        {
            _formacaoRepository = formacaoRepository;
        }

        public FormacaoModel Atualizar(FormacaoModel objeto) => _formacaoRepository.Atualizar(objeto);

        public bool Excluir(FormacaoModel objeto) => _formacaoRepository.Excluir(objeto);

        public FormacaoModel Inserir(FormacaoModel objeto) => _formacaoRepository.Inserir(objeto);

        public FormacaoModel ObterPorId(int id) => _formacaoRepository.ObterPorId(id);

        public List<FormacaoModel> ObterTodos() => _formacaoRepository.ObterTodos();
    }
}
