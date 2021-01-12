using System.Collections.Generic;

namespace Domain.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public List<FormacaoModel> Formacao { get; set; }
        public int ExperienciaTotal { get; set; }
        public List<ExperienciaModel> Experiencia { get; set; }
        public List<ExperienciaEmpresaModel> ExperienciaEmpresas { get; set; }
    }
}
