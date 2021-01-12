namespace Persistence.Entities
{
    public partial class Experiencia
    {
        public int Id { get; set; }
        public string Tecnologia { get; set; }
        public int TempoExperiencia { get; set; }
        public string DetalheExperiencia { get; set; }
        public int IdUser { get; set; }

        public Usuario IdUserNavigation { get; set; }
    }
}
