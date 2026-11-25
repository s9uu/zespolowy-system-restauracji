using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restauracja.Api.Baza;
using Restauracja.Api.Konta;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RestauracjaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Baza")));

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<IdentityUser>(options => options.User.RequireUniqueEmail = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RestauracjaDbContext>()
    .AddErrorDescriber<PolskieBledyKont>()
    .AddApiEndpoints();

// Api nie ma strony logowania, więc zamiast przekierowania sam kod błędu
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
});

builder.Services.AddCors(options =>
{
    // AllowCredentials, bo bez tego przeglądarka nie wyśle ciasteczka logowania
    options.AddPolicy("Web", policy =>
        policy.WithOrigins("https://localhost:7291", "http://localhost:5248")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

var app = builder.Build();

// baza aktualizuje się sama przy starcie
using (var scope = app.Services.CreateScope())
{
    var baza = scope.ServiceProvider.GetRequiredService<RestauracjaDbContext>();
    baza.Database.Migrate();
}

await KontaStartowe.UtworzAsync(app);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Web");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGroup("/api/konto").MapIdentityApi<IdentityUser>();

app.Run();
