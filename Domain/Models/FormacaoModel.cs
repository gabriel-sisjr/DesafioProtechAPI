using System;

namespace Domain.Models
{
    public class FormacaoModel
    {
        public int Id { get; set; }
        public string Curso { get; set; }
        public string Status { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
