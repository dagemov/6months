Rama usada : feature/week-04-1-infrastructure-persistence-composition

### Problema arquitectónico que se resuelve :
El problema arquitectónico resuelto , fue la falta de congruencia entre las capas , ahora API no depende o hacemos que no conozca la capa de persistencia ; ya que API únicamente depende de llamar a infrastructure o Application(donde se cumplen los contracts) . De esta manera mantenemos la integridad de  arquitectura limpia , también nos aseguramos de centralizar lógica de extensión de servicios en infraestructura, configuraciones y scripts de la aplicación.

### Desicion técnica adoptada.
La desisicon tecnica adoptada a sido el terminar o finalizar el patron de comunicacion de las capaz para poder hacer una migracion de forma satisfactoria sin ensuciar el proyecto con ruido que no deberia ir ; tal y como hicimos la comunicacion valida de API -> Infrasctura -> Persistencia .

##  Registro de Servicios movidos o Refactorizados .

Se refactorizo y finalizo la clase DagemovDbContext con su respectivo constructor .

```
  public DagemovDbContext(DbContextOptions<DagemovDbContext> options) : base(options)
  {
        
  }
```

Se han movido las configuración de EF a la capa de Infraestructura.

Se tocaron los archivos de configuración json .
```
 "ConnectionStrings": {
   "SqlServer": "Server=DAGEMOV\\SQLEXPRESS;Database=DagemovApp;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
   "Docker": "Server=localhost,1433;Database=DagemovAppDocker;User Id=sa;Password=Polondrolo3;Encrypt=True;TrustServerCertificate=True;"
 }
```
# Problemas encontrados :
1-)Se encontró el problema sobre el paquete de mincrosoft.entityFramewokrCore.Desing ; donde le proyecto startup Dagemov.Api debía tenerlo para que la comunicación fuera posible.
	lo solucione instalando el paquete en la capa de API con la misma versión trabajada en las otras capas 10.0.7
2-)Se encontró el siguiente problema
```
	Unable to create a 'DbContext' of type 'DagemovDbContext'. The exception 'Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContextOptions`1[Dagemov.Persistence.DagemovDbContext]' while attempting to activate 'Dagemov.Persistence.DagemovDbContext'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
```
	Solucion :
		Inyectamos de forma correcta el nuevo metodo de servicios estaticos en la clase program del API , juntos con la modificacion del json y se hizo el respectivo cambio de los archvios de configracion; se estaba pasando el objeto de forma explicita
		el resultado fue exitoso crenado la migracion y actulizando basando de datos.
		tambien se tuvieron que isntalar los paquetes sqlServer10.0.7 y configuration 10.0.7 en la capa de infrascturcure
