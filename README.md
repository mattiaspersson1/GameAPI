Tournament API
A .NET 8 Web API for managing tournaments and games.
This project demonstrates clean architecture, the repository pattern, Unit of Work, AutoMapper, DTOs, PATCH support, and full CRUD operations.

Technologies Used
ASP.NET Core Web API (.NET 8)

Entity Framework Core (Code First)

SQL Server LocalDB

AutoMapper

Newtonsoft.Json

Swagger / Postman

Project Structure
Project	Description
Tournament.Api	API layer: controllers, DI setup, Swagger
Tournament.Core	Domain layer: entities, DTOs, interfaces
Tournament.Data	Infrastructure: DbContext, repositories, seeders

Features
Entity models with validation attributes

Data Transfer Objects (DTOs)

Repository pattern and Unit of Work

Dependency Injection

Full CRUD operations (GET, POST, PUT, DELETE)

PATCH support for partial updates

Data seeding on startup

Search games by exact title

Swagger documentation

Status codes and error handling

Getting Started
Prerequisites
Visual Studio 2022 or later

.NET 8 SDK

SQL Server LocalDB (installed with Visual Studio)

Run the Application
Clone the repository:

bash
Kopiera
Redigera
git clone https://github.com/mattiaspersson1/TournamentAPI.git
cd TournamentAPI
Apply the initial database migration:

pgsql
Kopiera
Redigera
cd Tournament.Data
dotnet ef database update
Run the API:

arduino
Kopiera
Redigera
cd ..
dotnet run --project Tournament.Api
Open the Swagger UI in your browser:

bash
Kopiera
Redigera
https://localhost:{port}/swagger
API Examples
GET /api/Tournaments

GET /api/Tournaments/5

POST /api/Tournaments

PUT /api/Tournaments/5

PATCH /api/Tournaments/5

DELETE /api/Tournaments/5

GET /api/Games/search?title=SomeTitle

Status
All required functionality from the assignment instructions (Steps 1–33) is implemented.
Optional features in the "Extra" section (e.g., filtering, sorting, pagination) are not included.
