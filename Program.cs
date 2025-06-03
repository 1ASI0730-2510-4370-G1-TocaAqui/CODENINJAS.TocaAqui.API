using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using tocaaqui_backend.Domain.Users.Interfaces;
using tocaaqui_backend.Infrastructure.Auth;
using tocaaqui_backend.Infrastructure.Persistence;
using tocaaqui_backend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// 1. Servicios de la aplicación
// --------------------------------------------------
builder.Services.AddControllers();

// ------------ Swagger + JWT bearer ---------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TocaAquí – Auth API",
        Version = "v1",
        Description = "Endpoints de autenticación (login, register, logout)"
    });

    // Seguridad JWT en Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT en formato: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id   = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ------------- MediatR ----------------------------
builder.Services.AddMediatR(typeof(Program));

// ------------- EF Core MySQL ----------------------
var conn = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(conn, ServerVersion.AutoDetect(conn)));

// ------------- JWT settings -----------------------
var jwtSection = builder.Configuration.GetSection("Jwt");
var secretKey = Encoding.UTF8.GetBytes(jwtSection["Secret"]!);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
        };
    });

builder.Services.AddAuthorization();

// ------------- Dependencias de dominio ------------
builder.Services.AddScoped<IUserRepository, EfUserRepository>(); // EF Core repo
builder.Services.AddSingleton<IJwtGenerator, JwtGenerator>();    // JWT real

// --------------------------------------------------
// 2. Construir app
// --------------------------------------------------
var app = builder.Build();

// Swagger visible en dev
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
app.UseAuthentication();   // <-- habilita JWT
app.UseAuthorization();

app.MapControllers();
app.Run();
