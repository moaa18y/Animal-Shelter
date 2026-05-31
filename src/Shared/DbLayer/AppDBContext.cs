using AnimalShelter.src.Models;
using Microsoft.EntityFrameworkCore;
using System;
using BCrypt.Net;
using System.Collections.Generic;
using AnimalShelter.src.Shared.Enums;

namespace AnimalShelter.src.Shared.DbLayer
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CareNote> CareNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Adoption>().HasQueryFilter(a => !a.IsDeleted);
            modelBuilder.Entity<Vaccine>().HasQueryFilter(v => !v.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<CareNote>().HasQueryFilter(c => !c.IsDeleted);

            
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,  
                    RoleName = EnumRole.Admin,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Role
                {
                    RoleId = 2,  
                    RoleName = EnumRole.Employee,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Role
                {
                    RoleId = 3,  
                    RoleName = EnumRole.User,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
            );

            
            modelBuilder.Entity<User>().HasData(
                
                new User
                {
                    UserId = 1,  
                    UserName = "admin_john",
                    UserEmail = "john.admin@animalshelter.com",
                    UserPassword = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    RoleId = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new User
                {
                    UserId = 2,  
                    UserName = "admin_sarah",
                    UserEmail = "sarah.admin@animalshelter.com",
                    UserPassword = BCrypt.Net.BCrypt.HashPassword("Admin@456"),
                    RoleId = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                
                new User
                {
                    UserId = 3,  
                    UserName = "employee_mike",
                    UserEmail = "mike.employee@animalshelter.com",
                    UserPassword = BCrypt.Net.BCrypt.HashPassword("Employee@123"),
                    RoleId = 2,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new User
                {
                    UserId = 4,  
                    UserName = "employee_lisa",
                    UserEmail = "lisa.employee@animalshelter.com",
                    UserPassword = BCrypt.Net.BCrypt.HashPassword("Employee@456"),
                    RoleId = 2,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                
                new User
                {
                    UserId = 5,  
                    UserName = "user_emma",
                    UserEmail = "emma.user@example.com",
                    UserPassword = BCrypt.Net.BCrypt.HashPassword("User@123"),
                    RoleId = 3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new User
                {
                    UserId = 6,  
                    UserName = "user_james",
                    UserEmail = "james.user@example.com",
                    UserPassword = BCrypt.Net.BCrypt.HashPassword("User@456"),
                    RoleId = 3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new User
                {
                    UserId = 7,  
                    UserName = "user_sophia",
                    UserEmail = "sophia.user@example.com",
                    UserPassword = BCrypt.Net.BCrypt.HashPassword("User@789"),
                    RoleId = 3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
            );

            
            modelBuilder.Entity<Animal>().HasData(
                
                new Animal
                {
                    Id = 1,  
                    Name = "Max",
                    Age = 3,
                    Species = EnumAnimalSpecies.Dog,
                    Status = EnumAnimalStatus.Available,
                    Breed = "Golden Retriever",
                    Size = EnumAnimalSize.Large,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                
                new Animal
                {
                    Id = 2,  
                    Name = "Luna",
                    Age = 2,
                    Species = EnumAnimalSpecies.Cat,
                    Status = EnumAnimalStatus.Available,
                    Color = "Black and White",
                    IsIndoor = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                
                new Animal
                {
                    Id = 3,  
                    Name = "Rio",
                    Age = 1,
                    Species = EnumAnimalSpecies.Bird,
                    Status = EnumAnimalStatus.Available,
                    CanFly = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
            );

            
            modelBuilder.Entity<Vaccine>().HasData(
                new Vaccine
                {
                    VaccineId = 1,  
                    VaccineName = "Rabies",
                    VaccineDescription = "Rabies vaccination",
                    VaccineDate = DateTime.Now.AddMonths(-2),
                    AnimalId = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Vaccine
                {
                    VaccineId = 2, 
                    VaccineName = "Distemper",
                    VaccineDescription = "Canine distemper vaccination",
                    VaccineDate = DateTime.Now.AddMonths(-1),
                    AnimalId = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Vaccine
                {
                    VaccineId = 3,  
                    VaccineName = "FVRCP",
                    VaccineDescription = "Feline viral rhinotracheitis, calicivirus, and panleukopenia",
                    VaccineDate = DateTime.Now.AddMonths(-3),
                    AnimalId = 2,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
            );

            
            modelBuilder.Entity<CareNote>().HasData(
                new CareNote
                {
                    Id = 1,  
                    Title = "Daily Exercise",
                    Description = "Needs at least 30 minutes of daily exercise. Loves playing fetch.",
                    AnimalId = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new CareNote
                {
                    Id = 2,  
                    Title = "Special Diet",
                    Description = "Allergic to chicken. Feed only fish-based food.",
                    AnimalId = 2,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                },
                new CareNote
                {
                    Id = 3,  
                    Title = "Cage Requirements",
                    Description = "Needs a large cage with space to fly. Prefers morning sun.",
                    AnimalId = 3,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}