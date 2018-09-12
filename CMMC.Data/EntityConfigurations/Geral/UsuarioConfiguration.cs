using System.Data.Entity.ModelConfiguration;
using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.EntityConfigurations.Geral
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            this.ToTable("GeralUsuarios");
            this.HasKey(u => u.Id);
            this.Property(u => u.Id).HasColumnName("id").IsRequired();
            this.Property(u => u.Login).HasColumnName("login").HasMaxLength(255).IsRequired();
            this.Property(u => u.Nome).HasColumnName("nome").HasMaxLength(255).IsRequired();
            this.Property(u => u.PasswordHash).HasColumnName("passwordhHash").HasMaxLength(255).IsRequired();
            this.Property(u => u.DataUltimoLogin).HasColumnName("dataultimologin").IsOptional();
            this.Property(u => u.QuantidadeFalhasAcesso).HasColumnName("quantidadefalhasacesso").IsOptional();
            this.Property(u => u.Bloqueado).HasColumnName("bloqueado").IsOptional();
            this.Property(u => u.TerminoBloqueio).HasColumnName("terminobloqueio").IsOptional();
            this.Property(u => u.Ip).HasColumnName("ipultimoacesso").HasMaxLength(255).IsRequired();
            this.Property(u => u.NecessarioAlterarSenha).HasColumnName("necessarioalterarsenha").IsOptional();

            this.HasMany(u => u.Grupos).WithRequired(u => u.Usuario).HasForeignKey(u => u.IdUsuario);
        }
    }
}