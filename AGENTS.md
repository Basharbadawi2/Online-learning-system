# AGENTS.md

## Project layout

ASP.NET Core (net8.0) solution with two projects:

- `Online learning system/` — backend REST Web API (controllers, services, repositories, EF Core).
- `OnlineLearningSystem.Web/` — frontend Razor Pages app that calls the API server-side.

## Build & run

```powershell
# Build everything
dotnet build "Online learning system.sln"

# Backend: API at https://localhost:7292 (Swagger in Development)
dotnet run --project "Online learning system"

# Frontend: Razor Pages app configured via OnlineLearningSystem.Web/appsettings.json -> ApiBaseUrl
dotnet run --project "OnlineLearningSystem.Web"
```

## Database (EF Core, SQL Server LocalDB)

Connection string: `Server=(localdb)\MSSQLLocalDB;Database=OnlineLearningDB;Trusted_Connection=True;TrustServerCertificate=True` (backend `appsettings.json`).

```powershell
dotnet ef migrations add <Name> --project "./Online learning system" --startup-project "./Online learning system"
dotnet ef database update     --project "./Online learning system" --startup-project "./Online learning system"
```

- `OnlineLearningDbContext` handles schema and seeds `Role` via `HasData` (1=Student, 2=Instructor, 3=Admin).
- A design-time `ApplyMigrations`-style auto-migrate is NOT enabled; run `database update` explicitly or keep the DB current.

## Conventions & gotchas

- JWT auth: backend issues/signs tokens (`Jwt:Key` in backend `appsettings.json`; override via env var in production). Frontend never validates tokens — it forwards them.
- Frontend auth: JWT stored in HttpOnly cookie `OLS_Token`; `JwtAuthorizationHandler` (DelegatingHandler on `ApiClient`) forwards it. User identity comes from ASP.NET Core cookie auth `OLS_Auth` (claims: NameIdentifier, Name, Email, Role).
- Razor Pages authorization is folder-based in `OnlineLearningSystem.Web/Program.cs`:
  `/Student` -> Student role, `/Instructor` -> Instructor role, `/Admin` -> Admin role.
- Identity link: `Course.InstructorId` = `Instructor.InstructorId` (Instructor PK), NOT `User.UserId`. Always resolve instructor-by-user via `GET api/Instructors/by-user/{userId}` or `GET api/Courses/by-user/{userId}` — do not treat `_authSession.UserId` as an InstructorId.
- Backend controllers: `[Authorize]` on all business endpoints; `[AllowAnonymous]` only on `/api/Auth/*` and GET `/api/Courses`, GET `/api/Categories`; `/api/Users` and `/api/Roles` are Admin-only.
- Controllers return raw entities; JSON uses `ReferenceHandler.IgnoreCycles` (backend `Program.cs`).
- New registration always gets `RoleId = 1` (Student). No self-serve "become instructor" flow exists yet.

## Verification

- Run `dotnet build "Online learning system.sln"` — must finish with 0 warnings / 0 errors.
- No test project exists yet.