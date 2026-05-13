# Week 4.1 - Infrastructure + Persistence Composition

## Objetivo
Cerrar la deuda arquitectonica de la semana 4 sin romper la regla principal del proyecto: `Api` no debe referenciar `Persistence` directamente.

## Resultado
- `Dagemov.Infrastructure` referencia a `Dagemov.Persistence`.
- La composicion de servicios vive en `Dagemov.Infrastructure/ServiceAppExtension.cs`.
- `Dagemov.Api` solo consume `AddInfrastructureServices(...)`.
- Se creo y versiono la migracion inicial de `Company` y `WorkShift`.
- La solucion compila correctamente.

## Rama usada
- `feature/week-04-1-infrastructure-persistence-composition`

## Problema arquitectonico resuelto
Se completo la comunicacion `Api -> Infrastructure -> Persistence` para poder registrar `DbContext`, ejecutar migraciones y mantener la regla principal del proyecto: `Api` no conoce `Persistence` de forma directa.

## Correccion tecnica final
- Se corrigio la firma de auditoria en `AbstracAuditTable`.
- `MarkCreated` y `MarkUpdated` ahora reciben `string userName` no anulable.
- El constructor base paso a `protected` para dejar mas clara la intencion del modelo.
- Con esto se eliminaron los warnings `CS8604` que quedaban en el dominio.

## Decision arquitectonica
No se reescribio la historia previa de la rama aunque varios commits tienen mensajes debiles.

Motivo:
- La rama ya fue compartida.
- Reescribirla implicaria `force-push`.
- Para esta fase es mas profesional corregir el contenido, cerrar con una integracion limpia y usar un mensaje final correcto hacia `main`.

## Archivos clave
- `src/Dagemov.Infrastructure/ServiceAppExtension.cs`
- `src/Dagemov.Api/Program.cs`
- `src/Dagemov.Persistence/DagemovDbContext.cs`
- `src/Dagemov.Persistence/Migrations/`
- `src/Dagemov.Domain/ValueObjects/AbstracAuditTable.cs`

## Problemas encontrados
1. El proyecto de inicio necesitaba quedar correctamente preparado para que las herramientas de EF Core pudieran resolver el `DbContext` en tiempo de diseno.
2. La inyeccion de `DbContextOptions<DagemovDbContext>` no estaba cerrada todavia mientras la composicion seguia incompleta.
3. La auditoria del dominio dejaba warnings de nulabilidad aunque la regla de negocio exigia `userName` obligatorio.

## Resolucion aplicada
- Se movio la extension de servicios a `Dagemov.Infrastructure`.
- Se agregaron las referencias necesarias para configuracion, DI y SQL Server en infraestructura.
- Se registro `DagemovDbContext` desde `AddInfrastructureServices(...)`.
- Se creo y versiono la migracion inicial.
- Se corrigio la firma de auditoria para dejar la solucion en `0 warnings` y `0 errors`.

## Validacion esperada
```bash
dotnet build DagemovApp.slnx
```

Resultado esperado:
- `0 Warning(s)`
- `0 Error(s)`
