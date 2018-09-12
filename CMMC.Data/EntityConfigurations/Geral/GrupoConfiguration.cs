using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class GrupoConfiguration : EntityTypeConfiguration<Grupo>
    {
        public GrupoConfiguration()
        {
            this.ToTable("GeralGrupos");
            this.HasKey(g => g.Id);
            this.Property(g => g.Id).HasColumnName("id").IsRequired();
            this.Property(g => g.Nome).HasColumnName("nome").IsRequired();
            this.Property(g => g.Bloqueado).HasColumnName("bloqueado").IsRequired();
            this.Property(g => g.Excluido).HasColumnName("excluido").IsRequired();

            this.HasOptional(g => g.CategoriaRedeSemFio).WithMany(c => c.Grupos).HasForeignKey(g => g.IdCategoriaRedeSemFio);
            this.HasMany(u => u.Usuarios).WithRequired(g => g.Grupo).HasForeignKey(g => g.IdGrupo);
        }
    }
}