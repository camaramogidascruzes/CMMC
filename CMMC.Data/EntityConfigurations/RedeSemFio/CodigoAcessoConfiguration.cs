using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.RedeSemFio;

namespace CMMC.Data.EntityConfigurations.RedeSemFio
{
    public class CodigoAcessoConfiguration : EntityTypeConfiguration<CodigoAcesso>
    {
        public CodigoAcessoConfiguration()
        {
            this.ToTable("RedeSemFioCodigoAcesso");

            this.HasKey(c => c.Id);

            this.Property(a => a.Id).HasColumnName("id").IsRequired();
            this.Property(a => a.Codigo).HasColumnName("codigo").HasMaxLength(255).IsRequired();
            this.Property(a => a.DataEmissao).HasColumnName("dataEmissao").IsRequired();
            this.Property(a => a.Validade).HasColumnName("validade").IsRequired();
            this.Property(a => a.Quota).HasColumnName("Quota").IsRequired();

            this.HasRequired(c => c.Usuario).WithMany(u => u.Codigos).HasForeignKey(c => c.IdUsuarioRedeSemFio);
        }
    }
}