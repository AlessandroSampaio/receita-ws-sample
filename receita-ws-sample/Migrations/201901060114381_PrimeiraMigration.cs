namespace ReceitaWsSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CadastroPessoaJuridica",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(unicode: false),
                        NomeFantasia = c.String(unicode: false),
                        Uf = c.String(unicode: false),
                        Telefone = c.String(unicode: false),
                        Situacao = c.String(unicode: false),
                        Bairro = c.String(unicode: false),
                        Logradouro = c.String(unicode: false),
                        Numero = c.String(unicode: false),
                        Cep = c.String(unicode: false),
                        Municipio = c.String(unicode: false),
                        DataAbertura = c.String(unicode: false),
                        UltimaAtualizacao = c.DateTime(nullable: false, precision: 0),
                        Cnpj = c.String(unicode: false),
                        Tipo = c.String(unicode: false),
                        DataInclusao = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SocioAdministrador",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Ocupacao = c.String(unicode: false),
                        CadastroPessoaJuridica_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CadastroPessoaJuridica", t => t.CadastroPessoaJuridica_ID)
                .Index(t => t.CadastroPessoaJuridica_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocioAdministrador", "CadastroPessoaJuridica_ID", "dbo.CadastroPessoaJuridica");
            DropIndex("dbo.SocioAdministrador", new[] { "CadastroPessoaJuridica_ID" });
            DropTable("dbo.SocioAdministrador");
            DropTable("dbo.CadastroPessoaJuridica");
        }
    }
}
