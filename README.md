# PJConsulting

A side project to experiment with .NET and C# Web API development. Built with ASP.NET Core 10 and Entity Framework Core backed by SQL Server.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- EF Core CLI tools: `dotnet tool install --global dotnet-ef`

## Getting started

### 1. Clone the repo

```bash
git clone https://github.com/philjohnson74/PJConsulting.git
cd PJConsulting
```

### 2. Start a local SQL Server in Docker

```bash
docker run -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=YourPasswordHere!" \
  -p 1433:1433 \
  --name sqlserver \
  -d mcr.microsoft.com/azure-sql-edge
```

Wait ~15 seconds for the container to become ready before continuing.

### 3. Configure the local connection string

`appsettings.Development.json` is git-ignored and is where local credentials live. Create the file at `PJConsulting-WebAPI/appsettings.Development.json` with the following content, substituting the password you used above:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "PJConsultingDbConnectionString": "Server=localhost,1433;Database=PJConsultingDb;User Id=sa;Password=YourPasswordHere!;TrustServerCertificate=True;"
  }
}
```

### 4. Run migrations

```bash
cd PJConsulting-WebAPI
dotnet ef database update
```

This creates the `PJConsultingDb` database and applies all pending migrations.

### 5. Run the API

```bash
dotnet run
```

The API will be available at:

- HTTP: `http://localhost:5200`
- HTTPS: `https://localhost:7212`

OpenAPI schema: `http://localhost:5200/openapi/v1.json`

## Project structure

```
PJConsulting-WebAPI/
├── Controllers/        # API controllers
├── Data/               # EF Core DbContext and entity models
├── Migrations/         # EF Core migration files
├── appsettings.json              # Shared config (no credentials)
└── appsettings.Development.json  # Local config (git-ignored)
```

## Adding new migrations

After modifying entities in `Data/`, generate a new migration from the `PJConsulting-WebAPI` directory:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```
