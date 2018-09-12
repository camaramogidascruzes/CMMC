using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities;


namespace CMMC.Data.EntityConfigurations
{
    public class InformacaoEnderecoConfiguration : ComplexTypeConfiguration<InformacaoEndereco>
    {
        public InformacaoEnderecoConfiguration()
        {
            this.Property(e => e.Cep).HasColumnName("cep").HasMaxLength(10).IsOptional();
            this.Property(e => e.Logradouro).HasColumnName("logradouro").HasMaxLength(255).IsOptional();
            this.Property(e => e.Numero).HasColumnName("numero").HasMaxLength(10).IsOptional();
            this.Property(e => e.Complemento).HasColumnName("complemento").HasMaxLength(255).IsOptional();
            this.Property(e => e.Bairro).HasColumnName("bairro").HasMaxLength(255).IsOptional();
            this.Property(e => e.Cidade).HasColumnName("cidade").HasMaxLength(255).IsOptional();
            this.Property(e => e.Uf).HasColumnName("uf").HasMaxLength(10).IsOptional();

        }
    }
}