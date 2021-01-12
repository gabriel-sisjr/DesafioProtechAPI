using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class ExperienciaEmpresaRepository : IExperienciaEmpresaRepository
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public ExperienciaEmpresaRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ExperienciaEmpresaModel Atualizar(ExperienciaEmpresaModel objeto)
        {
            var b = _context.Experienciaempresa.FirstOrDefault(x => x.Id == objeto.Id);
            if (b != null)
            {
                _context.Experienciaempresa.Update(_mapper.Map<Experienciaempresa>(objeto));
                _context.SaveChanges();
                return objeto;
            }
            return null;
        }

        public bool Excluir(ExperienciaEmpresaModel objeto)
        {
            _context.Remove(_context.Experienciaempresa.FirstOrDefault(x => x.Id == objeto.Id));
            return _context.SaveChanges() == 1;
        }

        public ExperienciaEmpresaModel Inserir(ExperienciaEmpresaModel objeto)
        {
            _context.Experienciaempresa.Add(_mapper.Map<Experienciaempresa>(objeto));
            _context.SaveChanges();
            return objeto;
        }

        public ExperienciaEmpresaModel ObterPorId(int id) => _mapper.Map<ExperienciaEmpresaModel>(_context.Experienciaempresa.FirstOrDefault(x => x.Id == id));

        public List<ExperienciaEmpresaModel> ObterTodos() => _context.Experienciaempresa.Select(x => new ExperienciaEmpresaModel
        {
            Id = x.Id,
            Empresa = x.NomeEmpresa,
            Cargo = x.Cargo,
            DataInicio = x.DataInicio,
            DataFim = x.DataFim,
            DetalheExperiencia = x.DetalheExperiencia
        }).ToList();
    }
}
