using Microsoft.EntityFrameworkCore;
using Einkaufszettel.Domain;

namespace Einkaufszettel.Repository
{
    public class EinkaufContext : DbContext
    {
        public DbSet<Bedarf> Bedarfe { get; set; }

        public DbSet<Haushalt> Haushalte { get; set; }

        public DbSet<Produkt> Produkte { get; set; }

        public EinkaufContext() : base()
        {
            Console.WriteLine("constructing DbContext");
            
        }

        public EinkaufContext(DbContextOptions options) : base(options)
        {
            Console.WriteLine("constructing DbContext with options");
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("Configuring database");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            Console.WriteLine("Configuring conventions");
            configurationBuilder
                .Properties<Ulid>()
                .HaveConversion<UlidToStringConverter>()
                .HaveConversion<UlidToBytesConverter>();
        }
    }
}
