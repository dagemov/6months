

## Problema que resulve en dagemov la arquitectura limpia.
#### cuando necesitemos hacer un cambio pequeno o una implementacion a produccion evitaremos que con cualquier minimo cambio sensible , la aplicacion rompa ; porque de lo contrario ; si se cambiara una firma o valor en algun lugar la aplicacion , deberiamos cambiarlo en todas las N capas donde se llama , pero si nosotros en verdad integramos lo que es la clean architecture con los principos solid podremos entender que una capa , un metodo ( una responsabilidad) , implementacion de interfaces que nos ayuda en las DI  y de esta forma matenemos contratos e integraciones de clases limpias y si algun metodo cambia su firma , se cambia en ese metodo y la accion de el , nadie mas deberia saber que cambio , si no su contrato y la clase que lo implementa , las demas solo llaman entregan y no se preocupan de que hace.

# Paso1
# Gestion de las ramas de github para esta semana 02.
#bashGestionBranches
```
git switch main
git pull origin main
git switch -c feature/week-02-clean-architecture-structure

```
# Paso 2

#normalizesEstructureProjecFolder
#### Crear carpetas en la raíz y mover archivos .gitkeep
	mkdir tests frontend
	mv src/frontend/.gitkeep frontend/ 2>/dev/null
	mv src/test/.gitkeep tests/ 2>/dev/null
	
#### Eliminar carpetas viejas dentro de src
	rm -rf src/frontend src/test


# Pasos de usuario 1 y 2 :
#terminalDagemov
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (main)
$ git pull origin main
From https://github.com/dagemov/6months
 * branch            main       -> FETCH_HEAD
Already up to date.

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (main)
$ git switch -c feature/week-02-clean-architecture-structure
Switched to a new branch 'feature/week-02-clean-architecture-structure'

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ ls
DagemovApp.slnx  README.md  docs/  infrastructure/  src/

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ mkdir test

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ mkdir frontend

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ mv src/frontend/.gitkeep frontend/

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ mv src/test/.gitkeep test/

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ rm -rf src/frontend/ src/test
```

# Paso 3
#creacionCapas

| **Capa**           | **Comando de Terminal**                                                       |
| ------------------ | ----------------------------------------------------------------------------- |
| **Domain**         | `dotnet new classlib -n Dagemov.Domain -o src\Dagemov.Domain`                 |
| **Application**    | `dotnet new classlib -n Dagemov.Application -o src\Dagemov.Application`       |
| **Infrastructure** | `dotnet new classlib -n Dagemov.Infrastructure -o src\Dagemov.Infrastructure` |
| **Persistence**    | `dotnet new classlib -n Dagemov.Persistence -o src\Dagemov.Persistence`       |
| **Contracts**      | `dotnet new classlib -n Dagemov.Contracts -o src\Dagemov.Contracts`           |
| **Web API**        | `dotnet new web -n Dagemov.Api -o src\Dagemov.Api`                            |

| Capa            | Comando Terminal hecho por usuario                                                                                                                                                                                                                                                                                                                                                                                                                          |
| --------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Domain**      | `Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)`<br>`$ dotnet new classlib -n Dagemov.Domain -o src\Dagemov.Domain`<br>`The template "Class Library" was created successfully.`<br><br>`Processing post-creation actions...`<br>`Restoring C:\Users\Hombr\source\repos\6months\DagemovApp\srcDagemov.Domain\Dagemov.Domain.csproj:`<br>`Restore succeeded.`<br>                                     |
| **Application** | `Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)`<br>`$ dotnet new classlib -n Dagemov.Application -o src\Dagemov.Application`<br>`The template "Class Library" was created successfully.`<br><br>`Processing post-creation actions...`<br>`Restoring C:\Users\Hombr\source\repos\6months\DagemovApp\srcDagemov.Application\Dagemov.Application.csproj:`<br>`Restore succeeded.`<br>                 |
| Infrastructure  | `Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)`<br>`$ dotnet new classlib -n Dagemov.Infrastructure -o src\Dagemov.Infrastructure`<br>`The template "Class Library" was created successfully.`<br><br>`Processing post-creation actions...`<br>`Restoring C:\Users\Hombr\source\repos\6months\DagemovApp\srcDagemov.Infrastructure\Dagemov.Infrastructure.csproj:`<br>`Restore succeeded.`<br><br> |
| Persistence     | `Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)`<br>`$ dotnet new classlib -n Dagemov.Persistence -o src\Dagemov.Persistence`<br>`The template "Class Library" was created successfully.`<br><br>`Processing post-creation actions...`<br>`Restoring C:\Users\Hombr\source\repos\6months\DagemovApp\srcDagemov.Persistence\Dagemov.Persistence.csproj:`<br>`Restore succeeded.`<br>                 |
| Contracts       | `Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)`<br>`$ dotnet new classlib -n Dagemov.Contracts -o src\Dagemov.Contracts`<br>`The template "Class Library" was created successfully.`<br><br>`Processing post-creation actions...`<br>`Restoring C:\Users\Hombr\source\repos\6months\DagemovApp\srcDagemov.Contracts\Dagemov.Contracts.csproj:`<br>`Restore succeeded.`<br><br>                     |
| Web Api         | `Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)`<br>`$ dotnet new web -n Dagemov.Api -o src\Dagemov.Api`<br>`The template "ASP.NET Core Empty" was created successfully.`<br><br>`Processing post-creation actions...`<br>`Restoring C:\Users\Hombr\source\repos\6months\DagemovApp\srcDagemov.Api\Dagemov.Api.csproj:`<br>`Restore succeeded.`<br><br><br>                                         |

# Paso 4 
#### Vinculacion a la solucion y creacion de refenrecias.
dotnet sln DagemovApp.slnx add (ls src/**/*.csproj)

#ReglasDeRefencia 
### Quien referencia a quien.

- **Application** referencia a **Domain**.
    
- **Persistence** e **Infrastructure** referencian a **Application** y **Domain**.
    
- **Api** referencia a **todas** las demás (es el punto de entrada).
#ComandosParaReferencias:
# Application -> Domain
dotnet reference add src\Dagemov.Domain\Dagemov.Domain.csproj --project src\Dagemov.Application\Dagemov.Application.csproj

#### Resultado bash Terminal : 
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ dotnet reference add srcDagemov.Domain/Dagemov.Domain.csproj --project srcDagemov.Application/Dagemov.Application.csproj
Reference `..\srcDagemov.Domain\Dagemov.Domain.csproj` added to the project.

```

