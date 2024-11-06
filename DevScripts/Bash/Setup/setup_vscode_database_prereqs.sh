#!/bin/bash

# Exit immediately if a command exits with a non-zero status
set -e

# Step 1: Update and install necessary packages
echo "Updating system packages..."
sudo apt update -y && sudo apt upgrade -y

# Step 2: Install SQL Server (for Ubuntu). If you are using another Linux distro, adjust accordingly.
# Add Microsoft repository and import keys
echo "Installing SQL Server..."
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/mssql-server-2019.list)"
sudo apt update
sudo apt install -y mssql-server

# Configure SQL Server (unattended installation with default settings)
sudo /opt/mssql/bin/mssql-conf setup accept-eula

# Step 3: Install mssql-cli for command-line SQL querying
echo "Installing mssql-cli..."
pip install mssql-cli --user

# Step 4: Install Visual Studio Code (if not already installed)
if ! command -v code &> /dev/null; then
    echo "Installing Visual Studio Code..."
    wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > packages.microsoft.gpg
    sudo install -o root -g root -m 644 packages.microsoft.gpg /usr/share/keyrings/
    sudo sh -c 'echo "deb [arch=amd64 signed-by=/usr/share/keyrings/packages.microsoft.gpg] https://packages.microsoft.com/repos/vscode stable main" > /etc/apt/sources.list.d/vscode.list'
    sudo apt update
    sudo apt install -y code
fi

# Step 5: Install SQL Server (mssql) extension for VS Code
echo "Installing SQL Server extension for VS Code..."
code --install-extension ms-mssql.mssql

# Final message
echo "Prerequisites setup complete! SQL Server, mssql-cli, and the SQL Server extension for VS Code are installed."
echo "You can now proceed with setting up the test database."

