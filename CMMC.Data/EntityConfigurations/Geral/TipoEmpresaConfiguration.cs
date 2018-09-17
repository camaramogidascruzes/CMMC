using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class TipoEmpresaConfiguration : EntityTypeConfiguration<TipoEmpresa>
    {
        public TipoEmpresaConfiguration()
        {
            this.ToTable("GeralTipoEmpresa");
            this.HasKey(s => s.Id);
            this.Property(p => p.Id).HasColumnName("id").IsRequired();
            this.Property(s => s.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();

            this.HasMany(s => s.Empresas).WithRequired(f => f.TipoEmpresa);
        }
    }
}