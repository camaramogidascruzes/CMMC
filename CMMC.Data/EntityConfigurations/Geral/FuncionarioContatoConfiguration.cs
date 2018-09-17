using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class FuncionarioContatoConfiguration : EntityTypeConfiguration<FuncionarioContato>
    {
        public FuncionarioContatoConfiguration()
        {
            this.ToTable("GeralFuncionarioContatos");
            this.HasKey(c => c.Id);
            this.Property(t => t.Id).HasColumnName("id").IsRequired();
            this.Property(f => f.Excluido).HasColumnName("excluido").IsOptional();

            this.HasRequired(c => c.Funcionario).WithMany(c => c.Contatos);
        }
    }
}