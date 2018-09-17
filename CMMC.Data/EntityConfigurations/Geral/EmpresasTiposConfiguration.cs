using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class EmpresasTiposConfiguration : EntityTypeConfiguration<EmpresasTipos>
    {
        public EmpresasTiposConfiguration()
        {
            this.ToTable("GeralEmpresasTipos");
            this.HasKey(e => new
            {
                e.IdEmpresa,
                e.IdTipoEmpresa
            });
            this.HasRequired(et => et.Empresa).WithMany(e => e.Tipos);
            this.HasRequired(et => et.TipoEmpresa).WithMany(e => e.Empresas);
        }
    }
}