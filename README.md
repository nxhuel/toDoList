# Documentación ToDoList

## Índice

- [Descripción](#descripción)
- [Análisis de Requerimientos](#análisis-de-requerimientos)
    - [Requerimientos Funcionales](#requerimientos-funcionales)
    - [Requerimientos No Funcionales](#requerimientos-no-funcionales)
    - [Requerimientos Técnicos](#requerimientos-técnicos)
- [Diseño del Sistema](#diseño-del-sistema) 
    - [Arquitectura en Capas](#arquitectura-en-capas)
    - [Diagrama Entidad Relación](#diagrama-entidad-relación)
    - [Prototipo](#prototipo)
    - [Endpoints Disponibles](#endpoints-disponibles)
- [Casos de Uso](#casos-de-uso)
- [Configuración y Ejecución](#configuración-y-ejecución)
- [Pendientes / Mejoras Futuras](#pendientes--mejoras-futuras)
- [Contribuciones](#contribuciones)

## Descripción
SOFTWARE de gestión de tareas. Permite crear, leer, actualizar y eliminar tareas, así como marcar su estado de completado, estado de prioridad y visualizar fechas de creación, actualización y vencimiento.

⚠️ Este repositorio solo contiene el backend. Para la parte frontend visitá: [toDoListFe (Angular)](https://github.com/nxhuel/toDoListFe).

## Análisis de Requerimientos
### Requerimientos Funcionales
**ID:** RF001  

**Descripción:** El sistema debe permitir a los usuarios registrarse con su email y contraseña 

**Criterios de aceptación:** 
- El usuario debe poder ingresar su email y contraseña en los campos correspondientes  
- El email debe pasar por un validador, sea manual o por un middleware
- La contraseña debe pasar por un validador, sea manual o por un middleware
- El sistema debe crear una cuenta de usuario 
- El sistema debe re dirigirlo a la sección de tareas

**ID:** RF002  

**Descripción:** El sistema debe permitir a los usuarios realizar un CRUD de sus propias tareas  

**Criterios de aceptación:**   
- El usuario debe visualizar sus tareas creadas, completas, pendientes o vencidas
- El usuario debe crear nuevas tareas con los campos correspondientes: titulo, descripción, prioridad fecha de vencimiento y tags
- El usuario debe editar una tarea a la vez 
- El sistema debe encargarse de la fecha de creación y actualización  
- El usuario debe eliminar una tarea a la vez
- El sistema agrega, edita o elimina la tarea de la DB y refresca las tareas disponibles
### Requerimientos No Funcionales
- Toda la comunicación debe realizarse sobre HTTPS (TLS)
- Autenticación mediante JWT
- La respuestas de la API no deben superar un tiempo promedio de 200ms bajo carga normal
- Hacer buen uso de DTOs para no saturar las entidades
- Documentar la API utilizando Swagger
### Requerimientos Técnicos
**Backend** 
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- SQL Server
- Swagger

**Frontend**
- HTML5, SCSS, Typescript, Angular
- Bootstrap v5

**Despliegue**
- Azure
- Vercel

## Diseño del Sistema
### Arquitectura en Capas
<img width="747" height="334" alt="imagen" src="https://github.com/user-attachments/assets/2d784afc-6510-42dd-b076-149c0428e056" />

### Diagrama Entidad Relación
<img width="924" height="897" alt="imagen" src="https://github.com/user-attachments/assets/0eea8d5e-01ab-40f5-baae-97d2b0738bf8" />

### Prototipo
**PR001**

<img width="721" height="426" alt="imagen" src="https://github.com/user-attachments/assets/cae1b238-26ff-4ff3-adcf-d3648cb69f94" />

**PR002**

<img width="719" height="435" alt="imagen" src="https://github.com/user-attachments/assets/d751cf2e-bde7-40c5-b323-37c68e9ff9bc" />

**PR003**

<img width="720" height="436" alt="imagen" src="https://github.com/user-attachments/assets/eeb83798-38fc-442d-b029-ba54354afafa" />

**PR004**

<img width="717" height="431" alt="imagen" src="https://github.com/user-attachments/assets/bf4b54c5-4eca-49c4-b406-72324ab7d89a" />

**PR005**

<img width="718" height="431" alt="imagen" src="https://github.com/user-attachments/assets/d2c33998-3794-41ee-bdf4-d6120a1a6d2f" />

### Endpoints disponibles

| Método | Endpoint         | Descripción                  |
|--------|------------------|------------------------------|
| GET    | `/api/tasks`     | Obtener todas las tareas     |
| GET    | `/api/tasks/{id}`| Obtener una tarea por ID     |
| POST   | `/api/tasks`     | Crear una nueva tarea        |
| PUT    | `/api/tasks/{id}`| Actualizar una tarea         |
| DELETE | `/api/tasks/{id}`| Eliminar una tarea           |

| Método | Endpoint            | Descripción               |
|--------|---------------------|---------------------------|
| POST   | `/identity/register`| Registrarse               |
| POST   | `/identity/login`   | Loguearse                 |

> Autenticación no requerida por ahora (puede añadirse a futuro).  
> Todos los endpoints devuelven JSON. Para probarlos podés usar Postman o Swagger.

### Casos de uso
<img width="712" height="735" alt="imagen" src="https://github.com/user-attachments/assets/50a2f97f-eb93-4e1e-9ada-682bc4fa1a3c" />

## Configuración y Ejecución
    1. Clonar el repositorio
    2. Configurar la cadena de conexión en appsettings.json
    3. Ejecutar las migraciones (Si usas EF Core)
        ef database update
    4. Correr la API
        dotnet watch run
    5. Acceder a swagger en: http://localhost:5000/swagger
    6. Conexión con el frontend: Este backend se comunica con el frontend realizado en Angular, alojado en otro repositorio. El CORS está habilitado para aceptar solicitudes del origen del frontend.

## Pendientes / Mejoras Futuras
- Autenticación y autorización con JWT
- Testing
- Validaciones más robustas

## Contribuciones 
Aunque es un proyecto simple, estoy documentando todo como parte de mi aprendizaje y crecimiento.       
Si te interesa aportar ideas, código o feedback, ¡sos más que bienvenido/a!    
Gracias por leer 😄



