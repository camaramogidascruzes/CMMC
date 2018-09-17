using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            this.ToTable("GeralEmpresa");
            this.HasKey(e => e.Id);
            this.Property(t => t.Id).HasColumnName("id").IsRequired();
            this.Property(e => e.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();
            this.Property(e => e.DocumentoCpfCnpjTipo).HasColumnName("documentotipodocumentocpfcnpj").IsOptional();
            this.Property(e => e.DocumentoCpfCnpj).HasColumnName("documentocpfcnpj").HasMaxLength(20).IsOptional();
            this.Property(e => e.Observacao).HasColumnName("observacao").IsOptional();
            this.Property(f => f.Excluido).HasColumnName("excluido").IsOptional();

            this.HasMany(e => e.Contatos).WithRequired(c => c.Empresa).HasForeignKey(c => c.IdEmpresa);
            this.HasMany(e => e.Tipos).WithRequired(c => c.Empresa).HasForeignKey(c => c.IdEmpresa);
        }

    }
}