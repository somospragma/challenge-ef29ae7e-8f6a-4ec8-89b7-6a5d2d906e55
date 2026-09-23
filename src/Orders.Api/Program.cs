using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.Api.Middleware;
using Orders.Application.Commands.CreateOrder;
using Orders.Application.Queries.GetOrderById;
using Orders.Infrastructure.Database.Command;
using Orders.Infrastructure.Database.Query;
using Orders.Infrastructure.Repositories.Command;
using Orders.Infrastructure.Repositories.Query;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateOrderCommandValidator>())
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Registro de MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetOrderByIdQueryHandler).Assembly);
});

// Configuración de DbContext para escritura
builder.Services.AddDbContext<OrdersCommandDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersCommandConnection"),
    sqlOptions => sqlOptions.MigrationsAssembly("Orders.Infrastructure")));

// Configuración de DbContext para lectura
builder.Services.AddDbContext<OrdersQueryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersQueryConnection"),
    sqlOptions => sqlOptions.MigrationsAssembly("Orders.Infrastructure")));

// Registro de repositorios
builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Orders API",
        Version = "v1",
        Description = "API para gestión de órdenes con separación CQRS"
    });
});

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Middleware de manejo de excepciones
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

namespace Orders.Api
{
    public partial class Program { }
}