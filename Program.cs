using MediatR;
using Microsoft.OpenApi.Models;
using tocaaqui_backend.Domain.Users.Interfaces;
using tocaaqui_backend.Infrastructure.Repositories;
using tocaaqui_backend.Infrastructure.Auth;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------
// 1. Registramos servicios de la aplicaci�n
// ----------------------------------------------
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TocaAqu� � Auth API",
        Version = "v1",
        Description = "Endpoints de autenticaci�n (login, register, logout)"
    });

    // Si luego usas JWT real, aqu� se agregan esquemas de seguridad.
});

// MediatR (CQRS)
builder.Services.AddMediatR(typeof(Program)); // escanea este ensamblado

// Dependencias de dominio / infraestructura
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IJwtGenerator, FakeJwtGenerator>();

// ----------------------------------------------
// 2. Construimos la aplicaci�n
// ----------------------------------------------
var app = builder.Build();

// ----------------------------------------------
// 3. Pipeline HTTP
// ----------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TocaAqu� Auth v1");
        c.RoutePrefix = string.Empty; // Swagger en la ra�z /
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
