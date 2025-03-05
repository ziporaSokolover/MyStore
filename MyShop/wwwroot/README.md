# Dotnet WebAPI Project

## Overview

This project is a .NET WebAPI designed with a REST architecture, adhering strictly to REST principles. It includes CI/CD processes to ensure smooth integration and deployment. The project features a well-structured use of status codes and is divided into layers, each with a specific responsibility.

## Project Structure

The project is divided into the following layers:

- **Controller**: Manages the connection between the client and the server, handling error statuses.
- **Service**: Responsible for validations and business logic.
- **Repository**: Manages data access to the database.

### Layer Interaction

The layers communicate with each other through dependency injection (DI). This approach ensures that the logic is written once and can be injected wherever needed in the project. DI allows for efficient project management; if a change is needed in the code, it can be made in one place. The logic for DI is defined in the `program.cs` file.

## Data Transfer Objects (DTOs)

The project uses DTOs defined as records since there is no need to modify the objects. The benefits of using DTOs include:

1. Removing circular dependencies between objects.
2. Allowing partial return or acceptance of objects for security purposes.

### AutoMapper

Conversion between layers using DTOs is done via AutoMapper.

## Asynchronous Programming

The project utilizes the `async/await` mechanism to enhance scalability.ã

## Database

The database used is SQL, and EntityFramework is employed for ORM. The project follows the Code First approach. To create the database, use the following commands:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Configuration Management

The project uses configuration files to manage settings, such as `appsettings.json`, which allows for defining environment variables, application settings, and other configurations that can be easily updated or changed without modifying the main codebase. Examples include API keys and database connection strings, which are stored separately from the source code.

## Error Handling

All errors are handled using middleware. Errors are logged using a logger, and in case of a critical error, an alert email is sent.

## Request Monitoring

All requests to the site are saved in a `rating` table in the database for monitoring and analysis purposes.

## Clean Code

The project emphasizes writing clean and maintainable code, following best practices and design patterns.

## Additional Tools and Libraries

The project makes use of several additional tools and libraries to enhance functionality and maintainability:

- **FluentValidation**: Used for validation of models and DTOs.
- **Serilog**: Used for logging errors and application events.
- **MailKit**: Used for sending emails in case of critical errors.
- **Swagger**: Used for API documentation and testing.
- **Postman**: Used for testing API endpoints during development.

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Configure the `appsettings.json` file with your environment settings.
4. Run the application.

## Dependencies

- .NET 8.0
- EntityFramework
- AutoMapper
- FluentValidation
- Serilog
- MailKit
- Swagger



## API Documentation

The API documentation is available via Swagger. You can access it at the following link: [Swagger Documentation](https://localhost:44362/SWAGGER/v1/swagger.json)