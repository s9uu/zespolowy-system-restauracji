using Microsoft.EntityFrameworkCore;
using Restauracja.Api.Baza;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RestauracjaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Baza")));

// Web działa na innym porcie, więc bez CORS przeglądarka zablokuje mu dane z Api.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Web", policy =>
        policy.WithOrigins("https://localhost:7291", "http://localhost:5248")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Dzięki temu każdy dostaje aktualną bazę po F5, bez ręcznych poleceń.
using (var scope = app.Services.CreateScope())
{
    var baza = scope.ServiceProvider.GetRequiredService<RestauracjaDbContext>();
    baza.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Web");

app.UseAuthorization();

app.MapControllers();

app.Run();
