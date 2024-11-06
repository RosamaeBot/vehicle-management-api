Here's an updated version of the `SetupTestDatabase_VSCode.md` file, which now includes instructions for using the setup scripts.

---

# Setting Up a Test Database for the Vehicle Management API Using VS Code

This guide provides step-by-step instructions for setting up a test database (`TestDB`) for the Vehicle Management API using **Visual Studio Code** instead of **Visual Studio 2019**. The setup is facilitated by **SQL Server**, **VS Code’s SQL Server (mssql) extension**, and two Bash scripts to automate the installation of prerequisites and database setup.

---

## Prerequisites

1. **SQL Server** (preferably **LocalDB**) installed on your machine.
2. **VS Code** installed.
3. **Internet connection** to download the SQL setup script from GitHub.

If these prerequisites are not already installed, you can use the provided `setup_vscode_database_prereqs.sh` script to install them.

---

## Setup Scripts

The following scripts are located in the `DevScripts/Bash/Setup/` directory:

- **`setup_vscode_database_prereqs.sh`**: Installs the necessary prerequisites for setting up the database (SQL Server, mssql-cli, and the SQL Server extension for VS Code).
- **`setup_vscode_database.sh`**: Sets up the `TestDB` database and executes the SQL script to initialize it with tables and data.

---

### Step-by-Step Guide for Setting Up the Test Database in VS Code

#### 1. Run the Prerequisites Setup Script

To install the prerequisites, navigate to the `DevScripts/Bash/Setup/` directory in your terminal and run the following command:

```bash
./setup_vscode_database_prereqs.sh
```

This script will:
- Install SQL Server
- Install `mssql-cli` for command-line querying
- Install Visual Studio Code (if not already installed)
- Install the SQL Server (mssql) extension for VS Code

> **Note**: If you already have these prerequisites installed, you can skip this step.

#### 2. Run the Database Setup Script

After installing the prerequisites, run the `setup_vscode_database.sh` script to create the `TestDB` database and initialize it with tables and data:

```bash
./setup_vscode_database.sh
```

This script will:
- Connect to your SQL Server instance.
- Create the `TestDB` database.
- Download the SQL setup script from [GitHub](https://github.com/normanwongcl/vehicle-management-api/blob/master/Documentation/Database%20Design/TestDB.sql).
- Execute the script to create the necessary tables and data in `TestDB`.

---

### Verifying the Database Setup

After running the setup script, you can verify the database by connecting to **TestDB** in VS Code:

1. Open a new SQL file.
2. Run a test query to check the tables, for example:

   ```sql
   SELECT * FROM [YourTableName];
   ```

   Replace `[YourTableName]` with the actual table name created by the script.

---

### Troubleshooting

- **Connection Issues**: Ensure SQL Server is running and properly configured. You may need to restart the SQL Server service.
- **Script Errors**: Confirm that the SQL setup script downloaded correctly and that you are connected to `TestDB` when running it.

---

This guide and the scripts streamline setting up `TestDB` in VS Code, eliminating the need for Visual Studio 2019. For additional support, consult the **SQL Server Documentation** and **VS Code Extension Guide**.

