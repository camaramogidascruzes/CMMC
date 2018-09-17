using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class PatrimonioConfiguration : EntityTypeConfiguration<Patrimonio>
    {
        public PatrimonioConfiguration()
        {
            this.ToTable("GeralPatrimonios");
            this.HasKey(p => p.Id);
            this.Property(g => g.Id).HasColumnName("id").IsRequired();
            this.Property(g => g.Numero).HasColumnName("numero").IsRequired();
            this.Property(g => g.DataAquisicao).HasColumnName("dataaquisicao").IsOptional();
            this.Property(g => g.NumeroProcessoAquisicao).HasColumnName("numeroprocessoaquisicao").HasMaxLength(255).IsOptional();
            this.Property(g => g.DataLimiteGarantia).HasColumnName("datalimitegarantia").IsOptional();
            this.Property(g => g.Observacao).HasColumnName("observacao").IsOptional();
            this.Property(g => g.Excluido).HasColumnName("excluido").IsRequired();
        }
    }
}