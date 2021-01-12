using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class FormacaoRepository : IFormacaoRepository
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public FormacaoRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public FormacaoModel Atualizar(FormacaoModel objeto)
        {
            var b = _context.Formacao.FirstOrDefault(x => x.Id == objeto.Id);
            if (b != null)
            {
                _context.Formacao.Update(_mapper.Map<Formacao>(objeto));
                _context.SaveChanges();
                return objeto;
            }
            return null;
        }

        public bool Excluir(FormacaoModel objeto)
        {
            _context.Formacao.Remove(_context.Formacao.FirstOrDefault(x => x.Id == objeto.Id));
            return _context.SaveChanges() == 1;
        }

        public FormacaoModel Inserir(FormacaoModel objeto)
        {
            _context.Formacao.Add(_mapper.Map<Formacao>(objeto));
            _context.SaveChanges();
            return objeto;
        }

        public FormacaoModel ObterPorId(int id) => _mapper.Map<FormacaoModel>(_context.Formacao.FirstOrDefault(x => x.Id == id));

        public List<FormacaoModel> ObterTodos() => _context.Formacao.Select(y => new FormacaoModel
        {
            Id = y.Id,
            Status = y.Status,
            Curso = y.Curso,
            DataConclusao = y.DataConclusao
        }).ToList();
    }
}
