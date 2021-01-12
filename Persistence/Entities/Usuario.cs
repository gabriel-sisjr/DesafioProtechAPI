using System.Collections.Generic;

namespace Persistence.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Experiencia = new HashSet<Experiencia>();
            Experienciaempresa = new HashSet<Experienciaempresa>();
            Formacao = new HashSet<Formacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public int ExperienciaTotal { get; set; }

        public ICollection<Experiencia> Experiencia { get; set; }
        public ICollection<Experienciaempresa> Experienciaempresa { get; set; }
        public ICollection<Formacao> Formacao { get; set; }
    }
}
