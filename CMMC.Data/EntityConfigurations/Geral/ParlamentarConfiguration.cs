using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class ParlamentarConfiguration : EntityTypeConfiguration<Parlamentar>
    {
        public ParlamentarConfiguration()
        {
            this.ToTable("GeralParlamentares");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasColumnName("id").IsRequired();
            this.Property(p => p.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();
            this.Property(p => p.NomeCompleto).HasColumnName("nomecompleto").HasMaxLength(255).IsOptional();
            this.Property(f => f.Excluido).HasColumnName("excluido").IsOptional();

            this.HasRequired(p => p.Setor).WithMany().HasForeignKey(p => p.IdSetor);
        }
    }
}