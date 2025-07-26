# Task & Project Management Platform - Backend

This is the backend for the Task & Project Management Platform, built using ASP.NET Core. The backend is structured to follow Clean Architecture principles, separating concerns into different layers: Domain, Application, Infrastructure, and Presentation.

## Project Structure

- **Domain**: Contains domain models and entities that represent the core business logic of the application.
- **Application**: Includes application services, commands, and queries that handle the business logic and interact with the domain layer.
- **Infrastructure**: Contains implementations for data access, repositories, and external services.
- **Presentation**: Includes the presentation layer of the application, specifically the API controllers.

## Configuration

The application settings are stored in `appsettings.json`, which includes connection strings and other configuration settings necessary for the backend to function.

## Build and Run

To build and run the backend application, use the following commands:

1. Restore dependencies:
   ```
   dotnet restore
   ```

2. Build the project:
   ```
   dotnet build
   ```

3. Run the application:
   ```
   dotnet run
   ```

## Extensions for Visual Studio Code

To enhance your development experience, consider installing the following extensions:

1. **C#** (ms-dotnettools.csharp) - For backend development with .NET.
2. **ESLint** (dbaeumer.vscode-eslint) - For linting JavaScript/TypeScript code in the frontend.
3. **Prettier - Code formatter** (esbenp.prettier-vscode) - For code formatting in JavaScript/TypeScript.
4. **Docker** (ms-azuretools.vscode-docker) - For managing Docker containers and images.
5. **GitHub Actions** (GitHub.vscode-github-actions) - For working with GitHub Actions workflows.
6. **TypeScript** (ms-vscode.vscode-typescript-next) - For TypeScript support in the frontend.

## Contribution

Feel free to contribute to this project by submitting issues or pull requests. Your feedback and contributions are welcome!

## License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details.