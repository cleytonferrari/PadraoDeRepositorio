using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TISelvagem.RepositorioEF
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("TISelvagemEF")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());
        }

        public DbSet<AlunoDTO> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
