using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities;


namespace CMMC.Data.EntityConfigurations
{
    public class DadosCriacaoRegistroConfiguration : ComplexTypeConfiguration<DadosCriacaoRegistro>
    {
        public DadosCriacaoRegistroConfiguration()
        {
            this.Property(t => t.DataCriacao).HasColumnName("DataCriacao").IsRequired();
            this.Property(t => t.UsuarioCriacao).HasColumnName("UsuarioCriacao").HasMaxLength(255).IsRequired();
        }
    }
}