# Api -> El resto
dotnet reference add src\Dagemov.Application\Dagemov.Application.csproj src\Dagemov.Infrastructure\Dagemov.Infrastructure.csproj src\Dagemov.Persistence\Dagemov.Persistence.csproj src\Dagemov.Contracts\Dagemov.Contracts.csproj --project src\Dagemov.Api\Dagemov.Api.csproj

#### Resultado bash terminal : 
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ dotnet reference add srcDagemov.Application/Dagemov.Application.csproj srcDagemov.Infrastructure/Dagemov.Infrastructure.csproj srcDagemov.Persistence/Dagemov.Persistence.csproj srcDagemov.Contracts/Dagemov.Contracts.csproj --project srcDagemov.Api/Dagemov.Api.csproj
Reference `..\srcDagemov.Application\Dagemov.Application.csproj` added to the project.
Reference `..\srcDagemov.Infrastructure\Dagemov.Infrastructure.csproj` added to the project.
Reference `..\srcDagemov.Persistence\Dagemov.Persistence.csproj` added to the project.
Reference `..\srcDagemov.Contracts\Dagemov.Contracts.csproj` added to the project.
```


# Paso final
#validacion
# Compilar
dotnet build DagemovApp.slnx

### Resultado del build Dagemov :
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ dotnet build DagemovApp.slnx
Restore succeeded with 1 warning(s) in 0.0s
    C:\Program Files\dotnet\sdk\10.0.202\NuGet.targets(196,5): warning Unable to find a project to restore!

Build succeeded with 1 warning(s) in 0.1s
```

