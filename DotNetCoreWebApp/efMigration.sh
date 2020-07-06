#!/bin/bash

dotnet-ef dbcontext Scaffold \
  "Server=localhost;Database=DemoApplication;User ID=sa;Password=SecureAF!;" \
  Microsoft.EntityFrameworkCore.SqlServer -o ./Repositories/Entities/ \
  --verbose --force
