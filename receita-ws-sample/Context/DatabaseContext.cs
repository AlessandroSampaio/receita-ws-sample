using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using ReceitaWsSample.Models;

namespace ReceitaWsSample.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DbSet<CadastroPessoaJuridica> CadastrosPessoaJuridica { get; set; }
        public DbSet<SocioAdministrador> SociosAdministradores { get; set; }

        public DatabaseContext () : base("LocalConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}