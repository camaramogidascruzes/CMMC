using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            this.ToTable("GeralCargos");

            this.HasKey(c => c.Id);

            this.Property(c => c.Id).HasColumnName("id").IsRequired();
            this.Property(c => c.Nome).HasColumnName("nome").HasMaxLength(255);
            this.Property(f => f.Excluido).HasColumnName("excluido").IsOptional();

            this.HasMany(c => c.Funcionarios).WithRequired(f => f.Cargo).HasForeignKey(f => f.Idcargo);
        }
    }
}