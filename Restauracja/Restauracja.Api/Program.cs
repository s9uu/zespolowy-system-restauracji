var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Web działa na innym porcie, więc bez CORS przeglądarka zablokuje mu dane z Api.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Web", policy =>
        policy.WithOrigins("https://localhost:7291", "http://localhost:5248")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Web");

app.UseAuthorization();

app.MapControllers();

app.Run();
