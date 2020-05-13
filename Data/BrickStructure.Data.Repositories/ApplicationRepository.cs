using BrickStructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BrickStructure.Data.Repositories
{
    public class ApplicationRepository : DbContext, IRepositoryContext
    {
        private IEnumerable<string> OtherAssemblies { get; set; }

        public ApplicationRepository(DbContextOptions<ApplicationRepository> options, AssemblyMappingName mapName) : base(options)
        {
            OtherAssemblies = mapName?.FullNames;
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

            if (OtherAssemblies != null && OtherAssemblies.Any())
            {
                foreach (var assemblyName in OtherAssemblies)
                {
                    var element = Assembly.Load(assemblyName);
                    if (element != null)
                    {
                        modelBuilder.ApplyConfigurationsFromAssembly(element);
                    }
                }
            }
        }
    }
}
