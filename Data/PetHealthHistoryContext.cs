using Microsoft.EntityFrameworkCore;

namespace PetHealthHistory.Data;

// klasa kontekstu bazy danych Entity Framework
public class PetHealthHistoryContext : DbContext
{
    // definicje zbiorów (tabel) danych
    public DbSet<Pet> Pets { get; set; }
    
    public DbSet<Event> Events { get; set; }
    
    public DbSet<LabTestResult> LabTestResults { get; set; }
    
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
        modelBuilder.Entity<Pet>().HasMany(p => p.Events).WithOne().HasForeignKey(e => e.PetId);  // konfiguracja relacji jeden do wielu
        modelBuilder.Entity<Pet>().Navigation(p => p.Events).AutoInclude();                             // włącz automatyczne ładowanie powiązanych zdarzeń z bazy danych: https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager#model-configuration-for-auto-including-navigations
        modelBuilder.Entity<Pet>().HasDiscriminator(p => p.PetType)                                     // przechowywanie wszystkich typów zwierząt w jednej tabeli (i dostęp za pomocą jednej kolekcji generycznej): https://learn.microsoft.com/en-us/ef/core/modeling/inheritance#table-per-hierarchy-and-discriminator-configuration
            .HasValue<Cat>(PetType.Cat)
            .HasValue<Dog>(PetType.Dog);
        
        modelBuilder.Entity<Event>().HasKey(e => e.Id);                                                     // klucz główny
        modelBuilder.Entity<Event>().Property(e => e.EventType).HasConversion<string>().HasMaxLength(10);   // przechowywanie typu enum jako string zamiast liczby: https://stackoverflow.com/a/55260541 + maksymalna długość
        modelBuilder.Entity<Event>().HasDiscriminator(e => e.EventType)                                     // przechowywanie wszystkich typów zwierząt w jednej tabeli (i dostęp za pomocą jednej kolekcji generycznej): https://learn.microsoft.com/en-us/ef/core/modeling/inheritance#table-per-hierarchy-and-discriminator-configuration
            .HasValue<LabTest>(EventType.LabTest)
            .HasValue<Visit>(EventType.Visit)
            .HasValue<Procedure>(EventType.Procedure);
        
        modelBuilder.Entity<LabTest>().Property(l => l.LabName).HasMaxLength(100);                                      // maksymalna długość
        modelBuilder.Entity<LabTest>().Property(l => l.OrderedBy).HasMaxLength(100);                                    // maksymalna długość
        modelBuilder.Entity<LabTest>().HasMany(l => l.Results).WithOne().HasForeignKey(r => r.LabTestId);   // konfiguracja relacji jeden do wielu
        modelBuilder.Entity<LabTest>().Navigation(l => l.Results).AutoInclude();                                        // włącz automatyczne ładowanie powiązanych zdarzeń z bazy danych: https://learn.microsoft.com/en-us/ef/core/querying/related-data/eager#model-configuration-for-auto-including-navigations

        modelBuilder.Entity<Visit>().Property(v => v.Doctor).HasMaxLength(100);             // maksymalna długość
        modelBuilder.Entity<Visit>().Property(v => v.Clinic).HasMaxLength(100);             // maksymalna długość
        modelBuilder.Entity<Visit>().Property(v => v.Description).HasMaxLength(500);        // maksymalna długość
        
        modelBuilder.Entity<Procedure>().Property(p => p.Name).HasMaxLength(100);       // maksymalna długość
    }
}