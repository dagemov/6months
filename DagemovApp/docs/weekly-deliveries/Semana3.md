# Ejercicios de nivel 1
### Inventario del lenguaje de negocio Dagemov

# Listado de entidades iniciales y el por que .

1. `user` representa la identidad principal de una persona dentro de Dagemov. Permite autenticar, identificar y relacionar a una persona con compañías, propiedades, servicios, turnos e incidentes
		.Ejemplo practico : 
		Sebastian = User
		Sebastian puede ser Owner en Company A
		Sebastian puede ser Employee en Company B
		Sebastian puede ser Client en Company C
2. **`Company`**
	Existe porque [[Dagemov]] no gestiona trabajos sueltos; gestiona operaciones dentro de una empresa.
	
	Mejor definición:
	
	`Company` representa una organización o micro empresa que usa Dagemov para administrar clientes, empleados, propiedades, órdenes de servicio, turnos, pagos e incidentes.
	
	Ejemplo:
	CleanPro LLCLawnCare ExpressPainting Brothers LLC
1. `CompanyMembership`
	Esta es la entidad más importante para permisos.
	`CompanyMembership` representa la participación de un usuario dentro de una compañía específica. Define qué rol tiene ese usuario en esa compañía y si su relación está activa o no.
	Ejemplo:
		User: Sebastian
		Company: CleanPro LLC
		Role: Owner
		Status: Active

2. `Property`
	Existe porque los servicios no se realizan “en el aire”; se realizan sobre una ubicación física o propiedad asociada a un cliente.


# Ejercicio de nivel 3 Y 4.
Decidimos usar los principios de DDD (Domain-driver Deseing) ; para asegurarnos que las entidades siempre estén en un estado valido


### Pensemos reglas de Domino para workShift.
#### Que tan código o humano suena nuestra enumeración de workShift?

#### Que define un workShift?
> ***Define la hoja de trabajo en nuestra aplicación . No tomamos lógicamente todo lo que implica como el calculo de pago 200% por horas extras +9 o +40 a la semana , el por que ? porque ya eso seria un payrollPost completo , nosotros únicamente nos encargamos de hacer el shift de horas. Valida un workShift valido y la deducción del breakTime o tiempo de descanso
#### Puede un workShift tener la hora de inicio mayor a la del final ?
No , la hora de inicio debe estar siempre por debajo de la final ;
` juega de la siguiente  forma`  : 
>***inicio de trabajo 4/30/2026 - 8:00 Am final   4/30/2026 - 12:00 Pm 
***No puedo pasar que  :  4/30/2026- 8:00Am -- final 4/30/2026 6:00Am ***
Si puede pasar que el final sea el 6:00Am , pero del siguiente día , siempre debe ir por encima como regla de negocio.
#### Como vamos a asegurar la integridad del tiempo en workShift y no tener problemas de servidor o regional ?
Se tienen  las reglas de negocio claras y establecidas sobre el DateTime que se debe tomar  ; se tiene encuenta las comparaciones ,validaciones claras para el registro y la actualizacion clara del dateTime . De esta forma prometemos la integridad de un workShift sencillo , pero limpio .
Nada de DateTimes raros , shift sin forma y extranos , simple una hora de comienzo y final junto con el break time establecido .


#### Al final porque realizamos estas reglas y las aplicamos dentro de sus respectivas clase ?
por que : todas están son reglas de dominio para workShift, porque le pertenecen únicamente a la entidad  como tal ; no tuve que ir a buscar en base de datos algún ticket o relación con esta misma ; que eso ya seria un caso de uso o   lógica de negocio.


## Reglas de dominio para Company.
# 1-) Que es lo que en verdad hace ser una Company en Dagemov ? 
	> Lo que hace que una compania sea una compania en dagemov, es aquella entidad que tiene en su dominio el poder realizar cierto tipo de trabajos,servicios o evento sobre una o unas propiedades seleccionadas; dichas propiedades probienen de 1 o varios clientes en el caso que sean apartamentos. Las companias son aquellas que hacen la gestion de contrataciones y  programacion, para clientes y empleados.
	***En otras palabras :  "Una compania es aquella que tiene el poder de gestionar servicios en una propiedades y tiene su memebresia activa en dagemov , respetando los parametros legales para hacerlo***"
# Que son los Parámetros legales en Dagemov ?
	> El registro de una compania implica que este registrada legalmente, Esto no lo hace nuestro software pero lo tomamos como requisito funcional; ya que una compania es libre de registrarse en el sistema , pero es unicamente funcional solo si esta tiene activa una membresia dentro de nuestro sistema.
	> Por que no verificamos a nivel legal ?
	> sencillo en Dagemov no verificamos si en verdad la compania o micro empresa LLC en verdad existe en camara de comercio, eso no nos correspende, unicamente paga su membresia y segun el flujo que esta tenga es su cobra.
# Que es el flujo dentro de una Company ?
	> El flujo de una compania se mide por lo siguiente : 
	En las siguiente tabla apreciaremos que el flujo de una compania se define por la cantidad de registro de : empleados,clientes,servicios al mas , numero de archivos subidos al blob , se marca con una status el nivel del flujo de esta compania o micro empresa mensualmente ; al final con esto se hace el calculo del precio final de las membresia. cobraremos los justo cuando tengamos respaldo database en azure y la factura de los blobStorage

