using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.RedeSemFio;

namespace CMMC.Data.EntityConfigurations.RedeSemFio
{
    public class CategoriaUsuarioConfiguration : EntityTypeConfiguration<CategoriaUsuario>
    {
        public CategoriaUsuarioConfiguration()
        {
            this.ToTable("RedeSemFioCategoriaUsuario");
            this.HasKey(c => c.Id);
            this.Property(a => a.Id).HasColumnName("id").IsRequired();
            this.Property(a => a.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();
            this.Property(a => a.Validade).HasColumnName("validade").IsRequired();
            this.Property(a => a.Quota).HasColumnName("quota").IsRequired();

            this.HasMany(c => c.Grupos).WithOptional(g => g.CategoriaRedeSemFio);
        }

    }
}