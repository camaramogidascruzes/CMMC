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
    public class MigrationContext : DbContext
    {
        static MigrationContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public MigrationContext() : base("name=intranetdatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        /* Geral */
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<EmpresaContato> EmpresaContatos { get; set; }
        public virtual DbSet<EmpresasTipos> EmpresasTipos { get; set; }
        public virtual DbSet<TipoEmpresa> TiposEmpresa { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<FuncionarioContato> FuncionarioContatos { get; set; }
        public virtual DbSet<Ocupacao> Ocupacoes { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Domain.Entities.Geral.Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuariosGrupos { get; set; }
        public virtual DbSet<Parlamentar> Parlamentares { get; set; }
        public virtual DbSet<Patrimonio> Patrimonios { get; set; }
        public virtual DbSet<Setor> Setores { get; set; }

        /* Rede Sem Fio */
        public virtual DbSet<CategoriaUsuario> CategoriasUsuarioRedeSemFio { get; set; }
        public virtual DbSet<CodigoAcesso> CodigosAcessoRedeSemFio { get; set; }
        public virtual DbSet<UsuarioRedeSemFio> UsuariosRedeSemFio { get; set; }

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

            /* Geral*/
            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new EmpresaContatoConfiguration());
            modelBuilder.Configurations.Add(new EmpresasTiposConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioContatoConfiguration());
            modelBuilder.Configurations.Add(new GrupoConfiguration());
            modelBuilder.Configurations.Add(new OcupacaoConfiguration());
            modelBuilder.Configurations.Add(new SetorConfiguration());
            modelBuilder.Configurations.Add(new TipoEmpresaConfiguration());
            modelBuilder.Configurations.Add(new CMMC.Data.EntityConfigurations.Geral.UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioGrupoConfiguration());
            modelBuilder.Configurations.Add(new ParlamentarConfiguration());
            modelBuilder.Configurations.Add(new PatrimonioConfiguration());

            /* Rede Sem Fio */
            modelBuilder.Configurations.Add(new CategoriaUsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuarioRedeSemFioConfiguration());
            modelBuilder.Configurations.Add(new CodigoAcessoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}