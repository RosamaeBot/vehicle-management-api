#!/bin/bash

# Database configuration
DB_SERVER="(localdb)\MSSQLLocalDB"
DB_NAME="TestDB"
SQL_SCRIPT_URL="https://github.com/normanwongcl/vehicle-management-api/raw/master/Documentation/Database%20Design/TestDB.sql"
SQL_SCRIPT_FILE="TestDB.sql"

# Check for mssql-cli
if ! command -v mssql-cli &> /dev/null; then
    echo "Please install mssql-cli with 'pip install mssql-cli'"
    exit 1
fi

# Download SQL script
curl -o "$SQL_SCRIPT_FILE" -L "$SQL_SCRIPT_URL"

# Create TestDB and run script
mssql-cli -S "$DB_SERVER" -Q "IF DB_ID('$DB_NAME') IS NULL CREATE DATABASE [$DB_NAME];"
mssql-cli -S "$DB_SERVER" -d "$DB_NAME" -i "$SQL_SCRIPT_FILE"

# Clean up
rm "$SQL_SCRIPT_FILE"
echo "Database setup complete!"
