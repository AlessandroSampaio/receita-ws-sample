using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using ReceitaWsSample.Models;

namespace ReceitaWsSample.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext () : base("AppConnectionString")
        {

        }

        public DbSet<CadastroPessoaJuridica> CadastrosPessoaJuridica { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}