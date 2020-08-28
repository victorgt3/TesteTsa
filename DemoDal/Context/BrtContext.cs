using Demo.Dal.Extensions;
using Demo.Data.Mappings.Especialidade;
using Demo.Data.Mappings.Medico;
using Demo.Domain.Entitie.Especialidade;
using Demo.Domain.Entitie.Medico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Demo.Dal.Context
{
    public class BrtContext : DbContext
    {
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new MedicoMapping());
            modelBuilder.AddConfiguration(new EspecialidadeMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
