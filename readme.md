# Application Development

## Approaches

I use two main approaches for developing applications:

1. **Services**
   - Aspect-Oriented Framework (AOF)
   - Dependency Injection

2. **Mediator & CQRS**
   - Command Query Responsibility Segregation (CQRS)

## Technology Stack

- .NET 8
- Entity Framework 8
- SQL
- MS SQL Server

## Installation Folder Contents

- **SQL Statement**
- **SQL Script**
- **Postman Collections**:
  1. Share Owner
  2. Trader

## Getting Started

To get started with the project, follow these steps:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/yourusername/yourrepository.git
    ```

2. **Navigate to the project directory**:
    ```bash
    cd yourrepository
    ```

3. **Setup the database**:
   - Run the SQL scripts located in the `sql_script` folder to set up the database.

4. **Configure the application**:
   - Update the configuration files as necessary with your database connection strings and other settings.

5. **Run the application**:
    ```bash
    dotnet run
    ```

## Usage

### Postman Collections

You can find Postman collections for different user roles in the `postman_collection` folder:

1. **Share Owner**
2. **Trader**

Import these collections into Postman to test the APIs.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes or enhancements.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

