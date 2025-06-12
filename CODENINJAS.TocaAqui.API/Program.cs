using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;
using CODENINJAS.TocaAqui.API.Events.Domain.Services;
using CODENINJAS.TocaAqui.API.Events.Application.Internal.CommandServices;
using CODENINJAS.TocaAqui.API.Events.Application.Internal.QueryServices;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// 1. Servicios de la aplicación
// --------------------------------------------------
builder.Services.AddControllers();

// ------------ CORS para frontend ------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ------------ Swagger + JWT bearer ---------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CODENINJAS.TocaAqui.API",
        Version = "v1",
        Description = "API para eventos musicales TocaAquí - CODENINJAS"
    });

    // Especificar que usamos OpenAPI 3.0
    c.EnableAnnotations();
});

// ------------- EF Core MySQL ----------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    throw new Exception("Connection string is null");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    );
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        }
    );

// ------------- Dependencias de dominio ------------
// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Events
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventApplicantRepository, EventApplicantRepository>();
builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();
builder.Services.AddScoped<IEventCommandService, EventCommandService>();
builder.Services.AddScoped<IEventQueryService, EventQueryService>();
builder.Services.AddScoped<IEventApplicantCommandService, EventApplicantCommandService>();
builder.Services.AddScoped<IInvitationCommandService, InvitationCommandService>();

// --------------------------------------------------
// 2. Construir app
// --------------------------------------------------
var app = builder.Build();

// ------------- Crear base de datos automáticamente ---------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Swagger habilitado en todos los ambientes
app.UseSwagger();
app.UseSwaggerUI(ui =>
{
    ui.SwaggerEndpoint("/swagger/v1/swagger.json", "CODENINJAS.TocaAqui.API v1");
    ui.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();
app.Run();