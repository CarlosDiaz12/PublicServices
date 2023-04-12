using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PublicServices.Core.Entities;
using System;

namespace PublicServices.DataAccess.Data
{
    public class AppDbContext: DbContext
    {
        public IConfiguration Configuration { get; }
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            // AzureDbContext
            //DefaultConnection
            var connectionString = Configuration.GetConnectionString("AzureDbContext") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            optionsBuilder
                .UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure specific rules for entities
            modelBuilder.Entity<HistorialCrediticio>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<IndiceInflacion>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<TasaCambiaria>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(x => x.Moneda);                    
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<HistorialCrediticio> HistorialCrediticio { get; set; }
        public DbSet<IndiceInflacion> IndiceInflacion { get; set; }
        public DbSet<Moneda> Moneda { get; set; }
        public DbSet<TasaCambiaria> TasaCambiaria { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }

    }
}
