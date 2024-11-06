Here's the updated README that uses the new GitHub repository path `tonydev-tools/glbltrck-fleet-management-api`:

---

# GlobalTrack Fleet Management API

GlobalTrack Fleet Management API built using the [ApiBoilerPlate.AspNetCore](https://github.com/proudmonkey/ApiBoilerPlate) project template.

## Overview

This API provides a foundation for managing fleet and vehicle data, built on .NET Core and utilizing SQL Server for data management.

## Requirements
- .NET Core SDK: 3.1 or higher
- .NET Core runtime:
  - Microsoft.AspNetCore.App: 3.1.7 or higher
  - Microsoft.NETCore.App: 3.1.7 or higher

### Documentation
- [Task Requirements and Documentation](https://github.com/tonydev-tools/glbltrck-fleet-management-api/blob/master/Documentation/)

## Quick Setup - RunMe Script

The `RunMe` script automates the setup of your development environment, including dependency installation, database setup, and prerequisites for the Fleet Management API. Make sure you have `bash` installed on your system to use this script.

### Steps

1. **Clone the Repository**

   ```bash
   git clone git@github.com:tonydev-tools/glbltrck-fleet-management-api.git
   cd glbltrck-fleet-management-api
   ```

2. **Run the Setup Script**

   Run the following command to execute the setup script:

   ```bash
   ./RunMe.sh
   ```

   The script performs the following tasks:

   - Installs prerequisites for the API.
   - Installs necessary packages for .NET Core development.
   - Sets up a local SQL Server test database using `DevScripts/Bash/Setup/setup_vscode_database.sh` and `DevScripts/Bash/Setup/setup_vscode_database_prereqs.sh`.

### RunMe Script Breakdown

Here is what `RunMe.sh` does in detail:

```bash
#!/bin/bash

# Step 1: Install Prerequisites
echo "Installing prerequisites..."
bash DevScripts/Bash/Setup/setup_vscode_database_prereqs.sh

# Step 2: Restore .NET Dependencies
echo "Restoring .NET dependencies..."
dotnet restore

# Step 3: Set Up Test Database
echo "Setting up test database..."
bash DevScripts/Bash/Setup/setup_vscode_database.sh

echo "Development environment setup complete!"
```

## Manual Installation Instructions

If you prefer to set up the environment manually, please follow these instructions:

1. **Install Prerequisites**: Refer to the prerequisites in the “Documentation” section, or use the following script for Ubuntu:
   ```bash
   ./DevScripts/Bash/Setup/setup_vscode_database_prereqs.sh
   ```

2. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Set Up the Test Database**:
   ```bash
   ./DevScripts/Bash/Setup/setup_vscode_database.sh
   ```

## Testing the API

Once setup is complete, you can run tests to ensure everything is working correctly:

```bash
dotnet test
```

## Project Structure

The project structure is based on ApiBoilerPlate.AspNetCore and provides a clean architecture for ASP.NET Core APIs. See the documentation links for more details.

## Deployment

For deployment instructions, please refer to the relevant [documentation section](https://github.com/tonydev-tools/glbltrck-fleet-management-api/blob/master/Documentation/).

---

This updated README should help guide you through the setup using the new GitHub repository path. Let me know if further customization is needed!