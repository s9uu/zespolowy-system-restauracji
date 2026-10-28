var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// CORS: pozwalamy stronie Restauracja.Web pobierać dane z Api.
// Bez tego przeglądarka zablokuje pobieranie, bo Web ma inny adres.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Web", policy =>
        policy.WithOrigins("https://localhost:7291", "http://localhost:5248")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Włączamy zasadę CORS "Web" z góry pliku.
app.UseCors("Web");

app.UseAuthorization();

app.MapControllers();

app.Run();
