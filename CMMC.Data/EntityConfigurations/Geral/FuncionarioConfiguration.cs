using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            this.ToTable("GeralFuncionarios");
            this.HasKey(f => f.Id);
            this.Property(t => t.Id).HasColumnName("id").IsRequired();
            this.Property(f => f.Nome).HasColumnName("nome").HasMaxLength(255);
            this.Property(f => f.Nascimento).HasColumnName("datanascimento");
            this.Property(f => f.Excluido).HasColumnName("excluido").IsRequired();

            this.HasOptional(f => f.Setor).WithMany(s => s.Funcionarios);
            this.HasMany(f => f.Cargos).WithRequired(c => c.Funcionario).HasForeignKey(f => f.Idfuncionario);
            this.HasMany(f => f.Contatos).WithRequired(c => c.Funcionario).HasForeignKey(c => c.IdFuncionario);
        }
    }
}