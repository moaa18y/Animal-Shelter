using AnimalShelter.DbForMigration;
using AnimalShelter.src.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter.src.Repositories.Implementations
{
    public class VaccineRepo : IVaccineRepo
    {
        private readonly AppDBContext _dbContext;

        public VaccineRepo(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddVaccine(Vaccine vaccine)
        {
            _dbContext.Add(vaccine);
        }

       

        public List<Vaccine> GetAllVaccines()
        {
            return _dbContext.Vaccines.ToList();
        }

        
        public Vaccine GetVaccineById(int id)
        {
            return _dbContext.Vaccines.FirstOrDefault(u=>u.VaccineId == id);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}
