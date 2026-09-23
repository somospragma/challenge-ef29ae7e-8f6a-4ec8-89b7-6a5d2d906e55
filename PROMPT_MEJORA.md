# Prompt para Mejorar el Codigo Base

Copia y pega el contenido del bloque de abajo en un asistente de IA (Claude, ChatGPT)
para obtener un ZIP con el proyecto completo y arrancable.

Si preferis trabajar en tu editor con un agente local (Claude Code, Cursor, Copilot), usa `AGENTS.md` en vez de este archivo: dice lo mismo pero para que escriba los archivos en disco.

## Las dos reglas que no se negocian

1. **Completa el boilerplate.** Todo lo que el proyecto necesita para compilar y arrancar: manifiesto de dependencias, punto de entrada, configuracion, capa de interfaz, y las capas del patron arquitectonico declarado. Eso es andamiaje y es tu trabajo.
2. **NO resuelvas el reto.** Los entregables de las fases son el trabajo de la persona. El hueco pedagogico se deja como esta: el proyecto arranca, pero lo que el reto pide implementar NO esta implementado.

Dicho de otra forma: si algo impide compilar, arreglalo. Si algo es logica de negocio incompleta, validaciones ausentes, un secreto hardcodeado o un patron mejorable, dejalo exactamente como esta — es lo que la persona tiene que encontrar.

## Lo que le falta a este proyecto

Esto NO lo tenes que adivinar: salio de comparar el proyecto contra la arquitectura declarada del reto y de un analisis estatico del codigo. Completalo TODO.

### Archivos corruptos — arreglar primero

El contenido no corresponde a la extension. Regeneralos completos:

- `src/Orders.Api/appsettings.json` — El contenido no corresponde a un archivo json. Hay que regenerarlo completo.

## Como saber que terminaste

```bash
dotnet build
```

Ese comando corriendo sin errores es la definicion de "listo".

---

