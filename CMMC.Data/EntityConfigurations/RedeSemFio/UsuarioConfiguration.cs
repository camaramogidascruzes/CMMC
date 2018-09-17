using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.RedeSemFio;

namespace CMMC.Data.EntityConfigurations.RedeSemFio
{
    public class UsuarioRedeSemFioConfiguration : EntityTypeConfiguration<UsuarioRedeSemFio>
    {
        public UsuarioRedeSemFioConfiguration()
        {
            this.ToTable("RedeSemFioUsuario");
            this.HasKey(r => r.Id);
            this.Property(a => a.Id).HasColumnName("id").IsRequired();
            this.Property(a => a.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();
            this.Property(r => r.Nascimento).HasColumnName("datanascimento").IsRequired();
            this.Property(a => a.Excluido).HasColumnName("excluido").IsOptional();

            this.HasRequired(r => r.FuncionarioCadastrante).WithMany().HasForeignKey(r => r.IdFuncionarioCadastrante);
            this.HasMany(u => u.Codigos).WithRequired(c => c.Usuario).HasForeignKey(c => c.IdUsuarioRedeSemFio);
        }
    }
}