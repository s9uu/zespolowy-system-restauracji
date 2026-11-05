using Microsoft.EntityFrameworkCore;

namespace Restauracja.Api.Baza;

public class RestauracjaDbContext : DbContext
{
    public RestauracjaDbContext(DbContextOptions<RestauracjaDbContext> options) : base(options)
    {
    }

    public DbSet<Kategoria> Kategorie { get; set; }
    public DbSet<Danie> Dania { get; set; }
    public DbSet<Zamowienie> Zamowienia { get; set; }
    public DbSet<PozycjaZamowienia> PozycjeZamowien { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategoria>().HasData(DaneStartowe.Kategorie);
        modelBuilder.Entity<Danie>().HasData(DaneStartowe.Dania);
    }
}
