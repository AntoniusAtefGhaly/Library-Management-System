# Deployment & CI/CD Guide

This guide explains how the Library Management System is configured for production, including the backend migration to PostgreSQL and deployment to Render.com.

---

## ⚡ Project Links
- **Frontend (Vercel)**: [library-management-system-fe](https://library-management-system-git-main-antoniusatefghalys-projects.vercel.app/authors)
- **Backend (Render Dashboard)**: [library-management-api](https://dashboard.render.com/web/srv-d701n1450q8c739ue0h0)
- **Backend (API Base URL)**: [library-management-api-h3en.onrender.com](https://library-management-api-h3en.onrender.com/api)
- **Database (Neon Console)**: [floral-rice-2102](https://console.neon.tech/app/projects/floral-rice-21020274?database=neondb)

---


## 1. Prerequisites
- **GitHub Repository**: For version control and CI/CD triggers.
- **Neon.tech**: Managed PostgreSQL database.
- **Render.com**: For hosting the Dockerized backend.

---

## 2. Database Migration (Postgres)

We migrated from SQL Server to PostgreSQL using Entity Framework Core.

### **Steps Taken:**
1.  **Updated NuGet Packages**: 
    - Replaced `Microsoft.EntityFrameworkCore.SqlServer` with `Npgsql.EntityFrameworkCore.PostgreSQL`.
    - Updated Hangfire to use `Hangfire.PostgreSql`.
2.  **Code Updates**:
    - Modified `Program.cs` to use `.UseNpgsql(connectionString)`.
    - Added a global fix for PostgreSQL's `DateTime` requirements: `AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);`.
3.  **Migration Reset**:
    - Deleted the old `Migrations/` folder.
    - Ran `dotnet ef migrations add InitialPostgres` to create a fresh schema.
    - Applied changes with `dotnet ef database update`.

---

## 3. Docker Configuration

The backend is containerized to ensure it runs the same way locally and in the cloud.

### **Dockerfile (Monorepo Strategy)**
We use a multi-stage `Dockerfile` located in `Library-Management-System-BE/Dockerfile`. It uses a "Repo Root" strategy to handle dependencies correctly.

- **Base Image**: ASP.NET 8.0 Runtime.
- **Build Image**: .NET 8.0 SDK.
- **Process**: Copies the whole repository context, restores the `.sln` file, and publishes the `LMS.API` project.

### **.dockerignore**
Prevents `bin/`, `obj/`, and local settings files from being sent to the Docker daemon, speeding up builds.

---

## 4. Render.com Setup

To host the backend on Render:

1.  **Create a New Web Service**: Connect your GitHub repository.
2.  **Runtime**: Select `Docker`.
3.  **Settings**:
    - **Root Directory**: `(Leave Blank)` - This is critical for monorepos.
    - **Dockerfile Path**: `Library-Management-System-BE/Dockerfile`.
4.  **Environment Variables**:
    - `ConnectionStrings__DefaultConnection`: Your Neon.tech connection string.
    - `SecretKey`: Your JWT secret key.
    - `ASPNETCORE_URLS`: `http://0.0.0.0:8080`.

---

## 5. Angular Environment Configuration

The frontend was refactored to support multiple environments (Local vs. Prod).

### **Environment Files**
Located in `src/environments/`:
- **`environment.ts` (Default/Prod)**: Uses the Render URL (`https://.../api`).
- **`environment.development.ts` (Local)**: Uses `localhost:7279/api`.

### **Code Refactor**
The `LmsService` was updated to import the `environment` object:
```typescript
import { environment } from '../../../environments/environment';

export class LmsService {
  private apiUrl = environment.apiUrl; // Automatic selection
}
```

---

## 6. GitHub Actions (CI/CD)

Located in `.github/workflows/`:
- **`backend-ci.yml`**: Runs on every push to `main` for the backend. Performs `dotnet restore`, `build`, and `test`.
- **`frontend-ci.yml`**: Runs on every push to `main` for the Angular app. Performs `npm install`, `build`, and `lint`.

---

## 7. Useful Commands

### **Running Locally**
- Backend: `dotnet run --project LMS.API`
- Frontend: `ng serve` (uses `environment.development.ts` automatically).

### **Production Build**
- Frontend: `ng build` (uses `environment.ts` automatically).
