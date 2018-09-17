using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class SetorConfiguration : EntityTypeConfiguration<Setor>
    {
        public SetorConfiguration()
        {
            this.ToTable("GeralSetores");
            this.HasKey(s => s.Id);
            this.Property(p => p.Id).HasColumnName("id").IsRequired();
            this.Property(s => s.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();

            this.HasMany(s => s.Funcionarios).WithOptional(f => f.Setor).HasForeignKey(f => f.IdSetor);
        }

    }
}