# Git: Añadir, Comitear y Subir
```
git add .
git commit -m "feat: create Dagemov v2 backend architecture projects"
git push origin feature/week-02-clean-architecture-structure

### Resultado gitBash
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ git add .
warning: in the working copy of 'DagemovApp/srcDagemov.Api/Dagemov.Api.csproj', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Api/Program.cs', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Api/Properties/launchSettings.json', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Api/appsettings.Development.json', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Api/appsettings.json', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Application/Class1.cs', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Application/Dagemov.Application.csproj', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Contracts/Class1.cs', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Contracts/Dagemov.Contracts.csproj', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Domain/Class1.cs', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Domain/Dagemov.Domain.csproj', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Infrastructure/Class1.cs', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Infrastructure/Dagemov.Infrastructure.csproj', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Persistence/Class1.cs', CRLF will be replaced by LF the next time Git touches it
warning: in the working copy of 'DagemovApp/srcDagemov.Persistence/Dagemov.Persistence.csproj', CRLF will be replaced by LF the next time Git touches it

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ git commit -m "feat : create Dagemov v2 backend architecture projects"
[feature/week-02-clean-architecture-structure cd3037d] feat : create Dagemov v2 backend architecture projects
 17 files changed, 141 insertions(+)
 rename DagemovApp/{src => }/frontend/.gitkeep (100%)
 create mode 100644 DagemovApp/srcDagemov.Api/Dagemov.Api.csproj
 create mode 100644 DagemovApp/srcDagemov.Api/Program.cs
 create mode 100644 DagemovApp/srcDagemov.Api/Properties/launchSettings.json
 create mode 100644 DagemovApp/srcDagemov.Api/appsettings.Development.json
 create mode 100644 DagemovApp/srcDagemov.Api/appsettings.json
 create mode 100644 DagemovApp/srcDagemov.Application/Class1.cs
 create mode 100644 DagemovApp/srcDagemov.Application/Dagemov.Application.csproj
 create mode 100644 DagemovApp/srcDagemov.Contracts/Class1.cs
 create mode 100644 DagemovApp/srcDagemov.Contracts/Dagemov.Contracts.csproj
 create mode 100644 DagemovApp/srcDagemov.Domain/Class1.cs
 create mode 100644 DagemovApp/srcDagemov.Domain/Dagemov.Domain.csproj
 create mode 100644 DagemovApp/srcDagemov.Infrastructure/Class1.cs
 create mode 100644 DagemovApp/srcDagemov.Infrastructure/Dagemov.Infrastructure.csproj
 create mode 100644 DagemovApp/srcDagemov.Persistence/Class1.cs
 create mode 100644 DagemovApp/srcDagemov.Persistence/Dagemov.Persistence.csproj
 rename DagemovApp/{src => }/test/.gitkeep (100%)

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (feature/week-02-clean-architecture-structure)
$ git push origin feature/week-02-clean-architecture-structure
Enumerating objects: 24, done.
Counting objects: 100% (24/24), done.
Delta compression using up to 16 threads
Compressing objects: 100% (21/21), done.
Writing objects: 100% (22/22), 2.69 KiB | 1.35 MiB/s, done.
Total 22 (delta 3), reused 0 (delta 0), pack-reused 0 (from 0)
remote: Resolving deltas: 100% (3/3), completed with 1 local object.
remote:
remote: Create a pull request for 'feature/week-02-clean-architecture-structure' on GitHub by visiting:
remote:      https://github.com/dagemov/6months/pull/new/feature/week-02-clean-architecture-structure
remote:
To https://github.com/dagemov/6months.git
 * [new branch]      feature/week-02-clean-architecture-structure -> feature/week-02-clean-architecture-structure

```



### Resultaod PR 
### Pull request successfully merged and closed

You're all set — the [feature/week-02-clean-architecture-structure](https://github.com/dagemov/6months/tree/feature/week-02-clean-architecture-structure) branch can be safely deleted.



# Entrega del proyecto .

### Arbol del proyecto github : 
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (main)
$ git log --graph --oneline --all
*   4bbc09d (HEAD -> main, origin/main, origin/HEAD) Merge pull request #3 from dagemov/feature/week-02-clean-architecture-structure
|\
| * cd3037d (origin/feature/week-02-clean-architecture-structure) feat : create Dagemov v2 backend architecture projects
|/
* a76de4f chore: define line ending policy for Windows and WSL2
* 78ae81b (origin/feature/setup-docs) docs : add initial architecture project description
* 382fa82 chore : bootstrap Dagemov v2 repository and solution estructure
* 809ec7e chore : gitAttriubes and README added
*   8928d97 Merge pull request #1 from dagemov/feature/week-01-project-bootstrap
|\
| * 22672a7 chore : bootstrap DagemovApp repository and solution
|/
* 238c90c docs: add Dagemov Git Notes
* 69eb4d1 initial configuration + hygiene for .net development finished
* 39fa8ff Initial commit
```

### Proyectos en solucion : 
dotnet sln DagemovApp.slnx list
procedo a dar solucion al error de estructura del proyecto :
#### Paso 1 , creacion de la nueva rama fixed week 02
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (main)
$ git switch -c fix/week-02-solution-project-references
Switched to a new branch 'fix/week-02-solution-project-references'

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (fix/week-02-solution-project-references)
$
```

