using BrickStructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BrickStructure.Data.Repositories
{
    public class AppContext : DbContext, IRepositoryContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
