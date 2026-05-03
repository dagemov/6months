# Ejercicio de nivel 1
#### *Instalación de EF en la capa de persistencia* [terminado]
	>Se instalaron los paquetes correspiendetes en la capa de persistencia ; paquetes pedidos y dados en la seccion de clase semana 4.
	
### Solución de deuda técnica semana 3.
	> Se agrego el chore : feat (domain) sobre la deuda tenica te las 3 propiedades en esta semana . Decidimos crear la tabla llamada AduitTable que contiene las propiedades a Auditar de las tablas que entityFrameWork creara apartir de nuestras entidades. Esta tabla contiene la fecha de creacion , actulizacion y el campo del usuario por el cual fue modificado.

# Configuraciones 

	Se agrego la carpeta de configuracion en la capa de Dagemov.Persistence . Aqui viven 2 configuracion que hasta el momento son las 2 unicas entidades que tenemos : WorkShiftConfiguration y Companyconfigurations.
	Hacemos validacion de la llave y hacemos validacion del AuditTable


# Deudas técnicas pendientes  
  
## Auditoria — Current User  
  
- Se deja preparado el modelo de auditoría a nivel de dominio mediante la interfaz `IAuditableEntity` y su implementación en las entidades.  
  
- La resolución del usuario actual (`CurrentUser`) NO se implementa en esta fase porque:  
  
- Pertenece a la capa de **Infrastructure / API**, no al dominio.  
- Requiere acceso al contexto HTTP (JWT, Claims), lo cual rompe las reglas de Clean Architecture si se introduce en Domain o Application.  
  
- En una fase posterior se debe implementar:  
  
1. Contrato en Application:  
```csharp  
ICurrentUserService  
```  
  
2. Implementación en Infrastructure:  
- Lectura desde `HttpContext` / Claims  
- Manejo de fallback (`system`)  
  
3. Registro en DI:  
```csharp  
services.AddScoped<ICurrentUserService, CurrentUserService>();  
```  
  
4. Integración en `DagemovDataContext`:  
- Override de `SaveChanges / SaveChangesAsync`  
- Aplicación automática de:  
- `CreatedDate`  
- `UpdatedDate`  
- `ModifiedByUser`  
  
---  
  
## Decisión de diseño  
  
- Se eliminan configuraciones duplicadas de auditoría en cada `EntityConfiguration`.  
  
- Se centraliza la lógica de auditoría en:  
  
- Entidades (`IAuditableEntity`)  
- `DbContext` (punto único de escritura)  
  
- Esto evita:  
- Repetición de código  
- Errores humanos  
- Inconsistencias entre entidades  
  
---  
  
## Estado actual  
  
- Las entidades implementan `IAuditableEntity`  
- Las propiedades de auditoría existen en dominio  
- No se aplican aún automáticamente (pendiente DbContext)  
  
---  
  
## Pendiente crítico  
  
- Implementar auditoría automática en `DbContext` antes de:  
  
- Exponer endpoints  
- Persistir datos reales  
- Integrar autenticación  
  
---  
  
## Riesgo si no se implementa  
  
- Registros sin trazabilidad  
- Datos inconsistentes  
- Pérdida de información de quién modificó qué  
  
---  
  
# Ejercicio de nivel 4

Pasos seguidos :
	Agregar cadena de conección  y ejecutar una migración.
		**decisión , creamos un docker conteiner o lo hacemos meramente en el sql server 21 ? 

		Defincion de coneccion a un contener docker con sql server en el program
``` C#
		var connectionString = config.GetConnectionString("Docker");
	services.AddDbContext<DataContext>
	(options =>options.UseSqlServer(connectionString));
```
	> La cadena de coneccion "Docker"
```
	>   "ConnectionStrings": {
    "SqlServer": "Server=DAGEMOV\\SQLEXPRESS;Database=DagemovApp;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
    "Docker": "Server=localhost,1433;Database=DagemovAppDocker;User Id=sa;Password=Polondrolo3;Encrypt=True;TrustServerCertificate=True;"
  },
```
> Subiendo docker conteiner desde el gitBash 
> $ docker-compose -f dockerSql.yml up -d
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp/infrastructure/docker (feature/week-04-efcore-persistence-foundation)
	$ docker-compose -f dockerSql.yml up -d
	[+] Running 4/4
	 ✔ sqlserver Pulled                                                       36.8s
	   ✔ 05fefbc1c83d Pull complete                                           36.1s
	   ✔ 9ee6108ee484 Pull complete                                           34.6s
	   ✔ cb5e374be662 Pull complete                                            2.8s
	[+] Running 3/3
	 ✔ Network docker_default      Created                                     0.1s
	 ✔ Volume docker_mssql_data    Created                                     0.0s
	 ✔ Container DagemovAppDocker  Started    
```
**Ruta del archivo vive dentro de DagemovApp/Infrastructure/docker 
	Esto fue  decisión de la semana 1, donde tomamos la arquitectura de donde iban a vivir nuestros scripts

# Observación importante
No ejecuto la migración y de momento descarto el final del punto 4 y 5 , no porque no sepa ; lo descarto basado en desición tecnica de ruptura de la arquitectura  . Desde la semana 1 fuimos específicos en que API solo relacionaba Application,contracts and Infrastructure .


# Deuda Técnica Aceptada 
- [ ] Mover ServiceAppExtension a Infrastructure.
- [ ] Integración de persistencia dentro de infrastructure
- [ ] Hacer que Infrastructure componga a Persistence
- [ ] Creación de estrategia para no exponer Persistencia a Api
# Soluciones para Deuda Tecnica
No Abrir otra semana , crear una sub-fase de la semana 4 donde sea una retro alimentación y apliquemos un patrón arquitectónico correcto , una integración de las capas mencionadas  ; una final integración con el API y realizar la primera migración . 
Se marcaría semana 4.1 , rama sugerida ->  feature/week-04-persistence-Infrastructre-foundation