### Paso 2 , movimientoi de las carpetas mal creadas dentro de src
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (fix/week-02-solution-project-references)
$ git mv srcDagemov.Api src/Dagemov.Api
git mv srcDagemov.Application src/Dagemov.Application
git mv srcDagemov.Contracts src/Dagemov.Contracts
git mv srcDagemov.Domain src/Dagemov.Domain
git mv srcDagemov.Infrastructure src/Dagemov.Infrastructure
git mv srcDagemov.Persistence src/Dagemov.Persistence
```
### Paso 3 , limpieza de referencias viejas y crear nuevas : 
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (fix/week-02-solution-project-references)
$ dotnet remove src/Dagemov.Application/Dagemov.Application.csproj reference ../srcDagemov.Domain/Dagemov.Domain.csproj

dotnet remove src/Dagemov.Api/Dagemov.Api.csproj reference ../srcDagemov.Application/Dagemov.Application.csproj
dotnet remove src/Dagemov.Api/Dagemov.Api.csproj reference ../srcDagemov.Infrastructure/Dagemov.Infrastructure.csproj
dotnet remove src/Dagemov.Api/Dagemov.Api.csproj reference ../srcDagemov.Persistence/Dagemov.Persistence.csproj
dotnet remove src/Dagemov.Api/Dagemov.Api.csproj reference ../srcDagemov.Contracts/Dagemov.Contracts.csproj
Project reference `../srcDagemov.Domain/Dagemov.Domain.csproj` removed.
Project reference `../srcDagemov.Application/Dagemov.Application.csproj` removed.
Project reference `../srcDagemov.Infrastructure/Dagemov.Infrastructure.csproj` removed.
Project reference `../srcDagemov.Persistence/Dagemov.Persistence.csproj` removed.
Project reference `../srcDagemov.Contracts/Dagemov.Contracts.csproj` removed.

```
#### Nuevas referencias : 
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (fix/week-02-solution-project-references)
$ dotnet add src/Dagemov.Application/Dagemov.Application.csproj reference src/Dagemov.Domain/Dagemov.Domain.csproj

dotnet add src/Dagemov.Infrastructure/Dagemov.Infrastructure.csproj reference src/Dagemov.Application/Dagemov.Application.csproj src/Dagemov.Domain/Dagemov.Domain.csproj

dotnet add src/Dagemov.Persistence/Dagemov.Persistence.csproj reference src/Dagemov.Application/Dagemov.Application.csproj src/Dagemov.Domain/Dagemov.Domain.csproj

dotnet add src/Dagemov.Api/Dagemov.Api.csproj reference src/Dagemov.Application/Dagemov.Application.csproj src/Dagemov.Contracts/Dagemov.Contracts.csproj src/Dagemov.Infrastructure/Dagemov.Infrastructure.csproj src/Dagemov.Persistence/Dagemov.Persistence.csproj src/Dagemov.Domain/Dagemov.Domain.csproj
Reference `..\Dagemov.Domain\Dagemov.Domain.csproj` added to the project.
Reference `..\Dagemov.Application\Dagemov.Application.csproj` added to the project.
Reference `..\Dagemov.Domain\Dagemov.Domain.csproj` added to the project.
Reference `..\Dagemov.Application\Dagemov.Application.csproj` added to the project.
Reference `..\Dagemov.Domain\Dagemov.Domain.csproj` added to the project.
Reference `..\Dagemov.Application\Dagemov.Application.csproj` added to the project.
Reference `..\Dagemov.Contracts\Dagemov.Contracts.csproj` added to the project.
Reference `..\Dagemov.Infrastructure\Dagemov.Infrastructure.csproj` added to the project.
Reference `..\Dagemov.Persistence\Dagemov.Persistence.csproj` added to the project.
Reference `..\Dagemov.Domain\Dagemov.Domain.csproj` added to the project.