```
## Briefing del reto (autoridad)
Este bloque manda sobre los archivos adjuntos. El stack y el rol salen de AQUÍ, no de un topic genérico ni de markdown placeholder.

### Perfil
Chapter Backend, Especialidad Desarrollador, Tecnología .NET, Senior

### Brecha de conocimiento
Separa los comandos de las consultas y justifica el trade-off de consistencia que introduce

### Misión / candidato
Rediseñar el modulo de ordenes con lectura y escritura separadas

### Datos adicionales
Candidato con 6 años en .NET

### Reto
- Tema: Separacion de responsabilidades con CQRS
- Seniority: senior-l2
- Tipo: mixed
- Título: Rediseño del Módulo de Órdenes con CQRS
- Tiempo estimado: 15 horas

### Fases (trabajo del HUMANO — PROHIBIDO completarlas)
No implementes estos entregables. Dejalos como hueco pedagógico. El asistente solo materializa el proyecto arrancable para que el participante pueda trabajar.
- Fase 1: Exploración y Modelado Inicial — objetivo: Identificar las operaciones de lectura y escritura en el módulo de órdenes y modelar los comandos y consultas separadamente. — entregable (NO resolver): Modelo conceptual de comandos y consultas separados para el módulo de órdenes.
- Fase 2: Implementación de Comandos y Consultas — objetivo: Implementar los comandos y consultas separados en el módulo de órdenes. — entregable (NO resolver): Componentes implementados para manejar comandos y consultas separados en el módulo de órdenes.
- Fase 3: Evaluación y Justificación del Trade-off — objetivo: Evaluar el impacto del trade-off de consistencia introducido por la separación de comandos y consultas y justificar la decisión. — entregable (NO resolver): Evaluación y justificación del trade-off de consistencia introducido por la separación de comandos y consultas.

Eres un asistente experto en análisis, corrección y generación de archivos de cualquier tipo:
código fuente, documentación, hojas de cálculo, documentos Word, configuraciones, entre otros.
Voy a enviarte una cadena de texto que contiene uno o más archivos. Cada archivo está delimitado por un marcador con el siguiente formato:
// === ARCHIVO: ruta/del/archivo.extension ===
o también puede aparecer como:
## === ARCHIVO: ruta/del/archivo.extension ===
Lo que sigue al marcador puede ser:

El contenido real del archivo (código, texto, YAML, etc.)
Una descripción en lenguaje natural de lo que debe contener el archivo


TU TAREA
PASO 0 — ¿Esto es un proyecto o una carcasa?
Antes de extraer archivos, leé el Briefing (si está) y diagnosticá el adjunto.

Es CARCASA si ocurre CUALQUIERA de estas:
- No hay manifiesto de dependencias del stack del briefing (manifest.json de VTEX IO / package.json / pom.xml / build.gradle / requirements.txt / go.mod / *.tf / *.csproj, según corresponda)
- Hay un "binario" que en realidad es un comentario ("no puede ser mostrado como texto plano", placeholder .fig/.docx vacío)
- Los markdowns ya completan entregables de fases posteriores ("se implementó fade-in", lista de áreas ya resuelta)

Si es CARCASA:
- MATERIALIZÁ un proyecto que arranca en el stack del briefing (VTEX IO Store Framework, Angular, Terraform, pytest, Nest, etc.). Incluí manifiesto, punto de entrada y capa de interfaz reales.
- NO copies los markdowns de "solución" como si fueran el producto. Son ruido de generación.
- NO resuelvas las fases del briefing (están marcadas PROHIBIDO). Dejá el hueco pedagógico: el flujo existe, las microinteracciones/calidad/infra que el reto pide NO están hechas.
- Después seguí al PASO 5 (ZIP).

Si es un proyecto REAL (manifiesto + código que compila o arranca):
- Seguí PASO 1 en adelante. 🔴 compilación sí. 🟡 pedagógico no.

PASO 1 — Detección y extracción
Identifica todos los archivos presentes en la cadena. Para cada archivo extrae:

Su ruta completa (ej: src/main/java/com/pragma/Service.java)
Su contenido o descripción

PASO 2 — Clasificación por tipo
Clasifica cada archivo en una de estas categorías:
A) Código fuente (Java, Python, TypeScript, JavaScript, Kotlin, etc.)
B) Configuración / documentación (YAML, properties, Markdown, JSON, txt, etc.)
C) Excel (.xlsx, .xls, .csv)
D) Word (.docx, .doc)
E) Otro tipo de archivo binario o especial
PASO 3 — Clasificación de errores en código fuente

Objetivo prioritario: que el proyecto compile. No corrijas flujo de negocio ni lógica funcional.

Antes de modificar cualquier archivo de código fuente, clasifica cada problema encontrado en una de estas dos categorías:
🔴 ERROR DE COMPILACIÓN — corregir siempre
Son errores que impiden que el proyecto arranque, sin valor pedagógico:

Import faltante o incorrecto
Clase, método o variable referenciada que no existe en ningún archivo del proyecto
Error de sintaxis
Anotación con atributos inválidos
Dependencia ausente en pom.xml, package.json, etc.
Archivo referenciado que no existe y debe ser creado con implementación mínima

→ CORREGIR estos errores.
🟡 PROBLEMA FUNCIONAL O DE CALIDAD — preservar siempre
Son problemas que no impiden compilar. Pueden ser intencionales para el aprendizaje:

Clave secreta hardcodeada ("secret", "password123")
API deprecada que funciona pero tiene reemplazo moderno
Lógica de negocio incorrecta o incompleta
Código redundante o de baja legibilidad
Falta de validaciones en flujo de negocio
Patrones de diseño incorrectos pero funcionales
Concurrencia no segura
Configuración funcional pero no óptima

→ PRESERVAR tal cual. No corregir, no mejorar, no comentar.
PASO 4 — Procesamiento según tipo de archivo
Tipo A — Código fuente
Aplica únicamente las correcciones clasificadas como 🔴 ERROR DE COMPILACIÓN.
No alteres ningún elemento clasificado como 🟡 PROBLEMA FUNCIONAL O DE CALIDAD.
Si falta un archivo referenciado, créalo con la implementación mínima necesaria para compilar.
Tipo B — Configuración / documentación
Extrae el contenido tal cual, sin modificaciones salvo errores evidentes de sintaxis
(ej: YAML mal indentado).
Tipo C — Excel (.xlsx)
Si viene con contenido real, genera el archivo respetando ese contenido.
Si viene con descripción en lenguaje natural, genera un archivo Excel funcional con:

Fila de encabezados en negrita con color de fondo distintivo
Columnas con ancho ajustado al contenido
Tipos de dato correctos por columna
Validaciones si la descripción lo indica
Hojas nombradas descriptivamente si hay más de una
Filas de ejemplo si no hay datos reales

Tipo D — Word (.docx)
Si viene con contenido real, genera el archivo respetando ese contenido.
Si viene con descripción en lenguaje natural, genera un documento Word funcional con:

Estilos de título (Título 1, Título 2) para jerarquía de secciones
Fuente legible (Calibri o equivalente), tamaño 11-12pt para cuerpo
Márgenes estándar
Tabla de contenido si tiene múltiples secciones
Tablas con encabezados en negrita si aplica

Tipo E — Otro
Genera el archivo con el contenido o estructura más apropiada según la descripción.
PASO 5 — Exportación en ZIP
Empaqueta todos los archivos en un único archivo ZIP descargable respetando exactamente
la estructura de rutas indicada por los marcadores.
El ZIP debe incluir:

Archivos de código con únicamente los errores de compilación corregidos
Archivos de configuración y documentación sin cambios
Archivos nuevos creados para resolver dependencias de compilación faltantes
Archivos Excel y Word generados desde descripción

IMPORTANTE: El ZIP debe estar listo para descargar al finalizar. No preguntes si el usuario
quiere generarlo. Simplemente genera el archivo y proporciona el enlace de descarga; No debes desplegar en el chat el resumen de lo que arreglaste al Zip, solo entregalo.

REGLAS IMPORTANTES

No omitas ningún archivo aunque no tenga errores ni modificaciones
Respeta los nombres y rutas exactas indicadas por los marcadores
Si un archivo no tiene marcador claro, infiere el nombre desde su contenido
Si la cadena contiene solo documentación, placeholders o binarios fake, NO la reproduzcas:
aplicá PASO 0 (materializar el proyecto del briefing). Reproducir la carcasa es un fallo.
No agregues texto después del enlace de descarga del ZIP
No preguntes si el usuario quiere el ZIP: simplemente generalo siempre
Si detectas que falta un archivo de configuración necesario para compilar
(pom.xml, package.json, requirements.txt, build.gradle, etc.), créalo e inclúyelo
inferiendo su contenido desde los imports y frameworks detectados en el código
Nunca corrijas problemas 🟡 aunque parezcan obvios o fáciles de mejorar.
El participante que recibirá este proyecto los debe encontrar y resolver él mismo.


INPUT
Aquí está la cadena con los archivos:

// === ARCHIVO: Orders.Api.csproj ===
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <RootNamespace>Orders.Api</RootNamespace>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <NoWarn>$(NoWarn);1591</NoWarn>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MediatR" Version="12.1.0" />
    <PackageReference Include="Microsoft.AspNetCore.App" Version="9.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.0" />
    <PackageReference Include="Dapper" Version="2.1.24" />
    <PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />
    <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="9.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="9.0.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Orders.Application\Orders.Application.csproj" />
    <ProjectReference Include="..\Orders.Domain\Orders.Domain.csproj" />
    <ProjectReference Include="..\Orders.Infrastructure\Orders.Infrastructure.csproj" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Moq" Version="4.20.70" PrivateAssets="all" />
    <PackageReference Include="xunit" Version="2.8.1" PrivateAssets="all" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.3" PrivateAssets="all" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" PrivateAssets="all" />
  </ItemGroup>
</Project>

// === ARCHIVO: src/Orders.Api/Program.cs ===
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

// === ARCHIVO: src/Orders.Api/appsettings.json ===
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "OrdersCommandConnection": "Server=(localdb)\mssqllocaldb;Database=OrdersCommandDb;Trusted_Connection=True;MultipleActiveResultSets=true",
    "OrdersQueryConnection": "Server=(localdb)\mssqllocaldb;Database=OrdersQueryDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Swagger": {
    "Enabled": true
  }
}


// === ARCHIVO: src/Orders.Domain/Entities/Order.cs ===
using System;
using System.Collections.Generic;
using FluentValidation;

namespace Orders.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal TotalAmount { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
    private readonly List<OrderItem> _items = new();

    public Order(Guid customerId, IEnumerable<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        Status = OrderStatus.Pending;

        var itemList = items.ToList();
        if (!itemList.Any())
            throw new ArgumentException("An order must have at least one item.", nameof(items));

        _items.AddRange(itemList);
        TotalAmount = _items.Sum(i => i.Price * i.Quantity);
    }

    public void MarkAsPaid()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be marked as paid.");
        Status = OrderStatus.Paid;
    }

    public void MarkAsShipped()
    {
        if (Status != OrderStatus.Paid)
            throw new InvalidOperationException("Only paid orders can be marked as shipped.");
        Status = OrderStatus.Shipped;
    }

    public void MarkAsCancelled()
    {
        if (Status == OrderStatus.Shipped)
            throw new InvalidOperationException("Shipped orders cannot be cancelled.");
        Status = OrderStatus.Cancelled;
    }

    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
        TotalAmount = _items.Sum(i => i.Price * i.Quantity);
    }

    public void RemoveItem(Guid productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) throw new KeyNotFoundException("Item not found in order.");
        _items.Remove(item);
        TotalAmount = _items.Sum(i => i.Price * i.Quantity);
    }
}

public class OrderItem
{
    public Guid ProductId { get; }
    public string ProductName { get; }
    public decimal Price { get; }
    public int Quantity { get; }

    public OrderItem(Guid productId, string productName, decimal price, int quantity)
    {
        ProductId = productId;
        ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
        Price = price > 0 ? price : throw new ArgumentException("Price must be positive.", nameof(price));
        Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be positive.", nameof(quantity));
    }
}

public enum OrderStatus
{
    Pending,
    Paid,
    Shipped,
    Cancelled
}

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.CustomerId).NotEmpty();
        RuleFor(o => o.Items).NotEmpty().WithMessage("An order must have at least one item.");
        RuleForEach(o => o.Items).SetValidator(new OrderItemValidator());
    }
}

public class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {
        RuleFor(i => i.ProductId).NotEmpty();
        RuleFor(i => i.ProductName).NotEmpty().MaximumLength(100);
        RuleFor(i => i.Price).GreaterThan(0);
        RuleFor(i => i.Quantity).GreaterThan(0);
    }
}

// === ARCHIVO: src/Orders.Domain/Interfaces/IOrderCommandRepository.cs ===
using System;
using System.Threading;
using System.Threading.Tasks;
using Orders.Domain.Entities;

namespace Orders.Domain.Interfaces;

public interface IOrderCommandRepository
{
    Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Order order, CancellationToken cancellationToken = default);
    Task UpdateAsync(Order order, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

// === ARCHIVO: src/Orders.Domain/Interfaces/IOrderQueryRepository.cs ===
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Orders.Domain.Entities;

namespace Orders.Domain.Interfaces;

public interface IOrderQueryRepository
{
    Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default);
    Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
}

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; }
    public int TotalCount { get; }
    public int PageNumber { get; }
    public int PageSize { get; }

    public PagedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
    {
        Items = items ?? throw new ArgumentNullException(nameof(items));
        TotalCount = totalCount;
        PageNumber = pageNumber > 0 ? pageNumber : throw new ArgumentException("Page number must be positive.", nameof(pageNumber));
        PageSize = pageSize > 0 ? pageSize : throw new ArgumentException("Page size must be positive.", nameof(pageSize));
    }
}


// === ARCHIVO: src/Orders.Infrastructure/Repositories/Command/OrderCommandRepository.cs ===
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repositories.Command
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly OrdersCommandDbContext _context;

        public OrderCommandRepository(OrdersCommandDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task AddAsync(Order order, CancellationToken cancellationToken = default)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Order order, CancellationToken cancellationToken = default)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = await _context.Orders
               .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
            if (order!= null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

// === ARCHIVO: src/Orders.Infrastructure/Repositories/Query/OrderQueryRepository.cs ===
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Repositories.Query
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly OrdersQueryDbContext _context;

        public OrderQueryRepository(OrdersQueryDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .Where(o => o.CustomerId == customerId)
               .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .Where(o => o.Status == status)
               .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Orders
               .Include(o => o.Items)
               .Where(o => o.CreationDate >= startDate && o.CreationDate <= endDate)
               .ToListAsync(cancellationToken);
        }

        public async Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var skip = (pageNumber - 1) * pageSize;
            var orders = await _context.Orders
               .Include(o => o.Items)
               .Skip(skip)
               .Take(pageSize)
               .ToListAsync(cancellationToken);
            var totalCount = await _context.Orders.CountAsync(cancellationToken);
            return new PagedResult<Order>(orders, totalCount, pageNumber, pageSize);
        }
    }
}

// === ARCHIVO: src/Orders.Infrastructure/Database/Command/OrdersCommandDbContext.cs ===
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;

namespace Orders.Infrastructure.Database.Command
{
    public class OrdersCommandDbContext : DbContext
    {
        public OrdersCommandDbContext(DbContextOptions<OrdersCommandDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CustomerId).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.HasMany(e => e.Items)
                   .WithOne()
                   .HasForeignKey(e => e.OrderId);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.OrderId).IsRequired();
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.ProductName).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();
            });
        }
    }
}

// === ARCHIVO: src/Orders.Infrastructure/Database/Query/OrdersQueryDbContext.cs ===
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;

namespace Orders.Infrastructure.Database.Query
{
    public class OrdersQueryDbContext : DbContext, IOrderQueryRepository
    {
        public OrdersQueryDbContext(DbContextOptions<OrdersQueryDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await Orders.Where(o => o.CustomerId == customerId).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status, CancellationToken cancellationToken = default)
        {
            return await Orders.Where(o => o.Status == status).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            return await Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToListAsync(cancellationToken);
        }

        public async Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var orders = await Orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            var totalCount = await Orders.CountAsync(cancellationToken);
            return new PagedResult<Order>(orders, totalCount, pageNumber, pageSize);
        }
    }
}

// === ARCHIVO: src/Orders.Api/Controllers/OrdersCommandController.cs ===
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Commands.CreateOrder;
using Orders.Application.Commands.UpdateOrder;
using Orders.Application.Commands.DeleteOrder;

namespace Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersCommandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder(CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, orderId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, UpdateOrderCommand command)
        {
            if (id!= command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

// === ARCHIVO: src/Orders.Api/Controllers/OrdersQueryController.cs ===
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orders.Application.Queries.GetOrderById;
using Orders.Application.Queries.GetOrdersByCustomer;
using Orders.Application.Queries.GetOrdersByStatus;
using Orders.Application.Queries.GetOrdersByDateRange;

namespace Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            return order == null? NotFound() : Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByCustomerId(Guid customerId)
        {
            var orders = await _mediator.Send(new GetOrdersByCustomerQuery { CustomerId = customerId });
            return Ok(orders);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByStatus(OrderStatus status)
        {
            var orders = await _mediator.Send(new GetOrdersByStatusQuery { Status = status });
            return Ok(orders);
        }

        [HttpGet("date/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            var orders = await _mediator.Send(new GetOrdersByDateRangeQuery { StartDate = startDate, EndDate = endDate });
            return Ok(orders);
        }
    }
}

// === ARCHIVO: src/Orders.Api/Middleware/ExceptionHandlingMiddleware.cs ===
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Orders.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An error occurred while processing your request."
                }.ToString());
            }
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}

// === ARCHIVO: src/Orders.Application/Commands/CreateOrder/CreateOrderCommand.cs ===
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }

        public class Validator : AbstractValidator<CreateOrderCommand>
        {
            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty();
                RuleFor(x => x.Items).NotEmpty();
                RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
            }
        }
    }
}

// === ARCHIVO: src/Orders.Application/Commands/CreateOrder/CreateOrderCommandHandler.cs ===
using MediatR;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using Orders.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IValidator<Order> _orderValidator;

        public CreateOrderCommandHandler(IOrderCommandRepository orderCommandRepository, IValidator<Order> orderValidator)
        {
            _orderCommandRepository = orderCommandRepository;
            _orderValidator = orderValidator;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.CustomerId, request.Items);
            var validationResult = await _orderValidator.ValidateAsync(order, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _orderCommandRepository.AddAsync(order, cancellationToken);
            return order.Id;
        }
    }
}

// === ARCHIVO: src/Orders.Application/Queries/GetOrderById/GetOrderByIdQuery.cs ===
using MediatR;
using Orders.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Application.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;

        public GetOrderByIdQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            _orderQueryRepository = orderQueryRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderQueryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (order == null)
            {
                throw new Exception("Order not found");
            }
            return order;
        }
    }
}

// === ARCHIVO: src/Orders.Application/Queries/GetOrderById/GetOrderByIdQueryHandler.cs ===
using MediatR;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Orders.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;

        public GetOrderByIdQueryHandler(IOrderQueryRepository orderQueryRepository)
        {
            _orderQueryRepository = orderQueryRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var order = await _orderQueryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                throw new InvalidOperationException("Order not found");
            }

            return order;
        }
    }
}

// === ARCHIVO: src/Orders.Domain/Events/OrderCreatedEvent.cs ===
using System;

namespace Orders.Domain.Events
{
    public class OrderCreatedEvent : DomainEvent
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }

        public OrderCreatedEvent(Guid orderId, Guid customerId, IReadOnlyCollection<OrderItem> items)
        {
            if (orderId == Guid.Empty)
            {
                throw new ArgumentException("Order ID cannot be empty", nameof(orderId));
            }

            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Customer ID cannot be empty", nameof(customerId));
            }

            if (items == null ||!items.Any())
            {
                throw new ArgumentException("Items cannot be null or empty", nameof(items));
            }

            OrderId = orderId;
            CustomerId = customerId;
            Items = items;
        }
    }
}

// === ARCHIVO: tests/Orders.Application.Tests/Commands/CreateOrderCommandHandlerTests.cs ===
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Orders.Application.Commands.CreateOrder;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using Xunit;

namespace Orders.Application.Tests.Commands
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IOrderCommandRepository> _mockOrderCommandRepository;
        private readonly CreateOrderCommandHandler _handler;

        public CreateOrderCommandHandlerTests()
        {
            _mockOrderCommandRepository = new Mock<IOrderCommandRepository>();
            _handler = new CreateOrderCommandHandler(_mockOrderCommandRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidCreateOrderCommand_AddsOrderToRepository()
        {
            // Arrange
            var command = new CreateOrderCommand(Guid.NewGuid(), new List<OrderItem> { new OrderItem(Guid.NewGuid(), "Product1", 10.0m, 1) });

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockOrderCommandRepository.Verify(repo => repo.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCreateOrderCommand_ThrowsValidationException()
        {
            // Arrange
            var command = new CreateOrderCommand(Guid.Empty, new List<OrderItem> { new OrderItem(Guid.Empty, "", 0.0m, 0) });

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}

// === ARCHIVO: tests/Orders.Application.Tests/Queries/GetOrderByIdQueryHandlerTests.cs ===
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Orders.Application.Queries.GetOrderById;
using Orders.Domain.Entities;
using Orders.Domain.Interfaces;
using Xunit;

namespace Orders.Application.Tests.Queries
{
    public class GetOrderByIdQueryHandlerTests
    {
        private readonly Mock<IOrderQueryRepository> _mockOrderQueryRepository;
        private readonly GetOrderByIdQueryHandler _handler;

        public GetOrderByIdQueryHandlerTests()
        {
            _mockOrderQueryRepository = new Mock<IOrderQueryRepository>();
            _handler = new GetOrderByIdQueryHandler(_mockOrderQueryRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidGetOrderByIdQuery_ReturnsOrder()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var order = new Order(Guid.NewGuid(), new List<OrderItem> { new OrderItem(Guid.NewGuid(), "Product1", 10.0m, 1) });
            _mockOrderQueryRepository.Setup(repo => repo.GetByIdAsync(orderId, It.IsAny<CancellationToken>())).ReturnsAsync(order);

            var query = new GetOrderByIdQuery(orderId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderId, result.Id);
        }

        [Fact]
        public async Task Handle_InvalidGetOrderByIdQuery_ThrowsNotFoundException()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            _mockOrderQueryRepository.Setup(repo => repo.GetByIdAsync(orderId, It.IsAny<CancellationToken>())).ReturnsAsync((Order)null);

            var query = new GetOrderByIdQuery(orderId);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}
```
