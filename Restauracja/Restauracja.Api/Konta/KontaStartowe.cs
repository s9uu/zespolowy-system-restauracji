using Microsoft.AspNetCore.Identity;

namespace Restauracja.Api.Konta;

public static class KontaStartowe
{
    public static async Task UtworzAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var role = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var konta = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        foreach (var nazwa in new[] { "Klient", "Pracownik", "Administrator" })
        {
            if (!await role.RoleExistsAsync(nazwa))
                await role.CreateAsync(new IdentityRole(nazwa));
        }

        // konta startowe tylko na naszych komputerach
        if (!app.Environment.IsDevelopment())
            return;

        await UtworzKontoAsync(app, konta, "pracownik@przystole.test", "Pracownik", "KontaStartowe:HasloPracownika");
        await UtworzKontoAsync(app, konta, "admin@przystole.test", "Administrator", "KontaStartowe:HasloAdministratora");
    }

    private static async Task UtworzKontoAsync(WebApplication app, UserManager<IdentityUser> konta,
        string email, string rola, string kluczHasla)
    {
        if (await konta.FindByEmailAsync(email) != null)
            return;

        // hasło tylko z User Secrets, nigdy w kodzie
        var haslo = app.Configuration[kluczHasla];
        if (string.IsNullOrEmpty(haslo))
        {
            app.Logger.LogWarning("Brak {Klucz} w User Secrets, konto {Email} nie powstało.", kluczHasla, email);
            return;
        }

        var konto = new IdentityUser { UserName = email, Email = email };
        var wynik = await konta.CreateAsync(konto, haslo);
        if (!wynik.Succeeded)
        {
            var bledy = string.Join(" ", wynik.Errors.Select(b => b.Description).Distinct());
            app.Logger.LogWarning("Konto {Email} nie powstało: {Bledy}", email, bledy);
            return;
        }

        await konta.AddToRoleAsync(konto, rola);
    }
}
