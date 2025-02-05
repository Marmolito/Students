
# Students - Reto Recnico

Este repositorio contiene dos proyectos distintos:

-API en .NET

-Frontend en Angular 19


## API en .NET

### Descripción
Este proyecto es una API RESTfull desarrollada con .NET, EntityFrameWork. El objetivo es proporcionar una API escalable, fácil de mantener y probada.

### Instalación y ejecución

1. Asegúrate de tener .NET 8 o superior instalado.
2. Asegúrate de instalar la base de datos proporcionada en el archivo *Resources/StudentBD.sql*.
3. Clona este repositorio:

```bash
  git clone https://github.com/Marmolito/SalesDatePrediction.git
```
4. Configura la conexion a tu base de datos en el archivo *appsettings.json*:

```bash
  "ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=RegistroEstudiantesDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
5. Desde la raíz del repositorio, navega a la carpeta de la API:

```bash
  cd StudentsAPI
```

6. Restaura las dependencias y aplica las Migraciones:

```bash
  dotnet restore
  dotnet ef database update
```

7. Ejecuta el proyecto:

```bash
  dotnet run
```

La API estará corriendo en http://localhost:5237 (puede variar dependiendo de la configuración).

### OpenAPI

Al ejecutar el comando dotnet run, se abrirá automáticamente la interfaz de OpenAPI en http://localhost:5237/swagger. Esta interfaz proporciona un acceso rápido a la documentación de los endpoints y permite realizar pruebas manuales directamente desde el navegador.

## Frontend en Angular 19

### Descripción

Este proyecto es un frontend desarrollado con Angular 19, utilizando Angular Material y siguiendo buenas prácticas para la segmentación de directorios y archivos. Es un frontend para interactuar con la API creada en el primer proyecto.

### Instalación y ejecución

1. Asegúrate de tener Node.js y Angular CLI instalados.
2. Clona este repositorio:
3. Desde la raíz del repositorio, navega a la carpeta del frontend

```bash
  cd StudentsAPP
```

4. Instala las dependencias:

```bash
  npm install
```

5. Ejecuta el servidor de desarrollo:

```bash
  ng serve
```

El frontend estará disponible en http://localhost:4200.

## Recursos

### Colección de Postman

Se ha incluido una colección de Postman que contiene todos los endpoints disponibles en la API. Puedes importar esta colección en Postman para realizar pruebas fácilmente, además de usar la interfaz de Swagger.

### Script SQL

Se ha incluido un script SQL que contiene las consultas necesarias para crear y poblar la base de datos en SQL Server. Esto permitirá configurar la base de datos antes de ejecutar la API.

Para acceder tanto a la colección de Postman como al script SQL, navega a la carpeta *Resources* ubicada en la raíz del repositorio.