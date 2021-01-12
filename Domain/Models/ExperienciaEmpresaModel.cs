using System;

namespace Domain.Models
{
    public class ExperienciaEmpresaModel
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string DetalheExperiencia { get; set; }
    }
}
