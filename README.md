# NubaHotel.BookingSystem

Sistema de reservas para el hotel Nuba Hotel, desarrollado con .NET 8 siguiendo la arquitectura Clean Architecture. Este sistema está compuesto por múltiples proyectos organizados en capas bien definidas para garantizar separación de responsabilidades, mantenibilidad y escalabilidad.

## 📦 Estructura del Proyecto

```
src/
├── Api/
│   └── NubaHotel.BookingSystem.Api/         # Proyecto API (Web API)
│       ├── Controllers                       # Controladores HTTP
│       ├── Logging, Middleware               # Middleware y configuración de logs
│       ├── appsettings.json                  # Configuración de la app (ignorado en Git)
│       ├── secrets.json                      # Claves locales (no se sube a Git)
│       └── Program.cs                        # Entrada de la aplicación

├── Core/
│   ├── NubaHotel.BookingSystem.Application/  # Lógica de aplicación (Casos de uso, servicios)
│   │   ├── CQRS, DTOs, Services, Validators
│   └── NubaHotel.BookingSystem.Domain/       # Entidades del dominio y lógica de negocio
│       ├── Entities, Repositories, Security

├── Infrastructure/
│   ├── NubaHotel.BookingSystem.Infra.External/     # Conexiones con servicios externos
│   │   └── TokenService
│   └── NubaHotel.BookingSystem.Infra.Persistence/  # Persistencia (EF Core)
│       ├── Database, Authentication, Mappings
│       └── Entities, Repositories
```

## 🧱 Tecnologías y Patrones

* **.NET 8**
* **Clean Architecture**
* **CQRS (Command Query Responsibility Segregation)**
* **Entity Framework Core**
* **FluentValidation**
* **Inyección de Dependencias**
* **Automapper (manual)**

## 🔐 Configuración

Los archivos `appsettings.json` y `secrets.json` contienen información sensible y **están excluidos del control de versiones** mediante `.gitignore`. Se recomienda configurar los secretos de desarrollo mediante:

```bash
dotnet user-secrets init
dotnet user-secrets set "NombreClave" "Valor"
```

## 🚀 Objetivo

Proveer un sistema modular y escalable para gestionar reservas de habitaciones en Nuba Hotel, incluyendo autenticación, conexión con sistemas externos y validaciones robustas.

## 📂 Próximas mejoras

* Autenticación con JWT o IdentityServer
* Administración de usuarios y roles
* Dashboard de reservas por cliente y por fechas
* Soporte multilenguaje


