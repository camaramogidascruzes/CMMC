namespace CMMC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RedeSemFioCategoriaUsuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        validade = c.Int(nullable: false),
                        quota = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GeralGrupos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, unicode: false),
                        bloqueado = c.Boolean(nullable: false),
                        IdCategoriaRedeSemFio = c.Int(),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RedeSemFioCategoriaUsuario", t => t.IdCategoriaRedeSemFio)
                .Index(t => t.IdCategoriaRedeSemFio);
            
            CreateTable(
                "dbo.GeralUsuarioGrupo",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false),
                        IdGrupo = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.IdUsuario, t.IdGrupo })
                .ForeignKey("dbo.GeralUsuarios", t => t.IdUsuario)
                .ForeignKey("dbo.GeralGrupos", t => t.IdGrupo)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdGrupo);
            
            CreateTable(
                "dbo.GeralUsuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        login = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        passwordhHash = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        dataultimologin = c.DateTime(precision: 0),
                        terminobloqueio = c.DateTime(precision: 0),
                        bloqueado = c.Boolean(),
                        quantidadefalhasacesso = c.Int(),
                        ipultimoacesso = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        necessarioalterarsenha = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeralGrupos", "IdCategoriaRedeSemFio", "dbo.RedeSemFioCategoriaUsuario");
            DropForeignKey("dbo.GeralUsuarioGrupo", "IdGrupo", "dbo.GeralGrupos");
            DropForeignKey("dbo.GeralUsuarioGrupo", "IdUsuario", "dbo.GeralUsuarios");
            DropIndex("dbo.GeralUsuarioGrupo", new[] { "IdGrupo" });
            DropIndex("dbo.GeralUsuarioGrupo", new[] { "IdUsuario" });
            DropIndex("dbo.GeralGrupos", new[] { "IdCategoriaRedeSemFio" });
            DropTable("dbo.GeralUsuarios");
            DropTable("dbo.GeralUsuarioGrupo");
            DropTable("dbo.GeralGrupos");
            DropTable("dbo.RedeSemFioCategoriaUsuario");
        }
    }
}
