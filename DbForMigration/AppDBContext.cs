using AnimalShelter.src.Models;
using AnimalShelter.src.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.DbForMigration
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
        }
    }
}
