# Use the ASP.NET 8.0 runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET 8.0 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy EVERYTHING from the repository root
COPY . .

# Restore and Build using the full path to the solution
RUN dotnet restore "Library-Management-System-BE/LMS.sln"
RUN dotnet build "Library-Management-System-BE/LMS.sln" -c Release -o /app/build

# Publish the API project
FROM build AS publish
WORKDIR "/src/Library-Management-System-BE/LMS.API"
RUN dotnet publish "LMS.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: copy the published app to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS.API.dll"]
