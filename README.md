# Rediseño del Módulo de Órdenes con CQRS

El sistema de procesamiento de órdenes en la plataforma de comercio electrónico necesita una refactorización para separar las responsabilidades de lectura y escritura. Actualmente, el módulo de órdenes maneja tanto las solicitudes de lectura como de escritura en un mismo componente, lo que ha llevado a una complejidad creciente y a problemas de consistencia. El objetivo es implementar el patrón CQRS para separar estos comandos y evaluar el trade-off de consistencia que esto introduce.

## Informacion General

| Campo | Valor |
|-------|-------|
| **Tema** | Separacion de responsabilidades con CQRS |
| **Nivel** | senior-l2 |
| **Tipo** | mixed |
| **Tiempo estimado** | 15 horas |

## Fases del Reto

### Fase 0: Configuración del Proyecto

**Objetivo:** Obtener el proyecto base funcional enviando el Código Base a un asistente de IA, que lo analizará, corregirá errores y generará un ZIP listo para usar.

**Tiempo estimado:** 15-30 minutos

**Instrucciones:**

- Asegúrate de tener instalado para ejecutar el proyecto: .NET SDK 8+, VS Code o Visual Studio.
- Copia todo el contenido del campo **Código Base** de este reto — incluyendo el texto de instrucciones que aparece al inicio.
- Abre un asistente de IA (Claude en claude.ai, ChatGPT o Gemini — se recomienda Claude), pega el contenido copiado en el chat y envíalo.
- El asistente analizará los archivos, corregirá errores y generará un archivo ZIP descargable. Descárgalo y extráelo en la carpeta donde quieras trabajar.
- Ejecuta `dotnet build`. Si no hay errores, estás listo.

**Entregable:** El proyecto compila/arranca sin errores.

<details>
<summary>Pistas de conocimiento</summary>

- Copia el Código Base completo incluyendo el texto de instrucciones al inicio — esas instrucciones le indican al asistente exactamente qué hacer con los archivos.
- Si el asistente no genera el ZIP automáticamente al terminar el análisis, escríbele: "genera el ZIP ahora".
- Si el proyecto tiene errores al arrancar, comparte el mensaje de error con el mismo asistente para que lo corrija.

</details>

### Fase 1: Exploración y Modelado Inicial

**Objetivo:** Identificar las operaciones de lectura y escritura en el módulo de órdenes y modelar los comandos y consultas separadamente.

**Tiempo estimado:** 5 horas

**Instrucciones:**

- Analiza el módulo de órdenes existente para identificar las operaciones de lectura y escritura.
- Modela los comandos y consultas separadamente, definiendo las entidades y operaciones específicas para cada uno.

**Entregable:** Modelo conceptual de comandos y consultas separados para el módulo de órdenes.

<details>
<summary>Pistas de conocimiento</summary>

- Considera los diferentes tipos de órdenes y sus atributos relevantes.
- Piensa en cómo las operaciones de lectura y escritura pueden afectar la consistencia del sistema.

</details>

### Fase 2: Implementación de Comandos y Consultas

**Objetivo:** Implementar los comandos y consultas separados en el módulo de órdenes.

**Tiempo estimado:** 5 horas

**Instrucciones:**

- Crea los componentes necesarios para manejar los comandos y consultas separadamente.
- Asegura que los comandos y consultas se manejen de forma idónea, considerando los trade-offs de consistencia.

**Entregable:** Componentes implementados para manejar comandos y consultas separados en el módulo de órdenes.

<details>
<summary>Pistas de conocimiento</summary>

- Considera cómo manejar los estados y transiciones en el nuevo modelo.
- Evalúa los posibles trade-offs de consistencia y cómo mitigarlos.

</details>

### Fase 3: Evaluación y Justificación del Trade-off

**Objetivo:** Evaluar el impacto del trade-off de consistencia introducido por la separación de comandos y consultas y justificar la decisión.

**Tiempo estimado:** 5 horas

**Instrucciones:**

- Evalúa el impacto del trade-off de consistencia en el sistema.
- Justifica la decisión de implementar CQRS en términos de beneficios y costos.

**Entregable:** Evaluación y justificación del trade-off de consistencia introducido por la separación de comandos y consultas.

<details>
<summary>Pistas de conocimiento</summary>

- Considera los beneficios de mantener las operaciones de lectura y escritura separadas.
- Piensa en los costos asociados con el trade-off de consistencia.

</details>

## Dimensiones Evaluadas

- **queEs**: ¿Qué es el patrón CQRS y cómo se aplica en el módulo de órdenes?
- **paraQueSirve**: ¿Para qué sirve separar los comandos y consultas en el módulo de órdenes?
- **comoSeUsa**: ¿Cómo se implementan los comandos y consultas separados en el módulo de órdenes?
- **erroresComunes**: ¿Qué errores comunes pueden surgir al implementar CQRS en el módulo de órdenes?
- **queDecisionesImplica**: ¿Qué decisiones implica la implementación de CQRS en términos de consistencia y rendimiento?

## Criterios de Evaluacion

- Implementación correcta de los comandos y consultas separados en el módulo de órdenes.
- Evaluación y justificación clara del trade-off de consistencia introducido.
- Consideración de los posibles errores comunes y mitigación de los mismos.

## Como trabajar con un asistente de IA

Hay dos caminos, elegi uno:

- **AGENTS.md** (recomendado) — instrucciones nativas del repo. Abri esta carpeta con tu agente local (Claude Code, Cursor, Codex, Copilot, Gemini) y las carga solo. Sabe que archivos faltan y con que comando se verifica, y completa el scaffold escribiendo en disco.
- **PROMPT_MEJORA.md** — para copiar y pegar en un chat (claude.ai, ChatGPT). Devuelve un ZIP con el proyecto. Sirve si no tenes un agente en el IDE.

Ninguno de los dos resuelve las fases del reto: eso es tu trabajo.

## Verificacion

El proyecto esta listo para trabajar cuando este comando corre sin errores:

```bash
dotnet build
```

---

*Reto generado automaticamente por Challenge Generator - Pragma*
