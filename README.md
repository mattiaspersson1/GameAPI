# Tournament API

This is a .NET 8 Web API for managing tournaments and their games.  
The project demonstrates clean architecture principles with layered separation, repository pattern, Unit of Work, AutoMapper, DTOs, PATCH support, and full CRUD operations.

## Technologies Used

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (Code First)
- SQL Server LocalDB
- AutoMapper
- Newtonsoft.Json
- Swagger / Postman for testing

## Project Structure

| Project             | Description                                      |
|---------------------|--------------------------------------------------|
| `Tournament.Api`    | API layer: controllers, Swagger, DI setup        |
| `Tournament.Core`   | Domain layer: entities, DTOs, repository interfaces |
| `Tournament.Data`   | Infrastructure: DbContext, repositories, seeders |

## Features

- Entity models with validation attributes
- Data Transfer Objects (DTOs)
- Repository pattern and Unit of Work
- Dependency Injection for all layers
- Full CRUD support for tournaments and games
- PATCH support for partial updates
- AutoMapper for mapping between entities and DTOs
- Data seeding on application startup
- Search for games by exact title
- Swagger UI documentation
- Proper use of status codes and error handling

## Getting Started

### Prerequisites

- Visual Studio 2022 or newer
- .NET 8 SDK
- SQL Server LocalDB (installed with Visual Studio)

### Run the Application

1. **Clone the repository**
   ```
   git clone https://github.com/mattiaspersson1/TournamentAPI.git
   cd TournamentAPI
   ```

2. **Apply database migrations**
   ```
   cd Tournament.Data
   dotnet ef database update
   ```

3. **Run the application**
   ```
   cd ..
   dotnet run --project Tournament.Api
   ```

4. **Browse to Swagger**
   Open your browser at:  
   `https://localhost:{port}/swagger`

## Sample API Endpoints

```
GET    /api/Tournaments
GET    /api/Tournaments/{id}
POST   /api/Tournaments
PUT    /api/Tournaments/{id}
PATCH  /api/Tournaments/{id}
DELETE /api/Tournaments/{id}

GET    /api/Games
GET    /api/Games/{id}
GET    /api/Games/search?title=SomeTitle
POST   /api/Games
PUT    /api/Games/{id}
PATCH  /api/Games/{id}
DELETE /api/Games/{id}
```

## Status

All required features from the assignment (Steps 1–33) are implemented.  
Optional features from the "Extra" section (filtering, sorting, pagination, etc.) are not yet included.