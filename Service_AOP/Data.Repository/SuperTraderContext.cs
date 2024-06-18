using Data.Entities;
using Data.Entities.Configurations;
using Data.Entities.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class SuperTraderContext : DbContext
    {
        public SuperTraderContext()
        {

        }

        public SuperTraderContext(DbContextOptions<SuperTraderContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\sqlexpress,1433;initial catalog=SuperTraderDB;Integrated Security=True;TrustServerCertificate=True;");

           
        }
        public DbSet<Data.Entities.User> Users { get; set; }
        public DbSet<Data.Entities.Share> Shares { get; set; }
        public DbSet<Data.Entities.SharePriceDetail> SharePriceDetails { get; set; }
        public DbSet<Data.Entities.Transaction> Transactions { get; set; }
        public DbSet<Data.Entities.ShareOwner> ShareOwners { get; set; }
        public DbSet<Data.Entities.Portfolio> Portfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SharePriceDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ShareConfiguration());
            modelBuilder.ApplyConfiguration(new ShareOwnerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new PortfolioConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
