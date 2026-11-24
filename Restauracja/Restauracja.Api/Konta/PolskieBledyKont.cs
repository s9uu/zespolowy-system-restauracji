using Microsoft.AspNetCore.Identity;

namespace Restauracja.Api.Konta;

// login konta to e-mail, więc błędy loginu mają te same teksty co błędy e-maila
public class PolskieBledyKont : IdentityErrorDescriber
{
    public override IdentityError PasswordTooShort(int length) =>
        new() { Code = nameof(PasswordTooShort), Description = $"Hasło musi mieć co najmniej {length} znaków." };

    public override IdentityError PasswordRequiresDigit() =>
        new() { Code = nameof(PasswordRequiresDigit), Description = "Hasło musi mieć cyfrę." };

    public override IdentityError PasswordRequiresLower() =>
        new() { Code = nameof(PasswordRequiresLower), Description = "Hasło musi mieć małą literę." };

    public override IdentityError PasswordRequiresUpper() =>
        new() { Code = nameof(PasswordRequiresUpper), Description = "Hasło musi mieć wielką literę." };

    public override IdentityError PasswordRequiresNonAlphanumeric() =>
        new() { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Hasło musi mieć znak specjalny, np. ! albo #." };

    public override IdentityError DuplicateEmail(string email) =>
        new() { Code = nameof(DuplicateEmail), Description = "Konto z tym adresem e-mail już istnieje." };

    public override IdentityError DuplicateUserName(string userName) =>
        new() { Code = nameof(DuplicateUserName), Description = "Konto z tym adresem e-mail już istnieje." };

    public override IdentityError InvalidEmail(string? email) =>
        new() { Code = nameof(InvalidEmail), Description = "Niepoprawny adres e-mail." };

    public override IdentityError InvalidUserName(string? userName) =>
        new() { Code = nameof(InvalidUserName), Description = "Niepoprawny adres e-mail." };
}