| NroEmplado | NroClientes | NroServiciosMes | NroFilesSubidos | Status      | ComapnyId | finalPrice           |
| ---------- | ----------- | --------------- | --------------- | ----------- | --------- | -------------------- |
| 15         | 40          | 120             | 50              | medium      | 20        | 12$                  |
| 30         | 120         | 225             | 100             | medium-high | 5         | 18$                  |
| 80         | 300         | 450             | 200             | high        | 35        | 25$ or depende files |

# Reglas de Dominio de una Compania.
		Una Company o Compania debe tener una nombre unico y un nombre legal unico dentro del sistema; que pasaria si a futuro llegara haber una coicidencia de igualdad de nombre ? ( contemplar la opcion de un Alias )
		Una Company no deber tener nombres invalidos 
		 Una Company debe tener una estado que diga si esta activa o no segun su membresia,
		 Una Company no puede hacer actualizacion en el sistema si no es valida; se le va a requerir la activasion de la compania.
# Ejercicios de nivel 5


# Revisión critica de nuestro Dominio con mentalidad de PR

### Por que no usar atributos de EF core en el Domino ?
		> como se ve en las clases no se uso ninguna dataNotation o ninguna ayuda con EF core; es mas ni marcamos los atributos Id como [key]. Simple , un dominio contaminado es un domino no escalable y sensible a los cambios.
		> Que es un dominio sensible a cambios ?
		> un Dominio sensible a cambios es aquel que como tal no es un dominio tecnico puro y a puro no me refiero a ser dogmatico, me refiero a dependedr de liberias externas en las entidades bases como Company y workShift. Imagina el escenario donde tengamos que cambiar de sql a mongo en el futuro por cuestiones de software o requirimientos del sistema. Sencillamente seria un cambio muy sensible para un dominio que este contaminado, pero si el domino esta bien estructurado ; unicamente en la capa de conecxion a base de datos ( persistencia ) es donde va el cambio y como usamos nuestro hermoso concepto de DI , las demas clases no se preocupan de como se hacen las cosas en esa capa del proyecto (SIR).
# Modelo de Company


# Decisiones .
	Se desicidio que el Id sea un Guid y no un int.
		Justificacion de la desicion : por temas de seguridad y de unicidad global de la aplicacion; ya que si a futuro vamos a implementar la micro services architectura y comunicarnos con diferentes APIS , diferentes bases de datos. por temas de seguridad y unicidad preferi que esta entidad tuviera un guid y que no se pueda adivinar por ID .

		


# Modelo de WorkShift.
		Se decicido que le Id sea un simple entero. 
			Justifiacion : facilidad de manejo y busqueda. un workShift vive dentro de un servicio que se presta dentro de una X propiedad, de esta forma es mas facil buscarlo en este flujo, ya que nuestras entidades fuertes sobre workShift son Company and ServiceOrder

# Riesgos
	>Duplicacion de codigo ( en estos momentos bajo nivel) ; aunque tenemos 2 entidades por el momento , ambas manejan CreatedDate y UpdatedDate , junto con la opcion de ModifiedByUser ; el cual deberia guardar el usuario que modifico la entidad + su rol en la aplicacion , para llevar cierta auditoria.
	>Propuesta : Podria ser un ValueObject para todas las entidades de dominio.
	>Se podria definir reglas en el valueObject y a futuro si hace falta una interface de casos de usos especiales como : IUseCaseAuditValue , IUseCaseCompanyAuditValue , donde si se llegaran haber reglas especiales de auditoria para X entidad podria en el caso de uso implementarlo por medio de la interface y seria una opcion limpia re usando ese codigo y no tener que copiar estas 3 propiedades en todas las clases .
	
# Puntos débiles
###  WorkShift 
	> El punto debil de la entidad workShift es que va ligada de un servicio, si no hay servicio no hay horario de workShift que asignar en el sistema y eso es una regla clara de negocio en la aplicacion . No existen Shift sueltos ; por ende workShift no es una entidad que pueda valerse por si misma o que tenga identidad propia , tiene identidad cuando hace parte de un servicio y cobra sentido.
	
#### Deuda técnica Aceptada.
	> La creacion de servicios vendra a futuro para hacer el respectivo crud con workShift.
	> comentarios de lso atributos en la clase workShift por el momento.
	> nullables aceptados por el momentos (constructor protected en la clase)
	> Matener los 3 atributos que se recomiendan pasar a un ValueObject :
		1.  public DateTime CreatedDate { get; private set; }
		 2.  public string? ModifideByUser { get; set; } = string.Empty!; //Coger el usuario que modifico la entidad (auditoria)
		 3.  public DateTime UpdatedDate { get; private set; }

# Company
	> Para que company pueda ejercer Acciones en nuestro sistema, debe tener o estar activada por medio de una membreShip valida y esto se toma como regla de negocio.

#### Deuda técnica Aceptada.		
		> Matener los 3 atributos que se recomiendan pasar a un ValueObject :
		1.  public DateTime CreatedDate { get; private set; }
		 2.  public string? ModifideByUser { get; set; } = string.Empty!; //Coger el usuario que modifico la entidad (auditoria)
		 3.  public DateTime UpdatedDate { get; private set; }
		 > Mejoramiento de Namings un poco mas especificos o buscar la forma de dar valores no tan de codigo , si no humanos .
