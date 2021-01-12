using Microsoft.EntityFrameworkCore;

namespace Persistence.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Experiencia> Experiencia { get; set; }
        public virtual DbSet<Experienciaempresa> Experienciaempresa { get; set; }
        public virtual DbSet<Formacao> Formacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experiencia>(entity =>
            {
                entity.ToTable("experiencia", "mydb");

                entity.HasIndex(e => e.IdUser)
                    .HasName("fk_Experiencia_Usuario1_idx");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.DetalheExperiencia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).HasColumnType("int unsigned");

                entity.Property(e => e.Tecnologia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Experiencia)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Experiencia_Usuario1");
            });

            modelBuilder.Entity<Experienciaempresa>(entity =>
            {
                entity.ToTable("experienciaempresa", "mydb");

                entity.HasIndex(e => e.IdUser)
                    .HasName("fk_ExperienciaEmpresa_Usuario1_idx");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.DetalheExperiencia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).HasColumnType("int unsigned");

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Experienciaempresa)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ExperienciaEmpresa_Usuario1");
            });

            modelBuilder.Entity<Formacao>(entity =>
            {
                entity.ToTable("formacao", "mydb");

                entity.HasIndex(e => e.IdUser)
                    .HasName("fk_Formacao_Usuario_idx");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser).HasColumnType("int unsigned");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Formacao)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Formacao_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario", "mydb");

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.DataNascimento)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
