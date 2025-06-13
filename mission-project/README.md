# Mission Management System

A comprehensive .NET Core Web API project for managing missions and related activities. This project was developed as part of a training program, with each day building upon the previous day's work.

## Project Structure

The project follows Clean Architecture principles and is organized as follows:

```
Mission-Project/
├── src/
│   ├── Mission.API/           # Main API project
│   ├── Mission.Core/          # Core business logic
│   ├── Mission.Infrastructure/# Data access and external services
│   └── Mission.Domain/        # Domain models and interfaces
├── tests/                     # Test projects
└── docs/                      # Documentation for each day's progress
```

## Technology Stack

- .NET Core Web API
- PostgreSQL Database
- Entity Framework Core
- JWT Authentication
- Swagger/OpenAPI
- Clean Architecture

## Features

- User Authentication and Authorization
- Mission Management
- Theme Management
- Admin User Management
- RESTful API endpoints

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- PostgreSQL
- Visual Studio 2022 or VS Code

### Setup

1. Clone the repository
```bash
git clone [your-repo-url]
```

2. Update the connection string in `appsettings.json` with your PostgreSQL credentials

3. Run the database migrations
```bash
dotnet ef database update
```

4. Run the application
```bash
dotnet run
```

5. Access the Swagger UI at `https://localhost:5001/swagger`

## API Documentation

The API documentation is available through Swagger UI when running the application. The following main endpoints are available:

- `/api/auth` - Authentication endpoints
- `/api/users` - User management
- `/api/missions` - Mission management
- `/api/themes` - Theme management

## Development Progress

### Day 1
- Initial project setup
- Basic architecture implementation
- Database configuration

### Day 2
- User authentication implementation
- JWT token integration
- Basic CRUD operations

### Day 3
- Mission management features
- Theme implementation
- Enhanced security

### Day 4
- Additional business logic
- Performance improvements
- Code refactoring

### Day 5
- Final features and improvements
- Documentation
- Testing

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Training Program Team
- .NET Core Community
- All contributors 