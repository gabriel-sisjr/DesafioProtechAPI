using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public class ExperienciaEmpresaService : IExperienciaEmpresaService
    {
        private readonly IExperienciaEmpresaRepository _empresaRepository;
        public ExperienciaEmpresaService(IExperienciaEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public ExperienciaEmpresaModel Atualizar(ExperienciaEmpresaModel objeto) => _empresaRepository.Atualizar(objeto);

        public bool Excluir(ExperienciaEmpresaModel objeto) => _empresaRepository.Excluir(objeto);

        public ExperienciaEmpresaModel Inserir(ExperienciaEmpresaModel objeto) => _empresaRepository.Inserir(objeto);

        public ExperienciaEmpresaModel ObterPorId(int id) => _empresaRepository.ObterPorId(id);

        public List<ExperienciaEmpresaModel> ObterTodos() => _empresaRepository.ObterTodos();
    }
}
