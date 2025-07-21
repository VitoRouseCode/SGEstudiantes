# Sistema de Gestión de Estudiantes

Este proyecto es una aplicación web desarrollada como solución a una prueba técnica. 
La aplicación permite la gestión de estudiantes, materias y la inscripción de materias a estudiantes, aplicando reglas de negocio específicas.

## Requerimientos Funcionales Implementados

- **Gestión de Estudiantes**: Crear, listar, editar y eliminar estudiantes.
- **Gestión de Materias**: Crear, listar, editar y eliminar materias.
- **Inscripción de Materias**:
    - Asociar materias a estudiantes.
    - Implementada la validación que impide que un estudiante inscriba más de 3 materias con más de 4 créditos cada una.
    - Permitir la desinscripción de una materia.

## Stack Tecnológico

- **Framework**: .NET 6
- **Arquitectura**: Arquitectura Limpia por capas (Core, Infrastructure, Web)
- **Base de Datos**: Entity Framework Core con SQLite (base de datos local).
- **Frontend**: ASP.NET Core Razor Pages
- **Pruebas**: MSTest para pruebas unitarias.

## Instrucciones para Ejecutar el Proyecto

Para ejecutar este proyecto en su entorno local, por favor siga los siguientes pasos:

1.  **Clonar el Repositorio**
    
    git clone https://github.com/VitoRouseCode/SGEstudiantes
   

   Dentro de la carpeta que acaba de clonar (SGEstudiantes), encontrará la carpeta principal del proyecto llamada SistemaEstudiante.

   Abra esa carpeta y haga doble clic en el archivo SistemaEstudiante.sln. Esto cargará la solución completa en Visual Studio.

2.  **Prerrequisitos**
    - Tener instalado el **SDK de .NET 6** o superior.
    - Tener instalado **Visual Studio 2022** (con la carga de trabajo de ASP.NET y desarrollo web).

3.  **Configurar la Base de Datos**
    - Abra la solución (`.sln`) en Visual Studio.
    - En el menú superior, vaya a `Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes`.
    - En la consola que se abre, ejecute el siguiente comando para crear la base de datos local:
    ```powershell
    Update-Database
    ```

4.  **Ejecutar la Aplicación**
    - Presione `F5` o el botón de "Play" (▶️) en Visual Studio para iniciar la aplicación.