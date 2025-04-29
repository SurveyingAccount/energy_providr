# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . ./

# Restore dependencies and publish the app
RUN dotnet publish "energy_providr.csproj" -c Release -o out

# Use a smaller runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose port 5000 (or whatever ASP.NET Core binds to)
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "energy_providr.dll"]
