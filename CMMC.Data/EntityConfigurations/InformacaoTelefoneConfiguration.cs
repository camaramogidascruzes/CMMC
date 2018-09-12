using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities;


namespace CMMC.Data.EntityConfigurations
{
    public class InformacaoTelefoneConfiguration : ComplexTypeConfiguration<InformacaoTelefone>
    {
        public InformacaoTelefoneConfiguration()
        {
            this.Property(ec => ec.TipoTelefone).HasColumnName("tipotelefone").IsOptional();
            this.Property(ec => ec.Numero).HasColumnName("numerotelefone").HasMaxLength(255).IsOptional();
            this.Property(ec => ec.Operadora).HasColumnName("operadoratelefone").HasMaxLength(255).IsOptional();
        }
    }
}