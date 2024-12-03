Project Architecture and Technology Overview:


This project is built using the principles of Clean Architecture with a focus on maintainability, scalability, and testability. Below is a brief explanation of the architecture and technologies used:
//*********************************************
Architecture
//*********************************************
Clean Architecture:

Centralized around core business logic, ensuring separation of concerns.

//----------------
Layers include:
//----------------
API Layer (Presentation): Handles HTTP requests and returns appropriate responses.
Service Layer (Application): Contains the business logic and acts as the intermediary between the API and data layers.
Data Layer (Infrastructure): Manages database access and repositories.
Shared Layer: Contains reusable components like DTOs and models.


//---------------
Minimal APIs:
//---------------
Utilizes .NET's Minimal API features for defining endpoints with concise syntax, reducing boilerplate code.
Promotes simplicity and performance.

//------------------
Repository Pattern:
//------------------

Abstracts database interactions, providing flexibility in changing the underlying data source.
Testing with TDD:

Adopts Test-Driven Development using xUnit.
Includes unit tests for services and repositories.

//******************************************
Technologies
//******************************************

.NET 9: Leverages the latest features of .NET, including improved performance and new APIs.
In-Memory Database: Uses Microsoft.EntityFrameworkCore.InMemory for simplified database setup during development and testing.
Entity Framework Core: For seamless database operations.
Swagger/OpenAPI: Auto-generates API documentation and a testing interface.
Dependency Injection: Built-in support to manage service lifetimes and dependencies.
In-Memory Database: Optimized for development but not suited for production. Replace with SQL Server or another relational database in production.
Minimal APIs: Improves startup performance and runtime efficiency due to reduced overhead.

This project demonstrates a modern approach to API development using Clean Architecture and .NET's latest capabilities. It is well-structured for extensibility, suitable for enterprise applications.

//************************************************
Conclusion
//**************************************************
This project demonstrates a modern approach to API development using Clean Architecture and .NET's latest capabilities. It is well-structured for extensibility, suitable for enterprise applications, and includes a foundation for robust testing and authentication.





