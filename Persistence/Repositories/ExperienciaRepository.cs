using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class ExperienciaRepository : IExperienciaRepository
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public ExperienciaRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ExperienciaModel Atualizar(ExperienciaModel objeto)
        {
            var b = _context.Experiencia.FirstOrDefault(x => x.Id == objeto.Id);
            if (b != null)
            {
                _context.Experiencia.Update(_mapper.Map<Experiencia>(objeto));
                _context.SaveChanges();
                return objeto;
            }
            return null;

        }

        public bool Excluir(ExperienciaModel objeto)
        {
            _context.Remove(_context.Experiencia.FirstOrDefault(x => x.Id == objeto.Id));
            return _context.SaveChanges() == 1;
        }

        public ExperienciaModel Inserir(ExperienciaModel objeto)
        {
            _context.Experiencia.Add(_mapper.Map<Experiencia>(objeto));
            _context.SaveChanges();
            return objeto;
        }

        public ExperienciaModel ObterPorId(int id) => _mapper.Map<ExperienciaModel>(_context.Experiencia.FirstOrDefault(x => x.Id == id));

        public List<ExperienciaModel> ObterTodos() => _context.Experiencia.Select(y => new ExperienciaModel
        {
            Id = y.Id,
            Tecnologia = y.Tecnologia,
            TempoExperiencia = y.TempoExperiencia,
            DetalheExperiencia = y.DetalheExperiencia
        }).ToList();
    }
}
