using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CODENINJAS.TocaAqui.API.Shared.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using CODENINJAS.TocaAqui.API.IAM.Application.Internal.OutboundServices;

using CODENINJAS.TocaAqui.API.Events.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Events.Infrastructure.Repositories;
using CODENINJAS.TocaAqui.API.Events.Domain.Services;
using CODENINJAS.TocaAqui.API.Events.Application.Internal.CommandServices;
using CODENINJAS.TocaAqui.API.Events.Application.Internal.QueryServices;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Tokens.JWT.Services;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using CODENINJAS.TocaAqui.API.IAM.Domain.Repositories;
using CODENINJAS.TocaAqui.API.IAM.Domain.Services;
using CODENINJAS.TocaAqui.API.IAM.Application.Internal.CommandServices;
using CODENINJAS.TocaAqui.API.IAM.Application.Internal.QueryServices;
using CODENINJAS.TocaAqui.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using CODENINJAS.TocaAqui.API.Shared.Interfaces.ASP.Configuration;
using CODENINJAS.TocaAqui.API.Payments.Domain.Repositories;
using CODENINJAS.TocaAqui.API.Payments.Infrastructure.Persistence.EFC.Repositories;
using CODENINJAS.TocaAqui.API.Payments.Domain.Services;
using CODENINJAS.TocaAqui.API.Payments.Application.Internal.CommandServices;
using CODENINJAS.TocaAqui.API.Payments.Application.Internal.QueryServices;
using CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.CommandServices;
using CODENINJAS.TocaAqui.API.Evaluations.Application.Internal.QueryServices;
using CODENINJAS.TocaAqui.API.Evaluations.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// 1. Servicios de la aplicación
// --------------------------------------------------
builder.Services.AddControllers(opt =>
{
    // Convención kebab-case
    opt.Conventions.Add(new KebabCaseRouteNamingConvention());
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
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
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new Exception("Connection string is null");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString)
           .LogTo(Console.WriteLine,
                  builder.Environment.IsDevelopment() ? LogLevel.Information : LogLevel.Error)
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
});

// ------------- Dependencias de dominio ------------
// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Events
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventApplicantRepository, EventApplicantRepository>();
builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IRiderTechnicalRepository, RiderTechnicalRepository>();
builder.Services.AddScoped<IEventCommandService, EventCommandService>();
builder.Services.AddScoped<IEventQueryService, EventQueryService>();
builder.Services.AddScoped<IEventApplicantCommandService, EventApplicantCommandService>();
builder.Services.AddScoped<IInvitationCommandService, InvitationCommandService>();

// ---------- IAM bindings --------------------------
builder.Services.Configure<TokenSettings>(
    builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository,          UserRepository>();
builder.Services.AddScoped<IUserCommandService,      UserCommandService>();
builder.Services.AddScoped<IUserQueryService,        UserQueryService>();

// Payments
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();

// Evaluations
builder.Services.AddScoped<IEvaluationCommandService, EvaluationCommandService>();
builder.Services.AddScoped<IEvaluationQueryService, EvaluationQueryService>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();

// --------------------------------------------------
// 2. Construir app
// --------------------------------------------------
var app = builder.Build();

// ------------- Crear base de datos automáticamente ---------------
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        logger.LogInformation("Intentando crear/verificar la base de datos...");
        var created = context.Database.EnsureCreated();
        logger.LogInformation($"Base de datos creada (o ya existente): {created}");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error al crear la base de datos: {Message}", ex.Message);
    }
}

// ------------ Configure the HTTP request pipeline ----------------
//if (app.Environment.IsDevelopment())
//{
    // Swagger will be available also on production hosting
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "CODENINJAS.TocaAqui.API v1");
        ui.RoutePrefix = string.Empty;
    });
//}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// --- IAM auth middleware (valida tokens) ----------
app.UseRequestAuthorization();

app.MapControllers();
app.Run();