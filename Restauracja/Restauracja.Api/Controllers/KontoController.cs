using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Restauracja.Api.Controllers;

// logowanie i manage/info daje MapIdentityApi w Program.cs
[ApiController]
[Route("api/konto")]
public class KontoController : ControllerBase
{
    private readonly UserManager<IdentityUser> konta;
    private readonly SignInManager<IdentityUser> logowanie;

    public KontoController(UserManager<IdentityUser> konta, SignInManager<IdentityUser> logowanie)
    {
        this.konta = konta;
        this.logowanie = logowanie;
    }

    [HttpPost("rejestracja")]
    public async Task<IActionResult> Rejestracja(RegisterRequest dane)
    {
        var konto = new IdentityUser { UserName = dane.Email, Email = dane.Email };
        var wynik = await konta.CreateAsync(konto, dane.Password);

        if (!wynik.Succeeded)
        {
            // zajęty e-mail daje dwa błędy z tym samym tekstem, zostawiamy jeden
            foreach (var blad in wynik.Errors.DistinctBy(b => b.Description))
                ModelState.AddModelError(blad.Code, blad.Description);

            return ValidationProblem(ModelState);
        }

        await konta.AddToRoleAsync(konto, "Klient");
        return Ok();
    }

    // taki sam format jak /roles w przykładzie Microsoftu, bo tak czyta go Web
    [Authorize]
    [HttpGet("role")]
    public IActionResult Role()
    {
        var identity = (ClaimsIdentity)User.Identity!;
        var role = identity.FindAll(identity.RoleClaimType)
            .Select(c => new { c.Issuer, c.OriginalIssuer, c.Type, c.Value, c.ValueType });

        return Ok(role);
    }

    // w treści {} jak /logout w przykładzie Microsoftu
    [Authorize]
    [HttpPost("wyloguj")]
    public async Task<IActionResult> Wyloguj([FromBody] object pusty)
    {
        await logowanie.SignOutAsync();
        return Ok();
    }
}
