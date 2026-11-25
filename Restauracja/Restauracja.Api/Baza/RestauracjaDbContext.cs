using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Restauracja.Api.Baza;

public class RestauracjaDbContext : IdentityDbContext<IdentityUser>
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
        // tabele kont i ról z Identity
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kategoria>().HasData(DaneStartowe.Kategorie);
        modelBuilder.Entity<Danie>().HasData(DaneStartowe.Dania);

        // po usunięciu konta zamówienie zostaje, tylko bez konta
        modelBuilder.Entity<Zamowienie>()
            .HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(z => z.UzytkownikId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
