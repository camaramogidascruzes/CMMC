using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class EmpresaContatoConfiguration : EntityTypeConfiguration<EmpresaContato>
    {
        public EmpresaContatoConfiguration()
        {
            this.ToTable("GeralEmpresaContatos");
            this.HasKey(ec => ec.Id);
            this.Property(t => t.Id).HasColumnName("id").IsRequired();
            this.Property(ec => ec.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();
            this.Property(f => f.Excluido).HasColumnName("excluido").IsOptional();

            this.HasRequired(ec => ec.Empresa).WithMany(e => e.Contatos);
        }
    }
}