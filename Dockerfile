# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["HomeServer.sln", "."]
COPY ["HomerServer.ExtApi/HomerServer.ExtApi.csproj", "HomerServer.ExtApi/"]

# Restore dependencies
RUN dotnet restore "HomeServer.sln"

# Copy the rest of the source code
COPY . .

# Build the solution
RUN dotnet build "HomeServer.sln" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "HomeServer.sln" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
EXPOSE 8443

ENTRYPOINT ["dotnet", "HomerServer.ExtApi.dll"]
