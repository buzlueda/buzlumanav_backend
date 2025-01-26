#!/bin/bash

# Generate a unique migration name based on the current timestamp
migration_name="Migration_$(date +%Y%m%d_%H%M%S)"

# Create a new migration
echo "Creating a new migration with name: $migration_name ..."
dotnet ef migrations add $migration_name -p src/BuzluManav.Infrastructure/BuzluManav.Infrastructure.Persistence -s src/BuzluManav.Presentation/BuzluManav.Presentation.WebAPI

if [ $? -eq 0 ]; then
  echo "Migration '$migration_name' created successfully."
else
  echo "Failed to create migration."
  exit 1
fi
