using Animal_Shelter_V2.src.Models;
using AnimalShelter.DbForMigration;
using AnimalShelter.src.Repositories.Interfaces;
using System;

namespace Animal_Shelter.src.Repositories.Implementations
{
    public class AdoptionRepo : IAdoptionRepo
    {
        private readonly AppDBContext _dbContext;
        public AdoptionRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            
        }
        public void AddAdoption(Adoption adoption)
        {    
            _dbContext.Adoptions.Add(adoption);
            _dbContext.SaveChanges();
        }
    }
}