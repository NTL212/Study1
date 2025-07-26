# Database Setup Documentation

This directory contains the necessary files and instructions for setting up the database for the Task & Project Management Platform.

## Docker Configuration

The `docker-compose.yml` file is used to define and run the database services in a Docker container. Ensure that Docker is installed and running on your machine before proceeding.

### Steps to Run the Database

1. **Navigate to the database directory**:
   ```bash
   cd database
   ```

2. **Start the database services**:
   ```bash
   docker-compose up -d
   ```

3. **Access the database**:
   You can connect to the database using your preferred database client or through the command line.

4. **Stopping the services**:
   To stop the database services, run:
   ```bash
   docker-compose down
   ```

## Database Configuration

Make sure to configure the connection strings in the backend application's `appsettings.json` file to point to the database service defined in the `docker-compose.yml`.

## Additional Information

For more details on how to interact with the database, refer to the documentation of the specific database you are using (e.g., PostgreSQL, SQL Server).

Feel free to reach out if you have any questions or need further assistance!