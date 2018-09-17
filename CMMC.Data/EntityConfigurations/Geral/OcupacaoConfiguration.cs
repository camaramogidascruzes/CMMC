using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class OcupacaoConfiguration : EntityTypeConfiguration<Ocupacao>
    {
        public OcupacaoConfiguration()
        {
            this.ToTable("GeralFuncionariosCargos");
            this.HasKey(o => new
            {
                o.Idcargo,
                o.Idfuncionario
            });

            this.Property(o => o.Idcargo).HasColumnName("idcargo").IsRequired();
            this.Property(o => o.Idfuncionario).HasColumnName("idfuncionario").IsRequired();
            this.Property(c => c.Rgf).HasColumnName("rgf").IsRequired();

            this.HasRequired(o => o.Funcionario).WithMany(func => func.Cargos);
            this.HasRequired(o => o.Cargo).WithMany(func => func.Funcionarios);
        }
    }
}