# Task & Project Management Platform

## Overview
This project is a Task & Project Management Platform designed to help users manage their tasks and projects efficiently. It consists of a backend built with .NET and a frontend developed using React. The application includes features for user management, project management, task management, notifications, and more.

## Project Structure
The project is organized into three main directories: `backend`, `frontend`, and `database`.

- **backend**: Contains the server-side application built with .NET.
  - `src`: The source code for the backend application.
    - `Domain`: Contains domain models and entities.
    - `Application`: Includes application services, commands, and queries.
    - `Infrastructure`: Contains data access implementations and external services.
    - `Presentation`: Includes API controllers and the entry point of the application.
  - `appsettings.json`: Configuration settings for the backend application.
  - `TaskProjectManagementPlatform.sln`: Solution file for managing multiple projects.
  - `TaskProjectManagementPlatform.csproj`: Project file specifying dependencies and build settings.
  - `README.md`: Documentation specific to the backend application.

- **frontend**: Contains the client-side application built with React.
  - `src`: The source code for the frontend application.
    - `components`: Reusable React components.
    - `pages`: Page components representing different views.
    - `store`: State management logic.
    - `App.tsx`: Main application component.
    - `main.tsx`: Entry point of the frontend application.
  - `public`: Contains the main HTML file for the frontend application.
  - `package.json`: Configuration file for npm.
  - `tsconfig.json`: Configuration file for TypeScript.
  - `README.md`: Documentation specific to the frontend application.

- **database**: Contains configurations for running the database in Docker.
  - `docker-compose.yml`: Defines services and configurations for the database.
  - `README.md`: Documentation specific to the database setup.

- **.github**: Contains CI/CD workflows using GitHub Actions.
  - `workflows`: Directory for GitHub Actions workflows.

## Getting Started
To get started with the project, follow these steps:

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the backend directory and restore the dependencies:
   ```
   cd backend
   dotnet restore
   ```

3. Navigate to the frontend directory and install the dependencies:
   ```
   cd frontend
   npm install
   ```

4. Set up the database using Docker:
   ```
   cd database
   docker-compose up -d
   ```

5. Run the backend application:
   ```
   cd backend
   dotnet run
   ```

6. Run the frontend application:
   ```
   cd frontend
   npm start
   ```

## Extensions for Visual Studio Code
To enhance your development experience, consider installing the following extensions:

1. C# (ms-dotnettools.csharp) - For backend development with .NET.
2. ESLint (dbaeumer.vscode-eslint) - For linting JavaScript/TypeScript code in the frontend.
3. Prettier - Code formatter (esbenp.prettier-vscode) - For code formatting in JavaScript/TypeScript.
4. Docker (ms-azuretools.vscode-docker) - For managing Docker containers and images.
5. GitHub Actions (GitHub.vscode-github-actions) - For working with GitHub Actions workflows.
6. TypeScript (ms-vscode.vscode-typescript-next) - For TypeScript support in the frontend.

## Contributing
Contributions are welcome! Please read the [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.