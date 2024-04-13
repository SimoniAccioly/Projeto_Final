using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace CarteiraDoInvestidor.Repository
{
    public class CarteiraDoInvestidorContext : DbContext 
    {
        public CarteiraDoInvestidorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Carteiras> Carteiras { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Ativos> Ativos { get; set; }
        public DbSet<Plano> Planos { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarteiraDoInvestidorContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }



}