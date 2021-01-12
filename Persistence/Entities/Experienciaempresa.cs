using System;

namespace Persistence.Entities
{
    public partial class Experienciaempresa
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string DetalheExperiencia { get; set; }
        public int IdUser { get; set; }

        public Usuario IdUserNavigation { get; set; }
    }
}
