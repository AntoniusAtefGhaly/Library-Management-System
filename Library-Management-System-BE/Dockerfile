# Use the ASP.NET 8.0 runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET 8.0 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all the .csproj files and restore dependencies
COPY ["LMS.API/LMS.API.csproj", "LMS.API/"]
COPY ["LMS.Application/LMS.Application.csproj", "LMS.Application/"]
COPY ["LMS.Domain/LMS.Domain.csproj", "LMS.Domain/"]
COPY ["LMS.Infrastructure/LMS.Infrastructure.csproj", "LMS.Infrastructure/"]
RUN dotnet restore "LMS.API/LMS.API.csproj"

# Copy the rest of the source code and build
COPY . .
WORKDIR "/src/LMS.API"
RUN dotnet build "LMS.API.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "LMS.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: copy the published app to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LMS.API.dll"]
