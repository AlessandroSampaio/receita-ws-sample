namespace ReceitaWsSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CadastroPessoaJuridica",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(),
                        NomeFantasia = c.String(),
                        Uf = c.String(),
                        Telefone = c.String(),
                        Situacao = c.String(),
                        Bairro = c.String(),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Cep = c.String(),
                        Municipio = c.String(),
                        DataAbertura = c.String(),
                        UltimaAtualizacao = c.DateTime(nullable: false),
                        Cnpj = c.String(),
                        Tipo = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CadastroPessoaJuridica");
        }
    }
}
