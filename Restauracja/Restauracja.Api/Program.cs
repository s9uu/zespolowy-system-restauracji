using Microsoft.EntityFrameworkCore;
using Restauracja.Api.Baza;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RestauracjaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Baza")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("Web", policy =>
        policy.WithOrigins("https://localhost:7291", "http://localhost:5248")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// baza aktualizuje się sama przy starcie
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
