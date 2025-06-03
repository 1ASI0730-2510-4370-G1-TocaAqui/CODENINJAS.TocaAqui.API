using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using tocaaqui_backend.Domain.Users.Interfaces;
using tocaaqui_backend.Infrastructure.Auth;
using tocaaqui_backend.Infrastructure.Persistence;
using tocaaqui_backend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// -------------------- Servicios --------------------
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TocaAquí – Auth API",
        Version = "v1",
        Description = "Endpoints de autenticación (login, register, logout)"
    });
});

// MediatR
builder.Services.AddMediatR(typeof(Program));

// DbContext: MySQL
var conn = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(conn, ServerVersion.AutoDetect(conn)));

// Repositorio y JWT
builder.Services.AddScoped<IUserRepository, EfUserRepository>(); // EF Core
builder.Services.AddSingleton<IJwtGenerator, FakeJwtGenerator>();

// -------------------- App --------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "TocaAquí Auth v1");
        ui.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
