namespace CMMC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1709AdicionaFuncionarioAoUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeralUsuarios", "IdFuncionario", c => c.Int());
            CreateIndex("dbo.GeralUsuarios", "IdFuncionario");
            AddForeignKey("dbo.GeralUsuarios", "IdFuncionario", "dbo.GeralFuncionarios", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeralUsuarios", "IdFuncionario", "dbo.GeralFuncionarios");
            DropIndex("dbo.GeralUsuarios", new[] { "IdFuncionario" });
            DropColumn("dbo.GeralUsuarios", "IdFuncionario");
        }
    }
}
