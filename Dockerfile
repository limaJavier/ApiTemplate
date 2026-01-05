# Stage 1: Publish
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS publish
WORKDIR /ApiTemplate

# Copy all projects
COPY src/ApiTemplate.Api/ApiTemplate.Api.csproj src/ApiTemplate.Api/
COPY src/ApiTemplate.Application/ApiTemplate.Application.csproj src/ApiTemplate.Application/
COPY src/ApiTemplate.Domain/ApiTemplate.Domain.csproj src/ApiTemplate.Domain/
COPY src/ApiTemplate.Infrastructure/ApiTemplate.Infrastructure.csproj src/ApiTemplate.Infrastructure/

# Create a new solution file
RUN dotnet new sln -n ApiTemplate
# Add all projects to solution
RUN dotnet sln add src/**/*.csproj 

# Restore solution
RUN dotnet restore

# Copy the rest of the source code
COPY src/ src/

# Publish the app
RUN dotnet publish src/ApiTemplate.Api/ApiTemplate.Api.csproj \
    -c Release \
    -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS run
WORKDIR /app

# Copy published output
COPY --from=publish /app/publish .

# Expose HTTP port
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ApiTemplate.Api.dll"]
