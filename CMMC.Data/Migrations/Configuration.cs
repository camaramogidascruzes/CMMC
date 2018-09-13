using CMMC.Domain.Entities.Geral;

namespace CMMC.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CMMC.Data.Context.MigrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(CMMC.Data.Context.MigrationContext context)
        {
            var loginUsuariopadrao = "fernando.komura";
            var loginUsuarioAdministrador = "administrador";
            var passwordhash = "AHjLWSHRHMUHbUvQ5O+vm3CXo2Mw5fLnmjc8qB0rzP5Pi5jSkNB6XaWqK4MkQqtD8g==";

            // Grupos
            var nomeGrupoUsuario = "Usuario";
            var nomeGrupoAdministrador = "Administrador";
            var nomeGrupoUsuarioPaperCut = "UsuarioPaperCut";

            context.Grupos.AddOrUpdate(g => g.Nome, new Grupo(loginUsuariopadrao)
            {
                Nome = nomeGrupoUsuario
            });

            context.Grupos.AddOrUpdate(g => g.Nome, new Grupo(loginUsuariopadrao)
            {
                Nome = nomeGrupoAdministrador
            });

            context.Grupos.AddOrUpdate(g => g.Nome, new Grupo(loginUsuariopadrao)
            {
                Nome = nomeGrupoUsuarioPaperCut
            });

            context.SaveChanges();

            var grupoUsuario = context.Grupos.FirstOrDefault(g => g.Nome == nomeGrupoUsuario);
            var grupoAdministrador = context.Grupos.FirstOrDefault(g => g.Nome == nomeGrupoAdministrador);
            var grupoUsuarioPaperCut = context.Grupos.FirstOrDefault(g => g.Nome == nomeGrupoUsuarioPaperCut);

            // Usuario

            context.Usuarios.AddOrUpdate(u => u.Login, new Usuario()
            {
                Login = loginUsuariopadrao,
                Nome = "Fernando da Silva Komura",
                PasswordHash = passwordhash,
                DataUltimoLogin = DateTime.MinValue,
                TerminoBloqueio = DateTime.MinValue,
                Bloqueado = false,
                QuantidadeFalhasAcesso = 0,
                Ip = "",
                NecessarioAlterarSenha = false,
            });

            context.Usuarios.AddOrUpdate(u => u.Login, new Usuario()
            {
                Login = loginUsuarioAdministrador,
                Nome = "Admin",
                PasswordHash = passwordhash,
                DataUltimoLogin = DateTime.MinValue,
                TerminoBloqueio = DateTime.MinValue,
                Bloqueado = false,
                QuantidadeFalhasAcesso = 0,
                Ip = "",
                NecessarioAlterarSenha = false,
            });

            context.SaveChanges();

            var usuarioPadrao = context.Usuarios.FirstOrDefault(u => u.Login == loginUsuariopadrao);
            var usuarioAdministrador = context.Usuarios.FirstOrDefault(u => u.Login == loginUsuarioAdministrador);
            
            // Assinala Usuario ao Grupo
            if (usuarioPadrao != null)
            {
                if (grupoUsuario != null)
                {
                    context.UsuariosGrupos.AddOrUpdate(ug => new {ug.IdGrupo, ug.IdUsuario}, new UsuarioGrupo(usuarioPadrao.Id, grupoUsuario.Id, loginUsuariopadrao));
                }
                if (grupoAdministrador != null)
                {
                    context.UsuariosGrupos.AddOrUpdate(ug => new { ug.IdGrupo, ug.IdUsuario }, new UsuarioGrupo(usuarioPadrao.Id, grupoAdministrador.Id, loginUsuariopadrao));
                }
            }

            if (usuarioAdministrador != null)
            {
                if (grupoUsuario != null)
                {
                    context.UsuariosGrupos.AddOrUpdate(ug => new { ug.IdGrupo, ug.IdUsuario }, new UsuarioGrupo(usuarioAdministrador.Id, grupoUsuario.Id, loginUsuariopadrao));
                }
                if (grupoAdministrador != null)
                {
                    context.UsuariosGrupos.AddOrUpdate(ug => new { ug.IdGrupo, ug.IdUsuario }, new UsuarioGrupo(usuarioAdministrador.Id, grupoAdministrador.Id, loginUsuariopadrao));
                }
                if (grupoUsuarioPaperCut != null)
                {
                    context.UsuariosGrupos.AddOrUpdate(ug => new { ug.IdGrupo, ug.IdUsuario }, new UsuarioGrupo(usuarioAdministrador.Id, grupoUsuarioPaperCut.Id, loginUsuariopadrao));
                }
            }

            context.SaveChanges();

        }
    }
}
