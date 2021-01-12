using System;

namespace Persistence.Entities
{
    public partial class Formacao
    {
        public int Id { get; set; }
        public string Curso { get; set; }
        public string Status { get; set; }
        public DateTime DataConclusao { get; set; }
        public int IdUser { get; set; }

        public Usuario IdUserNavigation { get; set; }
    }
}
