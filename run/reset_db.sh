#!/bin/bash

# Set variables
project_path="src/BuzluManav.Infrastructure/BuzluManav.Infrastructure.Persistence"
startup_project_path="src/BuzluManav.Presentation/BuzluManav.Presentation.WebAPI"
migration_name="Migration_$(date +%Y%m%d_%H%M%S)"

# Step 1: Drop the database
echo "Starting database drop..."
dotnet ef database drop -p $project_path -s $startup_project_path -f

if [ $? -eq 0 ]; then
  echo "Database successfully dropped."
else
  echo "Failed to drop the database."
  exit 1
fi

# Step 2: Update the database (apply migrations)
echo "Updating database with existing migrations..."
dotnet ef database update -p $project_path -s $startup_project_path

if [ $? -eq 0 ]; then
  echo "Database successfully updated."
else
  echo "Failed to update the database."
  exit 1
fi

# Step 3: Create a new migration
echo "Creating a new migration with name: $migration_name ..."
dotnet ef migrations add $migration_name -p $project_path -s $startup_project_path

if [ $? -eq 0 ]; then
  echo "Migration '$migration_name' created successfully."
else
  echo "Failed to create migration."
  exit 1
fi

# Step 4: Apply the new migration to the database
echo "Applying migrations to update the database..."
dotnet ef database update -p $project_path -s $startup_project_path

if [ $? -eq 0 ]; then
  echo "Database successfully updated with the new migration."
else
  echo "Failed to update the database with the new migration."
  exit 1
fi

echo "All steps completed successfully!"
