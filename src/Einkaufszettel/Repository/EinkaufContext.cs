using Microsoft.EntityFrameworkCore;
using Einkaufszettel.Domain;

namespace Einkaufszettel.Repository
{
    public class EinkaufContext : DbContext
    {
        public DbSet<Bedarf> Bedarfe { get; set; }

        public DbSet<Haushalt> Haushalte { get; set; }

        public DbSet<Produkt> Produkte { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("sqlite:///Einkaufszettel.db");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Ulid>()
                .HaveConversion<UlidToStringConverter>()
                .HaveConversion<UlidToBytesConverter>();
        }
    }
}