```

## Paso 3 :  Ahora si Agregamos los proyectos a la solucion : 

```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (fix/week-02-solution-project-references)
$ dotnet sln DagemovApp.slnx add src/Dagemov.Api/Dagemov.Api.csproj
dotnet sln DagemovApp.slnx add src/Dagemov.Application/Dagemov.Application.csproj
dotnet sln DagemovApp.slnx add src/Dagemov.Contracts/Dagemov.Contracts.csproj
dotnet sln DagemovApp.slnx add src/Dagemov.Domain/Dagemov.Domain.csproj
dotnet sln DagemovApp.slnx add src/Dagemov.Infrastructure/Dagemov.Infrastructure.csproj
dotnet sln DagemovApp.slnx add src/Dagemov.Persistence/Dagemov.Persistence.csproj
Project `src\Dagemov.Api\Dagemov.Api.csproj` added to the solution.
Project `src\Dagemov.Application\Dagemov.Application.csproj` added to the solution.
Project `src\Dagemov.Domain\Dagemov.Domain.csproj` added to the solution.
Project `src\Dagemov.Contracts\Dagemov.Contracts.csproj` added to the solution.
Project `src\Dagemov.Infrastructure\Dagemov.Infrastructure.csproj` added to the solution.
Project `src\Dagemov.Persistence\Dagemov.Persistence.csproj` added to the solution.
Solution C:\Users\Hombr\source\repos\6months\DagemovApp\DagemovApp.slnx already contains project src\Dagemov.Application\Dagemov.Application.csproj.
Solution C:\Users\Hombr\source\repos\6months\DagemovApp\DagemovApp.slnx already contains project src\Dagemov.Contracts\Dagemov.Contracts.csproj.
Solution C:\Users\Hombr\source\repos\6months\DagemovApp\DagemovApp.slnx already contains project src\Dagemov.Domain\Dagemov.Domain.csproj.
Solution C:\Users\Hombr\source\repos\6months\DagemovApp\DagemovApp.slnx already contains project src\Dagemov.Infrastructure\Dagemov.Infrastructure.csproj.
Solution C:\Users\Hombr\source\repos\6months\DagemovApp\DagemovApp.slnx already contains project src\Dagemov.Persistence\Dagemov.Persistence.csproj.

```

## Validacion del build
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (fix/week-02-solution-project-references)
$ dotnet sln DagemovApp.slnx list
dotnet build DagemovApp.slnx
Project(s)
----------
src\Dagemov.Api\Dagemov.Api.csproj
src\Dagemov.Application\Dagemov.Application.csproj
src\Dagemov.Contracts\Dagemov.Contracts.csproj
src\Dagemov.Domain\Dagemov.Domain.csproj
src\Dagemov.Infrastructure\Dagemov.Infrastructure.csproj
src\Dagemov.Persistence\Dagemov.Persistence.csproj
Restore complete (0.8s)
  Dagemov.Domain net10.0 succeeded (2.2s) → src\Dagemov.Domain\bin\Debug\net10.0\Dagemov.Domain.dll
  Dagemov.Contracts net10.0 succeeded (2.2s) → src\Dagemov.Contracts\bin\Debug\net10.0\Dagemov.Contracts.dll
  Dagemov.Application net10.0 succeeded (0.3s) → src\Dagemov.Application\bin\Debug\net10.0\Dagemov.Application.dll
  Dagemov.Persistence net10.0 succeeded (0.3s) → src\Dagemov.Persistence\bin\Debug\net10.0\Dagemov.Persistence.dll
  Dagemov.Infrastructure net10.0 succeeded (0.3s) → src\Dagemov.Infrastructure\bin\Debug\net10.0\Dagemov.Infrastructure.dll
  Dagemov.Api net10.0 succeeded (1.4s) → src\Dagemov.Api\bin\Debug\net10.0\Dagemov.Api.dll

Build succeeded in 5.0s

```


