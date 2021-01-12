using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public class ExperienciaService : IExperienciaService
    {
        private readonly IExperienciaRepository _experienciaRepository;

        public ExperienciaService(IExperienciaRepository experienciaRepository)
        {
            _experienciaRepository = experienciaRepository;
        }

        public ExperienciaModel Atualizar(ExperienciaModel objeto) => _experienciaRepository.Atualizar(objeto);

        public bool Excluir(ExperienciaModel objeto) => _experienciaRepository.Excluir(objeto);

        public ExperienciaModel Inserir(ExperienciaModel objeto) => _experienciaRepository.Inserir(objeto);

        public ExperienciaModel ObterPorId(int id) => _experienciaRepository.ObterPorId(id);

        public List<ExperienciaModel> ObterTodos() => _experienciaRepository.ObterTodos();
    }
}
