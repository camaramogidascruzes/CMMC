namespace CMMC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1709GeralRedeSemFio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeralCargos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 255, storeType: "nvarchar"),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GeralFuncionariosCargos",
                c => new
                    {
                        idcargo = c.Int(nullable: false),
                        idfuncionario = c.Int(nullable: false),
                        rgf = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.idcargo, t.idfuncionario })
                .ForeignKey("dbo.GeralFuncionarios", t => t.idfuncionario)
                .ForeignKey("dbo.GeralCargos", t => t.idcargo)
                .Index(t => t.idcargo)
                .Index(t => t.idfuncionario);
            
            CreateTable(
                "dbo.GeralFuncionarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 255, storeType: "nvarchar"),
                        documentocpf = c.String(maxLength: 30, storeType: "nvarchar"),
                        documentoidentidadenumero = c.String(maxLength: 30, storeType: "nvarchar"),
                        documentoidentidadeorgaoemissor = c.String(maxLength: 30, storeType: "nvarchar"),
                        datanascimento = c.DateTime(precision: 0),
                        IdSetor = c.Int(),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GeralSetores", t => t.IdSetor)
                .Index(t => t.IdSetor);
            
            CreateTable(
                "dbo.GeralFuncionarioContatos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipotelefone = c.Int(),
                        numerotelefone = c.String(maxLength: 255, storeType: "nvarchar"),
                        operadoratelefone = c.String(maxLength: 255, storeType: "nvarchar"),
                        IdFuncionario = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GeralFuncionarios", t => t.IdFuncionario)
                .Index(t => t.IdFuncionario);
            
            CreateTable(
                "dbo.GeralSetores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RedeSemFioCodigoAcesso",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        dataEmissao = c.DateTime(nullable: false, precision: 0),
                        validade = c.Int(nullable: false),
                        Quota = c.Int(nullable: false),
                        IdUsuarioRedeSemFio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RedeSemFioUsuario", t => t.IdUsuarioRedeSemFio)
                .Index(t => t.IdUsuarioRedeSemFio);
            
            CreateTable(
                "dbo.RedeSemFioUsuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        documentocpf = c.String(maxLength: 30, storeType: "nvarchar"),
                        documentoidentidadenumero = c.String(maxLength: 30, storeType: "nvarchar"),
                        documentoidentidadeorgaoemissor = c.String(maxLength: 30, storeType: "nvarchar"),
                        datanascimento = c.DateTime(nullable: false, precision: 0),
                        cep = c.String(maxLength: 10, storeType: "nvarchar"),
                        logradouro = c.String(maxLength: 255, storeType: "nvarchar"),
                        numero = c.String(maxLength: 10, storeType: "nvarchar"),
                        complemento = c.String(maxLength: 255, storeType: "nvarchar"),
                        bairro = c.String(maxLength: 255, storeType: "nvarchar"),
                        cidade = c.String(maxLength: 255, storeType: "nvarchar"),
                        uf = c.String(maxLength: 10, storeType: "nvarchar"),
                        tipotelefone = c.Int(),
                        numerotelefone = c.String(maxLength: 255, storeType: "nvarchar"),
                        operadoratelefone = c.String(maxLength: 255, storeType: "nvarchar"),
                        IdFuncionarioCadastrante = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GeralFuncionarios", t => t.IdFuncionarioCadastrante)
                .Index(t => t.IdFuncionarioCadastrante);
            
            CreateTable(
                "dbo.GeralEmpresaContatos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        tipotelefone = c.Int(),
                        numerotelefone = c.String(maxLength: 255, storeType: "nvarchar"),
                        operadoratelefone = c.String(maxLength: 255, storeType: "nvarchar"),
                        IdEmpresa = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GeralEmpresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.GeralEmpresa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        documentotipodocumentocpfcnpj = c.Int(),
                        documentocpfcnpj = c.String(maxLength: 20, storeType: "nvarchar"),
                        cep = c.String(maxLength: 10, storeType: "nvarchar"),
                        logradouro = c.String(maxLength: 255, storeType: "nvarchar"),
                        numero = c.String(maxLength: 10, storeType: "nvarchar"),
                        complemento = c.String(maxLength: 255, storeType: "nvarchar"),
                        bairro = c.String(maxLength: 255, storeType: "nvarchar"),
                        cidade = c.String(maxLength: 255, storeType: "nvarchar"),
                        uf = c.String(maxLength: 10, storeType: "nvarchar"),
                        observacao = c.String(unicode: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GeralEmpresasTipos",
                c => new
                    {
                        IdEmpresa = c.Int(nullable: false),
                        IdTipoEmpresa = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        TipoEmpresa_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdEmpresa, t.IdTipoEmpresa })
                .ForeignKey("dbo.GeralTipoEmpresa", t => t.TipoEmpresa_Id)
                .ForeignKey("dbo.GeralEmpresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa)
                .Index(t => t.TipoEmpresa_Id);
            
            CreateTable(
                "dbo.GeralTipoEmpresa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GeralParlamentares",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        nomecompleto = c.String(maxLength: 255, storeType: "nvarchar"),
                        IdSetor = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GeralSetores", t => t.IdSetor)
                .Index(t => t.IdSetor);
            
            CreateTable(
                "dbo.GeralPatrimonios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numero = c.Int(nullable: false),
                        dataaquisicao = c.DateTime(precision: 0),
                        numeroprocessoaquisicao = c.String(maxLength: 255, storeType: "nvarchar"),
                        datalimitegarantia = c.DateTime(precision: 0),
                        observacao = c.String(unicode: false),
                        DataCriacao = c.DateTime(nullable: false, precision: 0),
                        UsuarioCriacao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        DataUltimaAlteracao = c.DateTime(nullable: false, precision: 0),
                        UsuarioUltimaAlteracao = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeralParlamentares", "IdSetor", "dbo.GeralSetores");
            DropForeignKey("dbo.GeralEmpresaContatos", "IdEmpresa", "dbo.GeralEmpresa");
            DropForeignKey("dbo.GeralEmpresasTipos", "IdEmpresa", "dbo.GeralEmpresa");
            DropForeignKey("dbo.GeralEmpresasTipos", "TipoEmpresa_Id", "dbo.GeralTipoEmpresa");
            DropForeignKey("dbo.RedeSemFioCodigoAcesso", "IdUsuarioRedeSemFio", "dbo.RedeSemFioUsuario");
            DropForeignKey("dbo.RedeSemFioUsuario", "IdFuncionarioCadastrante", "dbo.GeralFuncionarios");
            DropForeignKey("dbo.GeralFuncionariosCargos", "idcargo", "dbo.GeralCargos");
            DropForeignKey("dbo.GeralFuncionarios", "IdSetor", "dbo.GeralSetores");
            DropForeignKey("dbo.GeralFuncionarioContatos", "IdFuncionario", "dbo.GeralFuncionarios");
            DropForeignKey("dbo.GeralFuncionariosCargos", "idfuncionario", "dbo.GeralFuncionarios");
            DropIndex("dbo.GeralParlamentares", new[] { "IdSetor" });
            DropIndex("dbo.GeralEmpresasTipos", new[] { "TipoEmpresa_Id" });
            DropIndex("dbo.GeralEmpresasTipos", new[] { "IdEmpresa" });
            DropIndex("dbo.GeralEmpresaContatos", new[] { "IdEmpresa" });
            DropIndex("dbo.RedeSemFioUsuario", new[] { "IdFuncionarioCadastrante" });
            DropIndex("dbo.RedeSemFioCodigoAcesso", new[] { "IdUsuarioRedeSemFio" });
            DropIndex("dbo.GeralFuncionarioContatos", new[] { "IdFuncionario" });
            DropIndex("dbo.GeralFuncionarios", new[] { "IdSetor" });
            DropIndex("dbo.GeralFuncionariosCargos", new[] { "idfuncionario" });
            DropIndex("dbo.GeralFuncionariosCargos", new[] { "idcargo" });
            DropTable("dbo.GeralPatrimonios");
            DropTable("dbo.GeralParlamentares");
            DropTable("dbo.GeralTipoEmpresa");
            DropTable("dbo.GeralEmpresasTipos");
            DropTable("dbo.GeralEmpresa");
            DropTable("dbo.GeralEmpresaContatos");
            DropTable("dbo.RedeSemFioUsuario");
            DropTable("dbo.RedeSemFioCodigoAcesso");
            DropTable("dbo.GeralSetores");
            DropTable("dbo.GeralFuncionarioContatos");
            DropTable("dbo.GeralFuncionarios");
            DropTable("dbo.GeralFuncionariosCargos");
            DropTable("dbo.GeralCargos");
        }
    }
}
