#!/bin/bash

# Update the database (apply migrations)
echo "Applying migrations to update the database..."
dotnet ef database update -p src/BuzluManav.Infrastructure/BuzluManav.Infrastructure.Persistence -s src/BuzluManav.Presentation/BuzluManav.Presentation.WebAPI

if [ $? -eq 0 ]; then
  echo "Database successfully updated."
else
  echo "Failed to update the database."
  exit 1
fi