## comit
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (fix/week-02-solution-project-references)
$ git push origin fix/week-02-solution-project-references
Enumerating objects: 24, done.
Counting objects: 100% (24/24), done.
Delta compression using up to 16 threads
Compressing objects: 100% (19/19), done.
Writing objects: 100% (20/20), 2.41 KiB | 2.41 MiB/s, done.
Total 20 (delta 5), reused 0 (delta 0), pack-reused 0 (from 0)
remote: Resolving deltas: 100% (5/5), completed with 2 local objects.
remote:
remote: Create a pull request for 'fix/week-02-solution-project-references' on GitHub by visiting:
remote:      https://github.com/dagemov/6months/pull/new/fix/week-02-solution-project-references
remote:
To https://github.com/dagemov/6months.git
 * [new branch]      fix/week-02-solution-project-references -> fix/week-02-solution-project-references

```

# Pr result : 
### 

**[dagemov](https://github.com/dagemov)**commented[now](https://github.com/dagemov/6months/pull/4#issue-4349917931)

we're normalized the project and make sure the class libraries live inside of the solution DagemovApp.slnx

[![@dagemov](https://avatars.githubusercontent.com/u/97604053?s=40&v=4)](https://github.com/dagemov)

`[fix : register projects in solution and normalize src structure](https://github.com/dagemov/6months/pull/4/commits/c89370b6ccee59a36ce7b4b293780b8b9847548c "fix :  register projects in solution and normalize src structure")`

`[c89370b](https://github.com/dagemov/6months/pull/4/commits/c89370b6ccee59a36ce7b4b293780b8b9847548c)`

## Merge info

### No conflicts with base branch

Merging can be performed automatically.


# Limpieza 
```
Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (main)
$ git log --oneline --graph --decorate -10
*   f603c3d (HEAD -> main, origin/main, origin/HEAD) Merge pull request #4 from dagemov/fix/week-02-solution-project-references
|\
| * c89370b (origin/fix/week-02-solution-project-references, fix/week-02-solution-project-references) fix :  register projects in solution and normalize src structure
|/
*   4bbc09d Merge pull request #3 from dagemov/feature/week-02-clean-architecture-structure
|\
| * cd3037d (origin/feature/week-02-clean-architecture-structure) feat : create Dagemov v2 backend architecture projects
|/
* a76de4f chore: define line ending policy for Windows and WSL2
* 78ae81b (origin/feature/setup-docs) docs : add initial architecture project description
* 382fa82 chore : bootstrap Dagemov v2 repository and solution estructure
* 809ec7e chore : gitAttriubes and README added
*   8928d97 Merge pull request #1 from dagemov/feature/week-01-project-bootstrap
|\
| * 22672a7 chore : bootstrap DagemovApp repository and solution
|/

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (main)
$ dotnet sln DagemovApp.slnx list
dotnet build DagemovApp.slnx
Project(s)
----------
src\Dagemov.Api\Dagemov.Api.csproj
src\Dagemov.Application\Dagemov.Application.csproj
src\Dagemov.Contracts\Dagemov.Contracts.csproj
src\Dagemov.Domain\Dagemov.Domain.csproj
src\Dagemov.Infrastructure\Dagemov.Infrastructure.csproj
src\Dagemov.Persistence\Dagemov.Persistence.csproj
Restore complete (1.0s)
  Dagemov.Domain net10.0 succeeded (2.4s) → src\Dagemov.Domain\bin\Debug\net10.0\Dagemov.Domain.dll
  Dagemov.Contracts net10.0 succeeded (2.4s) → src\Dagemov.Contracts\bin\Debug\net10.0\Dagemov.Contracts.dll
  Dagemov.Application net10.0 succeeded (0.4s) → src\Dagemov.Application\bin\Debug\net10.0\Dagemov.Application.dll
  Dagemov.Persistence net10.0 succeeded (0.4s) → src\Dagemov.Persistence\bin\Debug\net10.0\Dagemov.Persistence.dll
  Dagemov.Infrastructure net10.0 succeeded (0.5s) → src\Dagemov.Infrastructure\bin\Debug\net10.0\Dagemov.Infrastructure.dll
  Dagemov.Api net10.0 succeeded (1.5s) → src\Dagemov.Api\bin\Debug\net10.0\Dagemov.Api.dll

Build succeeded in 5.9s

Hombr@Dagemov MINGW64 ~/source/repos/6months/DagemovApp (main)
$ git branch -d fix/week-02-solution-project-references
Deleted branch fix/week-02-solution-project-references (was c89370b).
```