using AMcom.Teste.DAL.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AMcom.Teste.DAL.ContextoBanco.Banco
{
    public class ContextAmcom : DbContext
    {
        public ContextAmcom(DbContextOptions<ContextAmcom> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UbsMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
