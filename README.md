# Animal Shelter Management System

A role-based C# console application for managing an animal shelter, built with Entity Framework Core and SQL Server.

---

## How to Run

```bash
# 1. Update the connection string in appsettings.json

# 2. Apply migrations
dotnet ef database update

# 3. Start the app
dotnet run
```

---

## Default Seed Users

| Username       | Email                              | Password      | Role     |
|----------------|------------------------------------|---------------|----------|
| admin_john     | john.admin@animalshelter.com       | Admin@123     | Admin    |
| admin_sarah    | sarah.admin@animalshelter.com      | Admin@456     | Admin    |
| employee_mike  | mike.employee@animalshelter.com    | Employee@123  | Employee |
| employee_lisa  | lisa.employee@animalshelter.com    | Employee@456  | Employee |
| user_emma      | emma.user@example.com              | User@123      | User     |
| user_james     | james.user@example.com             | User@456      | User     |
| user_sophia    | sophia.user@example.com            | User@789      | User     |

---

## Role Permissions

| Feature                  | Admin          | Employee      | User        |
|--------------------------|----------------|---------------|-------------|
| View animals             | Yes            | Yes           | Yes         |
| Add animal               | Yes            | No            | No          |
| Remove animal            | Yes            | No            | No          |
| Update animal status     | Yes            | Yes           | No          |
| Adopt animal             | Yes (any user) | Yes           | Yes (self)  |
| Manage adoptions         | Full           | View / Add    | Add only    |
| Add / update care notes  | Yes            | Yes           | No          |
| Add / update vaccines    | Yes            | Yes           | No          |
| User management          | Full           | No            | No          |

---

## Project Structure

```
src/
├── Models/
│   ├── BaseEntity.cs          ← Shared audit fields: CreatedAt, UpdatedAt, IsDeleted, ...
│   ├── Animal.cs              ← Flat model — all species fields in one table
│   ├── User.cs
│   ├── Role.cs
│   ├── Adoption.cs
│   ├── Vaccine.cs
│   └── CareNote.cs
│
├── Models/Enums/
│   ├── EnumAnimalSpecies.cs   ← Dog, Cat, Bird, SmallAnimal
│   ├── EnumAnimalStatus.cs    ← Available, Adopted, UnderMedicalCare
│   ├── EnumAnimalSize.cs      ← Small, Medium, Large
│   └── EnumRole.cs            ← Admin, Employee, User
│
├── Repositories/
│   ├── Interfaces/            ← IAnimalRepository, IUserRepo, IAdoptionRepo, ...
│   └── Implementations/       ← AnimalRepo, UserRepo, AdoptionRepo, CareNoteRepo, VaccineRepo
│
├── Services/
│   ├── Interfaces/            ← IAnimalService, IUserService, IAdoptionService, ...
│   └── Implementations/       ← AnimalService, UserService, AdoptionService, ...
│
├── Controllers/
│   ├── AuthorizationController.cs   ← Login flow
│   ├── AnimalsController.cs         ← Animal menu (role-aware)
│   └── UsersController.cs           ← Main menu dispatcher + all sub-menus
│
├── Shared/
│   ├── Helpers.cs             ← All console input/output helpers
│   └── Dtos/                  ← All DTOs (AddAnimalDto, GetAnimalDto, UserDto, ...)
│
├── DbForMigration/
│   └── AppDBContext.cs        ← EF Core DbContext + global query filters + seed data
│
└── Program.cs                 ← DI wiring and startup
```

---

## Architecture

```
Console UI
  AuthorizationController  →  login
  UsersController          →  role-based menu dispatcher
  AnimalsController        →  animal CRUD

Service Layer
  AnimalService / UserService / AdoptionService / CareNoteService / VaccineService

Repository Layer
  AnimalRepo / UserRepo / AdoptionRepo / CareNoteRepo / VaccineRepo

Database
  AppDBContext (EF Core + SQL Server)
  Tables: Animals, Users, Roles, Adoptions, Vaccines, CareNotes
```

---

## Animal Species & Their Fields

When adding an animal you are only asked for the fields that apply to that species:

| Species     | Extra fields                  |
|-------------|-------------------------------|
| Dog         | Breed, Size                   |
| Cat         | Color, IsIndoor               |
| Bird        | CanFly                        |
| SmallAnimal | AnimalType, IsNocturnal       |

All animals share: Name, Age, Species, Status (default: Available).

---

## Soft Delete

No record is ever permanently deleted. Every entity has:

```
IsDeleted  bool      — true = hidden from all queries
DeletedAt  DateTime
DeletedBy  string
```

EF Core global query filters automatically exclude soft-deleted records from every query.

---

## OOP & SOLID Concepts

| Concept | Where |
|---|---|
| **Encapsulation** | DTOs separate the API surface from the database model |
| **Interfaces** | Every repo and service has an interface — controllers depend on abstractions |
| **SRP** | Repos handle data access only; Services handle business rules only; Controllers handle UI only |
| **OCP** | Add a new animal species by extending the enum and the switch in `AnimalsController.AddAnimal` |
| **DIP** | Controllers depend on service interfaces; services depend on repo interfaces |
| **Soft Delete** | Centralised in `BaseEntity` — one flag protects all tables |
| **Global Query Filters** | `HasQueryFilter(e => !e.IsDeleted)` in `AppDBContext` — applied automatically everywhere |