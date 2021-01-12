using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        public UsuarioRepository(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UsuarioModel Atualizar(UsuarioModel objeto)
        {
            var b = _context.Usuario.FirstOrDefault(x => x.Id == objeto.Id);
            if (b != null)
            {
                _context.Usuario.Update(_mapper.Map<Usuario>(objeto));
                _context.SaveChanges();
            }
            return null;
        }

        public bool Excluir(UsuarioModel objeto)
        {
            _context.Usuario.Remove(_context.Usuario.FirstOrDefault(x => x.Id == objeto.Id));
            return _context.SaveChanges() == 1;
        }

        public UsuarioModel Inserir(UsuarioModel objeto)
        {
            _context.Usuario.Add(_mapper.Map<Usuario>(objeto));
            _context.SaveChanges();
            return objeto;
        }

        public UsuarioModel ObterPorId(int id) => _mapper.Map<UsuarioModel>(_context.Usuario.FirstOrDefault(x => x.Id == id));

        public List<UsuarioModel> ObterTodos() => _context.Usuario.Select(x => new UsuarioModel
        {
            Id = x.Id,
            Nome = x.Nome,
            Formacao = _context.Formacao.Where(y => y.Id == x.Id).Select(y => new FormacaoModel
            {
                Id = y.Id,
                Status = y.Status,
                Curso = y.Curso,
                DataConclusao = y.DataConclusao
            }).ToList(),
            Experiencia = _context.Experiencia.Where(y => y.Id == x.Id).Select(y => new ExperienciaModel
            {
                Id = y.Id,
                Tecnologia = y.Tecnologia,
                TempoExperiencia = y.TempoExperiencia,
                DetalheExperiencia = y.DetalheExperiencia
            }).ToList(),
            ExperienciaEmpresas = _context.Experienciaempresa.Where(y => y.Id == x.Id).Select(y => new ExperienciaEmpresaModel
            {
                Id = y.Id,
                Empresa = y.NomeEmpresa,
                Cargo = y.Cargo,
                DataInicio = y.DataInicio,
                DataFim = y.DataFim,
                DetalheExperiencia = y.DetalheExperiencia
            }).ToList(),
            DataNascimento = x.DataNascimento,
            ExperienciaTotal = x.ExperienciaTotal
        }).ToList();
    }
}
