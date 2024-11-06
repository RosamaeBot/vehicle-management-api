# Fleet Management SystemAPI

Fleet Management SystemAPI built using the [ApiBoilerPlate.AspNetCore](https://github.com/proudmonkey/ApiBoilerPlate) project template.

## Requirements
- .NET Core SDK: 3.1 or higher
- .NET Core runtime:
  - Microsoft.AspNetCore.App: 3.1.7 or higher
  - Microsoft.NETCore.App: 3.1.7 or higher

### Task Requirements and Documentation
- [Task Requirements](https://github.com/normanwongcl/Fleet-management-api/blob/master/Documentation/)
- [Documentation](https://github.com/normanwongcl/Fleet-management-api/blob/master/Documentation/)

## Prerequisite Installation

Installation instructions for various operating systems:

- [Windows](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=netcore31)
- [macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos)
- [Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux)

For WSL Ubuntu users, see the following [guide](https://ubuntu.com/blog/creating-cross-platform-applications-with-net-on-ubuntu-on-wsl) for .NET installation.

## Installation

```bash
# Clone repository
git clone git@github.com:normanwongcl/Fleet-management-api.git

# Navigate into the project directory
cd Fleet-management-api

# Restore dependencies
dotnet restore
```

## Setting Up a Test Database

The test database for the Fleet Management SystemAPI can be set up using **Visual Studio Code** and **SQL Server** by following these steps or by using the automated setup scripts provided.

### Automated Setup Using Scripts

Navigate to the `DevScripts/Bash/Setup` directory and run the following scripts:

1. **Install Prerequisites**: 
   ```bash
   ./setup_vscode_database_prereqs.sh
   ```

   This script installs SQL Server, `mssql-cli`, and the SQL Server extension for VS Code.

2. **Set Up the Test Database**: 
   ```bash
   ./setup_vscode_database.sh
   ```

   This script connects to the local SQL Server instance, creates the `TestDB` database, and runs the SQL script to initialize the database.

For manual setup, please refer to the updated [SetupTestDatabase_VSCode.md](https://github.com/normanwongcl/Fleet-management-api/blob/master/Documentation/Database%20Setup%20Guidelines/SetupTestDatabaseOnVSCode.md) guide.

## Running Tests

Run tests using the dotnet CLI or in Visual Studio Code:

```bash
dotnet test
```

## Project Structure

Details on the project folder structure and its components can be found in the following articles:

- [ApiBoilerPlate: A Project Template for ASP.NET Core APIs](https://vmsdurano.com/apiboilerplate-a-project-template-for-building-asp-net-core-apis/)
- [ApiBoilerPlate: New Features and Improvements for ASP.NET Core 3 APIs](https://vmsdurano.com/apiboilerplate-new-features-and-improvements-for-building-asp-net-core-3-apis/)

## Deployment

```bash
# Deployment instructions will be added here
```

## Tooling Decision

### Why .NET Core?

.NET Core is considered the default for building .NET projects according to [ThoughtWorks](https://www.thoughtworks.com/radar/platforms/net-core), as it is cross-platform and highly performant.

### Why ApiBoilerPlate.AspNetCore?

The boilerplate provides a structured setup that helps streamline setting up essential components like logging, CORS, unit tests, model/entity definitions, controllers, and API documentation in ASP.NET Core. This has been invaluable for transitioning from C# basics to designing a REST API within a short timeframe.
