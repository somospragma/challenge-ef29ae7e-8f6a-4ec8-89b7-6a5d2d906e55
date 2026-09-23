# AGENTS.md

Instrucciones para el agente de IA que abra este repositorio (Claude Code, Cursor, Codex, Copilot, Gemini). Se cargan solas: no hay que pegar nada en ningun chat.

## Que es este repositorio

Es el codigo base de un reto de aprendizaje de Pragma: **Rediseño del Módulo de Órdenes con CQRS**.

| | |
|---|---|
| Tema | Separacion de responsabilidades con CQRS |
| Nivel | senior-l2 |
| Chapter | Backend |
| Especialidad | .NET |
| Stack | .NET 9 / ASP.NET Core con MediatR 12.1.0 |
| Patron arquitectonico | CQRS con separación física de comandos y consultas, usando MediatR para la mediación y Event Sourcing opcional para consistencia eventual |
| Tiempo estimado | 15 horas |

## Receta del stack

Esqueleto obligatorio:

- `*.csproj en la raiz del proyecto`
- `Program.cs como entry point`
- `appsettings.json`
- `carpeta Domain con entidades e interfaces`
- `carpeta Application con casos de uso`
- `carpeta Infrastructure con repositorios y Controllers`

Dependencias:

- Microsoft.AspNetCore.App 9.0.0
- MediatR 12.1.0
- Microsoft.EntityFrameworkCore 9.0.0
- Dapper 2.1.24
- Microsoft.EntityFrameworkCore.SqlServer 9.0.0
- xunit 2.8.1
- Moq 4.20.70
- FluentValidation.AspNetCore 11.3.0

## Tu tarea

Dejar este proyecto en estado **verificable**: que el comando de verificacion corra sin errores. Escribi los archivos en disco, en este repositorio. No generes ZIPs ni archivos adjuntos.

En orden:

1. Corre `dotnet build` y mira que falla.
2. Completa lo que falte de la lista de abajo: manifiesto de dependencias, punto de entrada, capa de interfaz y las capas del patron declarado.
3. Arregla SOLO los errores que impiden compilar o arrancar.
4. Volve a correr `dotnet build` hasta que pase.
5. Pará ahí.

## Regla dura: las fases son trabajo del humano

**PROHIBIDO implementar los entregables de las fases.** El valor del reto esta en que la persona los resuelva. Tu trabajo es que tenga un proyecto que arranca; el hueco pedagogico se queda como esta.

No resuelvas nada de esto:

- **Fase 1 — Exploración y Modelado Inicial**: Modelo conceptual de comandos y consultas separados para el módulo de órdenes.
- **Fase 2 — Implementación de Comandos y Consultas**: Componentes implementados para manejar comandos y consultas separados en el módulo de órdenes.
- **Fase 3 — Evaluación y Justificación del Trade-off**: Evaluación y justificación del trade-off de consistencia introducido por la separación de comandos y consultas.

Distincion operativa:

- **Arreglar** (si): import faltante, tipo que no existe, dependencia sin declarar, error de sintaxis, archivo referenciado que no existe.
- **No tocar** (no): logica de negocio incompleta, validaciones ausentes, secretos hardcodeados, APIs deprecadas que funcionan, concurrencia insegura, patrones mejorables. Eso es lo que la persona tiene que encontrar.

## Lo que falta y tenes que completar

### Archivos corruptos (1) — arreglá esto primero

El contenido de estos archivos no corresponde a su extension. Regeneralos completos:

- [ ] `src/Orders.Api/appsettings.json` — El contenido no corresponde a un archivo json. Hay que regenerarlo completo.

### Presentes (20)

- `Orders.Api.csproj`
- `src/Orders.Api/Program.cs`
- `src/Orders.Api/appsettings.json`
- `src/Orders.Domain/Entities/Order.cs`
- `src/Orders.Domain/Interfaces/IOrderCommandRepository.cs`
- `src/Orders.Domain/Interfaces/IOrderQueryRepository.cs`
- `src/Orders.Infrastructure/Repositories/Command/OrderCommandRepository.cs`
- `src/Orders.Infrastructure/Repositories/Query/OrderQueryRepository.cs`
- `src/Orders.Infrastructure/Database/Command/OrdersCommandDbContext.cs`
- `src/Orders.Infrastructure/Database/Query/OrdersQueryDbContext.cs`
- `src/Orders.Api/Controllers/OrdersCommandController.cs`
- `src/Orders.Api/Controllers/OrdersQueryController.cs`
- `src/Orders.Api/Middleware/ExceptionHandlingMiddleware.cs`
- `src/Orders.Application/Commands/CreateOrder/CreateOrderCommand.cs`
- `src/Orders.Application/Commands/CreateOrder/CreateOrderCommandHandler.cs`
- `src/Orders.Application/Queries/GetOrderById/GetOrderByIdQuery.cs`
- `src/Orders.Application/Queries/GetOrderById/GetOrderByIdQueryHandler.cs`
- `src/Orders.Domain/Events/OrderCreatedEvent.cs`
- `tests/Orders.Application.Tests/Commands/CreateOrderCommandHandlerTests.cs`
- `tests/Orders.Application.Tests/Queries/GetOrderByIdQueryHandlerTests.cs`

### Capas del patron declarado

Cada una tiene que existir como directorio real con al menos un archivo. Codigo plano en la raiz no satisface el patron.

- `src/Orders.Application/Commands`
- `src/Orders.Application/Queries`
- `src/Orders.Application/Common`
- `src/Orders.Domain/Entities`
- `src/Orders.Domain/Events`
- `src/Orders.Domain/Interfaces`
- `src/Orders.Infrastructure/Repositories/Command`
- `src/Orders.Infrastructure/Repositories/Query`
- `src/Orders.Infrastructure/Database/Command`
- `src/Orders.Infrastructure/Database/Query`
- `src/Orders.Api/Controllers`
- `src/Orders.Api/Middleware`
- `tests/Orders.Application.Tests/Commands`
- `tests/Orders.Application.Tests/Queries`

## Verificacion

```bash
dotnet build
```

Ese comando pasando es la definicion de "terminado" para vos.

## Convenciones que tenes que respetar

- Un solo ecosistema: no declares librerias de otro lenguaje ni mezcles gestores de paquetes.
- Toda libreria que uses tiene que estar declarada en el manifiesto de dependencias.
- Todo import declarado tiene que usarse; todo tipo usado tiene que existir o venir de una dependencia declarada.
- El patron es **CQRS con separación física de comandos y consultas, usando MediatR para la mediación y Event Sourcing opcional para consistencia eventual**: los contratos (interfaces, puertos) los define la capa interna y los implementa la externa, nunca al revés.
- Los archivos que crees llevan implementacion real, no stubs: sin `TODO`, sin cuerpos vacios, sin `// getters y setters`.

## Contexto del candidato

Sirve para calibrar el nivel del codigo, no para resolver las fases.

- Perfil: Chapter Backend, Especialidad Desarrollador, Tecnología .NET, Senior
- Brecha que el reto ataca: Separa los comandos de las consultas y justifica el trade-off de consistencia que introduce
- Mision: Rediseñar el modulo de ordenes con lectura y escritura separadas

---

*Generado por Challenge Generator — Pragma. `README.md` tiene el enunciado completo del reto para la persona. `PROMPT_MEJORA.md` es la variante para pegar en un chat, si se prefiere ese flujo.*
