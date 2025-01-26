#!/bin/bash

# Drop the database
echo "Starting database drop..."
dotnet ef database drop -p src/BuzluManav.Infrastructure/BuzluManav.Infrastructure.Persistence -s src/BuzluManav.Presentation/BuzluManav.Presentation.WebAPI -f

if [ $? -eq 0 ]; then
  echo "Database successfully dropped."
else
  echo "Failed to drop the database."
  exit 1
fi
