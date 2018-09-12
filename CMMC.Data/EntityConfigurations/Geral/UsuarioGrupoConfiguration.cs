using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class UsuarioGrupoConfiguration : EntityTypeConfiguration<UsuarioGrupo>
    {
        public UsuarioGrupoConfiguration()
        {
            this.ToTable("GeralUsuarioGrupo");
            this.HasKey(e => new
            {
                e.IdUsuario,
                e.IdGrupo
            });
            this.HasRequired(ug => ug.Usuario).WithMany(e => e.Grupos);
            this.HasRequired(ug => ug.Grupo).WithMany(e => e.Usuarios);
        }
    }
}