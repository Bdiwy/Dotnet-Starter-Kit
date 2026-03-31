 # InvoiceHub 🚀

A professional, scalable invoicing system built with **.NET 9**, **MySQL**, and **Clean Architecture**.

---

## 🏗️ Architecture Overview

This project follows **Clean Architecture** (Onion Architecture) to ensure the core business logic is independent of frameworks, UI, and databases.

### 🧩 Project Layers & Responsibilities

1. **Domain** (Core Layer)
   - **Role:** The heart of the application. Contains enterprise-wide logic and types.
   - **Contents:** Entities (`Invoice`, `Client`), Value Objects, Enums, and Repository Interfaces.
   - **Dependencies:** None.

2. **Application** (Orchestration Layer)
   - **Role:** Contains application-specific business rules. It coordinates the data flow to and from the domain.
   - **Contents:** MediatR Commands/Queries, DTOs, FluentValidation, and Mapping logic.
   - **Logic Note:** This is where "Services" live as **Handlers**. It handles workflows like "When an invoice is created, decrease stock and send an email."
   - **Dependencies:** Depends only on `Domain`.

3. **Infrastructure** (External Concerns)
   - **Role:** Implements interfaces defined in the core layers. Deals with the "How" of data persistence.
   - **Contents:** `InvoiceDbContext` (EF Core), MySQL Migrations, Repository Implementations, and Identity (JWT) logic.
   - **Dependencies:** Depends on `Application`.

4. **Api** (Presentation Layer)
   - **Role:** The entry point for the user. Handles HTTP requests and returns responses.
   - **Contents:** Controllers, Middleware (Authentication/Logging), and DI (Dependency Injection) Registration.
   - **Dependencies:** Depends on `Infrastructure`.

---

## 💡 Where Does the Logic Go?

- **Domain Logic:** If it's a rule that never changes (e.g., *Total = Price × Quantity*), it goes inside the **Domain Entity**.
- **Application Logic:** If it's a workflow involving multiple steps or external systems (e.g., *Check User → Create Invoice → Save to DB → Log Activity*), it goes into the **Application Handlers**.

---

## 🐳 Dockerized Environment

The project uses **multi-stage builds** to keep images small (Alpine-based) and fast.

### 🚀 Quick Start

To build and start the API, MySQL, and phpMyAdmin:

```bash
docker-compose up -d --build
```

### 🔗 Service Endpoints

| Service    | URL                     | Credentials                  |
|------------|-------------------------|------------------------------|
| Web API    | http://localhost:5000  | -                            |
| phpMyAdmin | http://localhost:8081  | User: root / Pass: rootpassword |
| MySQL DB   | localhost:3306         | User: root / Pass: rootpassword |

### 🛠️ Development Workflow

How to rebuild after code changes:

Whenever you update your C# code, run:

```bash
docker-compose build api
docker-compose up -d api
```

### Database Migrations

Since the DB is in a container, run migrations through the API container or via the CLI targeting the infrastructure project:

```bash
# Add a new migration
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project Api

# Update database
dotnet ef database update --project Infrastructure --startup-project Api
```

### 🔐 Security (JWT)

Authentication is handled via JWT (JSON Web Tokens).

- Configuration is located in `Api/appsettings.json`.
- Validation logic is implemented in the `Program.cs` of the API layer.

### ⚙️ Configuration Note

Inside the Docker network, the API communicates with the database using the service name `db` (e.g., `Server=db;...`) instead of `localhost`. This is configured in the `docker-compose.yml` environment variables.