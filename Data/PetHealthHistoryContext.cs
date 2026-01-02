using Microsoft.EntityFrameworkCore;

namespace PetHealthHistory.Data;

// klasa kontekstu bazy danych Entity Framework
public class PetHealthHistoryContext : DbContext
{
    // definicje zbiorów (tabel) danych
    public DbSet<Pet> Pets { get; set; }
    
    public PetHealthHistoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // konfigracja zwierzęcia
        modelBuilder.Entity<Pet>().HasKey(p => p.Id);                                                   // klucz główny
        modelBuilder.Entity<Pet>().Property(p => p.Name).HasMaxLength(100);                             // maksymalna długość
        modelBuilder.Entity<Pet>().Property(p => p.Kind).HasMaxLength(100);                             // maksymalna długość
        modelBuilder.Entity<Pet>().Property(p => p.PetType).HasConversion<string>().HasMaxLength(10);   // przechowywanie typu enum jako string zamiast liczby: https://stackoverflow.com/a/55260541 + maksymalna długość
        modelBuilder.Entity<Pet>()
            .HasDiscriminator(p => p.PetType)                                                           // przechowywanie wszystkich typów zwierząt w jednej tabeli (i dostęp za pomocą jednej kolekcji generycznej): https://learn.microsoft.com/en-us/ef/core/modeling/inheritance#table-per-hierarchy-and-discriminator-configuration
            .HasValue<Cat>(PetType.Cat)
            .HasValue<Dog>(PetType.Dog);
    }
}