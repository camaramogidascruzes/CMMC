using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CMMC.Data.EntityConfigurations;
using CMMC.Data.EntityConfigurations.Geral;
using CMMC.Data.EntityConfigurations.RedeSemFio;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Entities.RedeSemFio;

namespace CMMC.Data.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class GeralContext : DbContext
    {
        static GeralContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public GeralContext() : base("name=intranetdatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        /* Geral */
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuariosGrupos { get; set; }
        /* Rede Sem Fio */
        public virtual DbSet<CategoriaUsuario> CategoriasUsuarioRedeSemFio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new DadosCriacaoRegistroConfiguration());
            modelBuilder.Configurations.Add(new DadosAlteracaoRegistroConfiguration());
            modelBuilder.Configurations.Add(new InformacaoEnderecoConfiguration());
            modelBuilder.Configurations.Add(new InformacaoDocumentoConfiguration());
            modelBuilder.Configurations.Add(new InformacaoTelefoneConfiguration());

            modelBuilder.Configurations.Add(new GrupoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioGrupoConfiguration());
            /* Rede Sem Fio */
            modelBuilder.Configurations.Add(new CategoriaUsuarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}