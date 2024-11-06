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
