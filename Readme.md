# InvoiceHub 🚀

A modern, scalable invoicing system built with **.NET 9**, **MySQL**, and **Clean Architecture** principles.

## 🏗️ Architecture Overview

This project follows **Clean Architecture** to ensure separation of concerns, testability, and independence from external frameworks.

### 🧩 Project Layers

* **InvoiceHub.Domain**: The core of the system. Contains Enterprise logic, Entities (`Invoice`, `Client`), Enums, and Repository Interfaces. It has **zero** dependencies.
* **InvoiceHub.Application**: The "Orchestrator" layer. Contains business logic, DTOs, Mapping, and Request Handlers (MediatR). This is where the **Application Services** live.
* **InvoiceHub.Infrastructure**: Handles external concerns. Implements the MySQL database context using **EF Core**, Identity (JWT), and file storage.
* **InvoiceHub.Api**: The entry point. Handles HTTP requests, Middleware (Authentication/Logging), and Dependency Injection (DI) registration.



---

## 💡 Logic & Service Flow

In this project, logic is distributed based on its responsibility:

1.  **Domain Logic**: Logic that belongs to the entity (e.g., calculating taxes on an invoice) stays inside the `Domain` entities.
2.  **Application Logic (Services)**: Complex workflows that involve multiple entities or external services are handled in the `Application` layer using **MediatR Handlers**. This replaces traditional "Fat Services" with granular, focused classes.

---

## 🛠️ Tech Stack

- **Backend**: .NET 9 (C#)
- **Database**: MySQL (via Pomelo.EntityFrameworkCore.MySql)
- **Authentication**: JWT Bearer Tokens
- **Patterns**: CQRS (MediatR), Repository Pattern, Result Pattern

## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- MySQL Server

### Configuration
Update the connection string in `InvoiceHub.Api/appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InvoiceHubDb;User=root;Password=yourpassword;"
}