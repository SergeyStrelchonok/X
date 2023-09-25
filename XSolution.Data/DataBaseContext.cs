using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XSolution.Data.Entities;

namespace XSolution.Data
{

    public class DataBaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataBaseContext()
        {
        }

        public DataBaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryProvince> CountryProvinces { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
            .HasMany(e => e.Provinces)
            .WithOne(e => e.Country)
            .HasForeignKey(e => e.CountryId)
            .IsRequired();

            modelBuilder.Entity<Country>()
            .HasMany(e => e.Users)
            .WithOne(e => e.Country)
            .HasForeignKey(e => e.CountryId)
            .IsRequired();

            modelBuilder.Entity<CountryProvince>()
            .HasMany(e => e.Users)
            .WithOne(e => e.Province)
            .HasForeignKey(e => e.CountryId)
            .IsRequired();
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("XDatabase"),
                 x => x.MigrationsAssembly("XSolution.Data"));
        }
    }
}
