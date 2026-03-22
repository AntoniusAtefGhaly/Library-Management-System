# Use the ASP.NET 8.0 runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET 8.0 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy EVERYTHING in the current folder (Library-Management-System-BE)
COPY . .

# Restore and Build
RUN dotnet restore "LMS.API/LMS.API.csproj"
RUN dotnet build "LMS.API/LMS.API.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "LMS.API/LMS.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: copy the published app to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS.API.dll"]
