using Brka.Bank.Contas.Repository.Contas;
using Brka.Bank.Contas.Repository.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace Brka.Bank.Contas.Repository
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        
        public virtual  DbSet<ContaModel> Contas { get; set; }
        public virtual DbSet<TransacaoModel> Transacoes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}